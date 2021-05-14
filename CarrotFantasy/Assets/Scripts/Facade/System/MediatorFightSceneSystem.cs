using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediatorFightSceneSystem : MediatorManageSystem
{
    public MediatorFightSceneSystem(Facade facade) : base(facade)
    {
        Initialize();
    }
    public override void Initialize()
    {
        mapMeditor = new FightMeditor(new FightUI(m_facade));
    }
    public override void Clear()
    {
        mapMeditor.Clear();
        mapMeditor = null;
    }
    public override void Update()
    {
        mapMeditor.Update();
    }
}
