using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIMediator : IMediator
{
    MainUI view;

    public MainUIMediator(IUserInterface uI) : base(uI)
    {
        view = (MainUI)UI;

        this.view.AdventureMode = () => { m_Facade.NotifyMessage("选择冒险模式"); };
    }



}
