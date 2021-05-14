using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMeditor : IMediator
{
    private MapUI view;
    SelectLevelDataSmallProxy proxy1;
    MapDataProxy proxy2;
    MosterDataProxy proxy3;
    LevelDataSmall data1;
    MapData data2;

    float HP=10;//萝卜血量
    int money;//金币数量
  


    public MapMeditor(IUserInterface uI) : base(uI)
    {
        PlayerPrefs.SetString("是否结束","否");
        view = (MapUI)UI;
        proxy1 = m_Facade.GetProxy<SelectLevelDataSmallProxy>();
        proxy2 = m_Facade.GetProxy<MapDataProxy>();
        proxy3 = m_Facade.GetProxy<MosterDataProxy>();
        data1 = proxy1.GetByDic(PlayerPrefs.GetInt("NowIndex"));
        data2 = proxy2.GetMapDataById(PlayerPrefs.GetInt("NowIndex").ToString());
        mosterData = proxy3.GetByDic(data1.MosterID);

        Register();
        SetData();
    }

    float timer = 0;
    Action action;
    bool bo = false;


    public void SetData()
    {
        bo = true;
        money = data1.Money;
        AllBo = data1.Frequency;
        view.SetMoney(money.ToString());
        view.SetBo(nowBo + "/" + AllBo);
        view.SetCloud_Left(m_Facade.GetSpriteByAtlas(data1.AtlasPathBGLeft, data1.AtlasBGLeftID));
        view.SetCloud_Right(m_Facade.GetSpriteByAtlas(data1.AtlasPathBGRight, data1.AtlasBGRightID));
        view.SetBG(m_Facade.GetSpriteByAtlas(data1.AtlasPathBG, data1.BGindex));
        view.SetRoute(m_Facade.GetSpriteByAtlas(data1.AtlasPathRoute, data1.AtlasBGRouteID));
        view.SetDiTu(data2); 
        action = () =>
        {
            view.SetGuaiStart(data2.paths[0]);
            view.SetLuoBo(data2.paths[data2.paths.Count - 1]);
            Debug.Log("地图生成成功！");
            IsNeedCreate = true;
        };


       
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
        if (bo)
        {
            timer += Time.deltaTime;
            if (timer >  0.1f)
            {
                timer = 0;
                bo = false;
                action?.Invoke();
            }
        }
        if (IsNeedCreate)
        {
            CreateTimer += Time.deltaTime;
            if (CreateTimer>=0.4f)
            {
                CreateTimer = 0;
                dic_guai.Add(createNow++, view.CreateGuai(mosterData.Path,data2.paths,createNow-1,(id)=>GuaiSi(id),()=> Eat(), mosterData));
                if (createNow>=data1.Num)
                {
                    IsNeedCreate = false;
                    createNow = 0;
                }
            }
        }

    }


    void GuaiSi(int id)
    {
       
        if (!dic_guai.ContainsKey(id))
            return;
        GameObject.Destroy(dic_guai[id].gameObject);
        dic_guai.Remove(id);


        if (PlayerPrefs.GetInt("IsFight") == 0)
        {
            return;
        }
        if (dic_guai.Count == 0 && IsNeedCreate == false)
        {
            Debug.Log($"当前完成第{nowBo}波");
            IsNeedCreate = true;
            nowBo++;
            view.SetBo(nowBo + "/" + AllBo);
            if (nowBo >= AllBo)
            {
                Debug.Log("游戏胜利！");
                PlayerPrefs.SetInt("IsFight", 0);
            }
        }

    }


    void Eat()
    {
        HP -= mosterData.Harm; ;
        if (HP<=0)
        {
            Debug.Log("输了！");
            PlayerPrefs.SetInt("IsFight", 0);

        }
    }
    public override void Register()
    {

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
