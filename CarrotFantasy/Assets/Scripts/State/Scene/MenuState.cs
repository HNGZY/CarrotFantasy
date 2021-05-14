using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseSceneState
{

    public override void StateBegin()
    {
        PlayerPrefs.SetInt("IsFight", 0);
        Facade.Instance().Initialize_MainScene();
    }

    public override void StateUpdate()
    {
        if (PlayerPrefs.GetInt("IsFight") == 1 )
        {
            m_Controller.SetState<FightState>("FightScene");
        }
    }

    public override void StateEnd()
    {
        Facade.Instance().Clear();
    }


}
