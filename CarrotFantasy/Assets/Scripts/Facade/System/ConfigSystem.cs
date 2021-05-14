using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Newtonsoft.Json;

/// <summary>
/// 配置管理系统（读取配置表，这个不会被清除）
/// </summary>
public class ConfigSystem : IGameSystem
{
    /// <summary>
    /// 存放读取的配置表的代理，可以通过Facade获取
    /// </summary>
    private Dictionary<Type, Iproxy> ProxyDic = new Dictionary<Type, Iproxy>();
    public ConfigSystem(Facade facade) : base(facade)
    {
        Initialize();
    }

    public override void Initialize()
    {
        Load();
    }

    public T Getproxy<T>() where T:Iproxy
    {
        if(ProxyDic.ContainsKey(typeof(T)))
        {
            return ProxyDic[typeof(T)] as T;
        }
        Debug.Log($"没有找到代理！——{typeof(T).ToString()}");

        return null;
    }

    private void Load()
    {
        string[] str_Guai = File.ReadAllLines(Application.dataPath + "/Resources/" + "Data/Moster.csv");
        string[] str_Battery = File.ReadAllLines(Application.dataPath + "/Resources/" + "Data/Battery.csv");
        string[] str_LevelBig = File.ReadAllLines(Application.dataPath + "/Resources/" + "Data/Level_Big.csv");
        string[] str_LevelSmall = File.ReadAllLines(Application.dataPath + "/Resources/" + "Data/Level_Small.csv");


        ProxyDic.Add(typeof(SelectLevelDataBigProxy), new SelectLevelDataBigProxy(AddDic<LevelDataBig>(str_LevelBig)));
        ProxyDic.Add(typeof(SelectLevelDataSmallProxy), new SelectLevelDataSmallProxy(AddDic<LevelDataSmall>(str_LevelSmall)));
        ProxyDic.Add(typeof(MosterDataProxy), new MosterDataProxy(AddDic<MosterData>(str_Guai)));
        ProxyDic.Add(typeof(BatteryDataProxy), new BatteryDataProxy(AddDic<BatteryData>(str_Battery)));
        ProxyDic.Add(typeof(MapDataProxy), new MapDataProxy(GetmapData()));

        Debug.Log("配置表解析完成！");

    }
    private Dictionary<int, T> AddDic<T>(string[] arr) where T :DataBase,new()
    {

        Dictionary<int, T> newdic = new Dictionary<int, T>();
        for (int i = 1; i < arr.Length; i++)
        {
            T data = new T();
            data.SetData(arr[i]);
            newdic[data.ID] = data;
        }
        return newdic;
    }


    private Dictionary<string,MapData> GetmapData()
    {
        Dictionary<string, MapData> dic=new Dictionary<string, MapData>();
        //string Path = Application.dataPath + "/Resources/Data/Map.json";
        string path = Application.dataPath+"/Resources/Data/Map.json";
        string str = File.ReadAllText(path);
        List<MapData> da = JsonConvert.DeserializeObject<List<MapData>>(str);
        foreach (var item in da)
        {
            dic.Add(item.id, item);
        }
        return dic;
    }

}


