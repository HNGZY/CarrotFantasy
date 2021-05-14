using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelBigMediator : IMediator
{
    SelectLevelBigUI view;
    SelectLevelDataBigProxy proxy;

    public LevelBigMediator(IUserInterface uI) : base(uI)
    {
        view = (SelectLevelBigUI)UI;
        Register();
        SetContent();
        view.Back = () => { Hide(); };
    }
    /// <summary>
    /// 读表生成大关卡
    /// </summary>
    private void SetContent()
    {
        proxy = m_Facade.GetProxy<SelectLevelDataBigProxy>();
        Dictionary<int, LevelDataBig> dic = proxy.GetDic();
        Transform m_Content = UITool.Instance.Find<Transform>(m_UIRoot.transform, "Content");
        foreach (var item in dic.Values)
        {
            Image btn = GameObject.Instantiate(Resources.Load<Image>("Prefab/Image"), m_Content, false);
            btn.sprite = m_Facade.GetSpriteByAtlas(item.AtlasPath, item.Index);
            btn.gameObject.AddComponent<Button>().onClick.AddListener(() => { m_Facade.NotifyMessage("打开选择小关卡面板"); });
        }
        Transform Scrollbar = UITool.Instance.Find<Transform>(this.m_UIRoot.transform, "Scrollbar");
        Scrollbar.gameObject.AddComponent<Test>().conent = m_Content;
    }

    /// <summary>
    /// 注册消息监听
    /// </summary>
    public override void Register()
    {
        m_Facade.RegisterMessage("选择冒险模式", new Observer(() =>{ Open(); }));
    }

}
