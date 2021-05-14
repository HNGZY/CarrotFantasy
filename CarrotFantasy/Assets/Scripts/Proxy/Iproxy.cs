using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 代理的基类
/// </summary>
public abstract class Iproxy 
{
    /// <summary>
    ///代理的数据
    /// </summary>
    protected object Data;

    protected Iproxy(object data)
    {
        Data = data;
    }
}
