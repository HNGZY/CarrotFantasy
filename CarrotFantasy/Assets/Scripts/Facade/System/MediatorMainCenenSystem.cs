using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediatorMainCenenSystem : MediatorManageSystem
{
    public MediatorMainCenenSystem(Facade facade) : base(facade)
    {
        Initialize();
    }

    public override void Initialize()
    {
        mainUIMediator = new MainUIMediator(new MainUI(m_facade));
        levelBigMediator = new LevelBigMediator(new SelectLevelBigUI(m_facade));
        levelSmallMediator = new LevelSmallMediator(new SelectLevelSmallUI(m_facade));
    }

    public override void Clear()
    {
        mainUIMediator.Clear();
        levelBigMediator.Clear();
        levelSmallMediator.Clear();
        mainUIMediator = null;
        levelBigMediator = null;
        levelSmallMediator = null;
    }

    public override void Update()
    {
        mainUIMediator.Update();
        levelBigMediator.Update();
        levelSmallMediator.Update();
    }
}
