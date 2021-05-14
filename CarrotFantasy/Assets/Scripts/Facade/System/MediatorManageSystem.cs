using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 中介管理系统
/// </summary>
public abstract class MediatorManageSystem : IGameSystem
{
    protected MainUIMediator mainUIMediator;
    protected LevelBigMediator levelBigMediator;
    protected LevelSmallMediator levelSmallMediator;
    protected FightMeditor mapMeditor;
    public MediatorManageSystem(Facade facade) : base(facade)
    {
    }
}
