using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightMeditor : IMediator
{
    private FightUI view;
    SelectLevelDataSmallProxy proxy1;
    MapDataProxy proxy2;
    MosterDataProxy proxy3;
    LevelDataSmall data1;
    MapData data2;
    float HP=10;//萝卜血量
    int money;//金币数量
  


    public FightMeditor(IUserInterface uI) : base(uI)
    {
        PlayerPrefs.SetString("是否结束","否");
        view = (FightUI)UI;
        proxy1 = m_Facade.GetProxy<SelectLevelDataSmallProxy>();
        proxy2 = m_Facade.GetProxy<MapDataProxy>();
        proxy3 = m_Facade.GetProxy<MosterDataProxy>();
        data1 = proxy1.GetByDic(PlayerPrefs.GetInt("NowIndex"));
        data2 = proxy2.GetMapDataById(PlayerPrefs.GetInt("NowIndex").ToString());
        mosterData = proxy3.GetByDic(data1.MosterID);

        Register();
        SetData();

    }


    public void SetData()
    {
        money = data1.Money;
        AllBo = data1.Frequency;
        view.SetMoney(money.ToString());
        view.SetBo(nowBo + "/" + AllBo);
        view.SetCloud_Left(m_Facade.GetSpriteByAtlas(data1.AtlasPathBGLeft, data1.AtlasBGLeftID));
        view.SetCloud_Right(m_Facade.GetSpriteByAtlas(data1.AtlasPathBGRight, data1.AtlasBGRightID));
        view.SetBG(m_Facade.GetSpriteByAtlas(data1.AtlasPathBG, data1.BGindex));
        view.SetRoute(m_Facade.GetSpriteByAtlas(data1.AtlasPathRoute, data1.AtlasBGRouteID));
        view.SetMap(data2);
        view.SetBattery(data1.BatteryIds);
        NewInvoke.Instance.Add(new MyInv(() =>
        {
            view.SetGuaiStart(data2.paths[0]);
            view.SetLuoBo(data2.paths[data2.paths.Count - 1]);
            Debug.Log("地图生成成功！");
            CreateGuai();
        },
        0.1f,
        1
        ));
    }


    MosterData mosterData;//怪物的信息
    int createNow = 0;//现在生成的第N个怪物
    bool IsNeedCreate = false;//
    int nowBo = 1;//现在的波数
    int AllBo;//总共的波数
    float CreateTimer;//生成怪物时计数
    Dictionary<int, Image> dic_guai = new Dictionary<int, Image>();//存小怪
    public override void Update()
    {
        if (PlayerPrefs.GetInt("IsFight") == 0)
            return;
       
    }
    int id = 1;
    /// <summary>
    /// 创建怪物
    /// </summary>
    public void CreateGuai()
    {
        NewInvoke.Instance.Add(new MyInv(
            () => {
                id = 0;
                PlayerPrefs.SetString("是否正在创建", "是");
            },
            () => {
                if (PlayerPrefs.GetInt("IsFight") == 0)
                    return;
                id++;
                if (m_Facade.IsHasKey_Moster(id))
                    return;
                Image ima = view.CreateGuai(mosterData.Path, data2.paths, id, (id1) => { MessageManager.Instance.Send("移除怪物列表", new Mess(id1));}, () => Eat(), mosterData);
                MessageManager.Instance.Send("添加怪物到列表", new Mess(id, ima));
            },
            () =>{
                PlayerPrefs.SetString("是否正在创建", "否");
                id = 0;
            },
            0.4f,
            data1.Num
            ));
    }




    void Eat()
    {
        if (PlayerPrefs.GetInt("IsFight") == 0)
            return;
        HP -= mosterData.Harm;
        Debug.Log("萝卜血量剩余——" + HP);
        if (HP<=0)
        {
            Debug.Log("输了！");
            PlayerPrefs.SetInt("IsFight", 0);
        }
    }
    public override void Register()
    {
        m_Facade.RegisterMessage("怪物全部死亡", new Observer(() => 
        {
            nowBo++;
            CreateGuai();
            view.SetBo(nowBo + "/" + AllBo);
            if (nowBo >= AllBo)
            {
                Debug.Log("游戏胜利！");
                PlayerPrefs.SetInt("IsFight", 0);
            }
        }));
        MessageManager.Instance.Add("弹出UI选择建造炮台",(mes)=> 
        {
            view.OpenPut((int)mes.Data[0]);
        
        });

        
    }

    public override void Clear()
    {
        view.Release();
        view = null;
        proxy1 = null;
        proxy2 = null;
        proxy3 = null;
        data1 = null;
        data2 = null;
        dic_guai.Clear();
        dic_guai = null;
        mosterData = null;

    }
}
