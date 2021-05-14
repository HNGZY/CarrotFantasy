using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMediator
{
    protected Facade m_Facade;
    protected IUserInterface UI;
    protected GameObject m_UIRoot;

    protected IMediator(IUserInterface uI)
    {
        UI = uI;
        GetFacade();
        GetUiToot();
    }

     void GetFacade() {
        m_Facade = UI.GetFacade();
    }
    void GetUiToot()
    {
        m_UIRoot = UI.GetUiRoot();
    }

    /// <summary>
    /// 注册监听
    /// </summary>
    public virtual void Register() { }
    public virtual void Hide()
    {
        m_UIRoot.SetActive(false);
    }
    public virtual void Open()
    {
        m_UIRoot.SetActive(true);
    }
    public virtual void Update()
    {

    }
    public virtual void Clear() { }
}
