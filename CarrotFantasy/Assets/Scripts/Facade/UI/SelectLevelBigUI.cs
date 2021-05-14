using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
public class SelectLevelBigUI : IUserInterface
{
    public Action Back;
    public SelectLevelBigUI(Facade facade) : base(facade)
    {
        Initialize();
    }
    public override void Update()
    {
        if (!IsOpening)
            return;
    }

    private Button m_Back;
    private Button m_WenHao;
    public Transform m_Content;

    public override void Initialize()
    {
        m_UIRoot = UITool.Instance.GetUIObj("SelectLevalBig");
        m_Back = UITool.Instance.Find<Button>(m_UIRoot.transform,"Back");
        m_WenHao = UITool.Instance.Find<Button>(m_UIRoot.transform, "WenHao");
        m_Back.onClick.AddListener(()=> { Back?.Invoke(); });
        m_UIRoot.SetActive(false);
    }

}
