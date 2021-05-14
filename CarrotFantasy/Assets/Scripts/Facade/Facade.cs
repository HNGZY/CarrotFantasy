using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facade 
{
    static Facade instance;
    public Facade(){}
    public static Facade Instance()
    {
        if (instance == null)
            instance = new Facade();
        return instance;
    }

    //配置表管理系统
    private ConfigSystem configSystem = null;
    //资源管理系统
    private ExplorerSystem explorerSystem = null;
    //消息管理系统
    private ObserverSystem observerSystem = null;
    //中介者管理系统
    private MediatorManageSystem mediatorManageSystem = null;


    /// <summary>
    /// 怪物管理系统
    /// </summary>
    private MosterSystem mosterSystem;

    /// <summary>
    /// 进入主场景后初始化
    /// </summary>
    public void Initialize_MainScene()
    {
        observerSystem = new ObserverSystem(this);
        mediatorManageSystem = new MediatorMainCenenSystem(this);
    }

    /// <summary>
    /// 进入FightState时调用这个初始化
    /// </summary>
    public void Initialize_Fight()
    {
        observerSystem = new ObserverSystem(this);
        mediatorManageSystem = new MediatorFightSceneSystem(this);
        mosterSystem = new MosterSystem(this);
    }

    public void Update()
    {
        if (mediatorManageSystem!=null)
            mediatorManageSystem.Update();
    }
   /// <summary>
   /// 清除
   /// </summary>
    public void Clear()
    {
        observerSystem.Clear();
        mediatorManageSystem.Clear();
        if (mosterSystem != null)
            mosterSystem.Clear();
        MessageManager.Instance.Clear();
    }
    /// <summary>
    /// 注册监听消息
    /// </summary>
    /// <param name="key"></param>
    /// <param name="observer"></param>
    /// 
    public void RegisterMessage(string key, IObserver observer)
    {
        observerSystem.RegisterMessage(key, observer);
    }
    /// <summary>
    /// 移除监听消息
    /// </summary>
    /// <param name="key"></param>
    /// <param name="observer"></param>
    public void RemoveMessage(string key,IObserver observer)
    {
        observerSystem.RemoveMessage(key, observer);
    }
    /// <summary>
    /// 通知消息
    /// </summary>
    /// <param name="key"></param>
    public void NotifyMessage(string key)
    {
        observerSystem.NotifyMessage(key);
    }
    /// <summary>
    /// 获取代理
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public T GetProxy<T>() where T :Iproxy
    {
        return configSystem.Getproxy<T>();
    }
    /// <summary>
    /// 获取图集中的切图
    /// </summary>
    /// <param name="path"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public Sprite GetSpriteByAtlas(string path, int index)
    {
        return explorerSystem.GetSpriteByAtlas(path, index);
    }
    /// <summary>
    /// 加载资源
    /// </summary>
    public void LoadConfig()
    {
        explorerSystem = new ExplorerSystem(this);
        configSystem = new ConfigSystem(this);
    }


    /// <summary>
    /// 获取目标
    /// </summary>
    public Transform GetMuBiao(Vector3 pos,float juli)
    {
        return mosterSystem.Get(pos, juli);
    }

    public bool IsHasKey_Moster(int id)
    {
        return mosterSystem.IsHasKey(id);
    }
}
