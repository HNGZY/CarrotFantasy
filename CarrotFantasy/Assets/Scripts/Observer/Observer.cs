using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Observer : IObserver
{
    private Action m_something;

    public Observer(Action something)
    {
        m_something = something;
    }

    public void DoSomething()
    {
        m_something?.Invoke();
    }


}
