using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelSmallUI : IUserInterface
{
    public Action Back;
    private SelectLevelDataSmallProxy proxy;
    public SelectLevelSmallUI(Facade facade) : base(facade)
    {
        Initialize();
    }

    private Button m_Back;
    private Button m_WenHao;

    public override void Update()
    {
        base.Update();
    }
    public override void Initialize()
    {
        m_UIRoot = UITool.Instance.GetUIObj("SelectLevalSmall");
        m_Back = UITool.Instance.Find<Button>(m_UIRoot.transform, "Back");
        m_WenHao = UITool.Instance.Find<Button>(m_UIRoot.transform, "WenHao");
        m_Back.onClick.AddListener(() => { Back?.Invoke(); });
      
        m_UIRoot.SetActive(false);
    }

    public override void Release()
    {

    }
}
