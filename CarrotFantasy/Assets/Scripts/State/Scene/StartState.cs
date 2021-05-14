using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartState : BaseSceneState
{
    float Timer = 0;
    public override void StateBegin()
    {
        Facade.Instance().LoadConfig();
        Debug.Log("进入StartGame状态！");
        Timer = 0;

    }
    public override void StateUpdate()
    {
        Timer += Time.deltaTime;
        if(Timer>=2)
        {
            m_Controller.SetState<MenuState>("MainScene");
        }

    }

}
