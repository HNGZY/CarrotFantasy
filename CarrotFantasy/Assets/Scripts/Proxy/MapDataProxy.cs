using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataProxy : Iproxy
{
    private Dictionary<string, MapData> dic;
    public MapDataProxy(object data) : base(data)
    {
        dic = Data as Dictionary<string, MapData>;
    }

    public MapData GetMapDataById(string ID)
    {
        if(dic.ContainsKey(ID))
        {
            return dic[ID];
        }
        Debug.Log($"没有找到键为{ID}的地图信息！");
        return null;
    }

  
}
