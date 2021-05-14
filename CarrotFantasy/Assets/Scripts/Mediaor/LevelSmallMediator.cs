using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSmallMediator : IMediator
{

    SelectLevelSmallUI view;
    SelectLevelDataSmallProxy proxy;

    Transform m_Content;
    int NowIndex=1;
    Dictionary<int, GameObject> dic_Battery;
    public LevelSmallMediator(IUserInterface uI) : base(uI)
    {
        view = (SelectLevelSmallUI)UI;
        view.Back = () => { Hide(); };
        Register();
        SetConent();
        SetTest();
        SetBattery();
    }

    private void SetBattery()
    {
        Transform m_Gameobject = UITool.Instance.Find<Transform>(m_UIRoot.transform, "GameObject");
        dic_Battery = new Dictionary<int, GameObject>();
        for (int i = 0; i < m_Gameobject.childCount; i++)
        {
            dic_Battery.Add(i + 1, m_Gameobject.GetChild(i).gameObject);
        }

    }

    private void SetConent()
    {
        proxy = m_Facade.GetProxy<SelectLevelDataSmallProxy>();
        Dictionary<int, LevelDataSmall> dic = proxy.GetDic();
        m_Content = UITool.Instance.Find<Transform>(m_UIRoot.transform, "Content");
        foreach (var item in dic.Values)
        {
            Image btn = GameObject.Instantiate(Resources.Load<Image>("Prefab/Image"), m_Content, false);
            btn.sprite = m_Facade.GetSpriteByAtlas(item.AtlasPath, item.Index);
            btn.gameObject.AddComponent<Button>().onClick.AddListener(() => { m_Facade.NotifyMessage("进入游戏"); });
        }
      
      

    }
    private void SetTest()
    {
        Scrollbar Scrollbar = UITool.Instance.Find<Scrollbar>(this.m_UIRoot.transform, "Scrollbar");
        Test test = Scrollbar.gameObject.AddComponent<Test>();
        test.conent = m_Content;
        test.action = (index) =>
        {
            NowIndex = index + 1;
            m_Facade.NotifyMessage("刷新可以使用的炮台");
        };
    }

    public override void Register()
    {
        m_Facade.RegisterMessage("打开选择小关卡面板", new Observer(() => { 
            Open();
            m_Facade.NotifyMessage("刷新可以使用的炮台");
        }));
        m_Facade.RegisterMessage("进入游戏", new Observer(() => 
        {
            Debug.Log("进入游戏");
            PlayerPrefs.SetInt("NowIndex", NowIndex+1000);
            PlayerPrefs.SetInt("IsFight", 1);
        }  ));
        m_Facade.RegisterMessage("刷新可以使用的炮台", new Observer(() =>
         {
             LevelDataSmall levelData = proxy.GetByDic(NowIndex+1000);
             foreach (var item in dic_Battery.Values)
             {
                 item.SetActive(false);
             }
             foreach (var item in levelData.BatteryIds)
             {
                if(dic_Battery.ContainsKey(item))
                 {
                     dic_Battery[item].SetActive(true);
                 }
             }

         }));
    }
}
