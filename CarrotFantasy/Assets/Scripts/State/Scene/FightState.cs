using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : BaseSceneState
{
    public override void StateBegin()
    {
        Facade.Instance().Initialize_Fight();
        PlayerPrefs.SetInt("IsFight", 1);
    }
    public override void StateEnd()
    {
        Facade.Instance().Clear();
    }

    public override void StateUpdate()
    {
        Facade.Instance().Update();

        if (PlayerPrefs.GetInt("IsFight")==0)
        {
            m_Controller.SetState<MenuState>("MainScene");
        }
    }

}
