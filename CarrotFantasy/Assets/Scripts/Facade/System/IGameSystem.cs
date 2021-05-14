using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IGameSystem 
{
    protected Facade m_facade;

    protected IGameSystem(Facade facade)
    {
        m_facade = facade;
    }

    public virtual void Initialize() { }
    public virtual void Clear() { }
    public virtual void Update() { }
}
