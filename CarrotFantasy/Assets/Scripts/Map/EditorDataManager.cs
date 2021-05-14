using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using System;

/// <summary>
/// 编辑器地图数据操作在这里
/// </summary>
public class EditorDataManager
{
    static EditorDataManager ins;
    public static EditorDataManager Ins
    {
        get
        {
            if (ins == null)
            {
                ins = new EditorDataManager();
            }
            return ins;
        }
    }

    internal void Click(MapItemData data)
    {
        if (State!=-1)
        {
            data.type = State;
        }
        if (State==3)
        {
            dic_MapData[id].paths.Add(data.id);
        }
    }

    public int State = -1;
    public string id;

    private Dictionary<string, MapData> dic_MapData;
   
    public void Init()
    {
        Clear1();
        dic_MapData = new Dictionary<string, MapData>();
        Load();
       

    }

    public void ADD(string id)
    {
        dic_MapData.Add(id, new MapData(id));
        
    }

    //清除路径
    public void ClearPath()
    {
        if (dic_MapData.ContainsKey(id))
        {
            dic_MapData[id].ClearPath();
        }
    }

    
    /// <summary>
    /// 按照数据生成一个新的地图
    /// </summary>
    public void CreateByData(string id)
    {
        this.id = id;
        Transform content = GameObject.Find("Content").transform;
        GameObject clone = Resources.Load<GameObject>("Prefab/Image");
        Dictionary<int, MapItemData> dic1 = dic_MapData[id].dic;
        foreach (var item in dic1.Values)
        {
            GameObject a = GameObject.Instantiate(clone, content, false);
            DiKuai kuai = a.AddComponent<DiKuai>();
            kuai.data = item;
        }
    }
    public Dictionary<string, MapData> getData()
    {
        return dic_MapData;
    }

    /// <summary>
    /// 加载数据
    /// </summary>
    public void Load()
    {
        string path = GetPath();
        string str = File.ReadAllText(path);
        List<MapData> da = JsonConvert.DeserializeObject<List<MapData>>(str);
        foreach (var item in da)
        {
            dic_MapData.Add(item.id, item);
        }
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    public void Save()
    {
        string path = GetPath();


        File.WriteAllText(path, JsonConvert.SerializeObject(dic_MapData.Values));


    }

    string GetPath()
    {
        string Path = Application.dataPath + "/Resources/Data/Map.json";
        if(!File.Exists(Path))
        {
            File.WriteAllText(Path, "[]");
        }
        return Path;
    }

    /// <summary>
    /// 清除数据
    /// </summary>
    public void Clear1()
    {
        if (dic_MapData != null)
            dic_MapData.Clear();

      
    }
    public void Clear2()
    {
        Transform content = GameObject.Find("Content").transform;
        if (content.childCount == 0)
        {
            return;
        }
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(content.GetChild(i).gameObject);
        }
    }



}
