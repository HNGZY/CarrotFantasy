using UnityEngine.UI;
using UnityEngine;
using System;
public class MainUI : IUserInterface
{
    public Action AdventureMode;
    /// <summary>
    /// ？按钮
    /// </summary>
    private Button m_Query = null;
    /// <summary>
    /// 设置按钮
    /// </summary>
    private Button m_Set = null;
    /// <summary>
    /// 怪物窝按钮
    /// </summary>
    private Button m_MonsterNest = null;
    /// <summary>
    /// Boos模式按钮
    /// </summary>
    private Button m_BoosMode = null;
    /// <summary>
    /// 冒险模式
    /// </summary>
    private Button m_AdventureMode = null;
    public MainUI(Facade facade) : base(facade)
    {
        Initialize();
    }

    public override void Initialize()
    {
        m_UIRoot = UITool.Instance.GetUIObj("MainPanel");
        m_Query = UITool.Instance.Find<Button>(m_UIRoot.transform, "Query");
        m_Set = UITool.Instance.Find<Button>(m_UIRoot.transform, "Set");
        m_MonsterNest = UITool.Instance.Find<Button>(m_UIRoot.transform, "MonsterNest");
        m_BoosMode = UITool.Instance.Find<Button>(m_UIRoot.transform, "BoosMode");
        m_AdventureMode = UITool.Instance.Find<Button>(m_UIRoot.transform, "AdventureMode");
        m_AdventureMode.onClick.AddListener(()=> {AdventureMode?.Invoke();});
    }



}
