using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class SceneStateController
{
    private BaseSceneState m_State;

    /// <summary>
    /// 是否已经执行Begin方法
    /// </summary>
    private bool m_IsRunBegin = false;

    Dictionary<Type, BaseSceneState> dic = new Dictionary<Type, BaseSceneState>();
    

    public void SetState<T>(string NeedLoodSceneName=null)where T :BaseSceneState,new()
    {
        if (!dic.ContainsKey(typeof(T)))
        {
            dic[typeof(T)] = new T();
        }      


        LoadScene(NeedLoodSceneName);


        if (m_State != null)
            m_State.StateEnd();


        m_State = dic[typeof(T)];
        dic[typeof(T)].SetCtrl(this);

        m_IsRunBegin = false;
    }

    private void LoadScene(string needLoodSceneName)
    {
        if (needLoodSceneName == null || needLoodSceneName.Length == 0)
            return;
        //TODO:考虑是否异步加载
        //NewLoadScene.LoadScene(needLoodSceneName);
        SceneManager.LoadScene(needLoodSceneName);
    }

    public void StateUpdate()
    {
        if (Application.isLoadingLevel)
            return;
        if(m_State!=null&&m_IsRunBegin==false)
        {
            m_State.StateBegin();
            m_IsRunBegin = true;

        }
        if(m_State!=null)
            m_State.StateUpdate();
    }
}
