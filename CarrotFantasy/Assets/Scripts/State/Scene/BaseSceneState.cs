using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有的状态的脚本都继承的类
/// </summary>
public  class BaseSceneState
{
    private string m_StateName = "ISceneState";
    public string StateName
    {
        get
        {
            return m_StateName;
        }
        set
        {
            m_StateName = value;
        }
    }

    /// <summary>
    /// 控制者
    /// </summary>
    protected SceneStateController m_Controller = null;

    public BaseSceneState()
    {
    }
    public void SetCtrl(SceneStateController controller)
    {
        this.m_Controller = controller;
    }
    /// <summary>
    /// 状态开始的时候执行的方法
    /// </summary>
    public virtual void StateBegin() { }
    /// <summary>
    /// 状态结束的时候执行的方法
    /// </summary>
    public virtual void StateEnd() { }
    /// <summary>
    /// 状态更新的时候执行的方法（每帧执行）
    /// </summary>
    public virtual void StateUpdate() { }

    /// <summary>
    /// 重写ToString的方法
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "当前状态是:" + m_StateName;
    }

}
