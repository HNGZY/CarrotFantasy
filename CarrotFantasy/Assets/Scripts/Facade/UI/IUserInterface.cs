using UnityEngine;

public abstract class IUserInterface
{
    protected Facade m_Facade;
    protected GameObject m_UIRoot;
    protected bool IsOpening;
    protected IUserInterface(Facade facade)
    {
        m_Facade = facade;
    }

    /// <summary>
    /// 刷新界面
    /// </summary>
    public virtual void Update(){}
    public virtual void Initialize() { }
    public virtual void Release() { }

    public virtual Facade GetFacade()
    {
        return m_Facade;
    }

    public virtual GameObject GetUiRoot()
    {
        return m_UIRoot;
    }
}
