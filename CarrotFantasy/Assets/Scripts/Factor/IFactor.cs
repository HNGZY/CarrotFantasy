using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IFactor
{
    protected IFactor()
    {
    }

    public abstract void Create(params object[] data);
}
