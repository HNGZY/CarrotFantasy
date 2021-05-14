using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterDataProxy : Iproxy
{
    private Dictionary<int, MosterData> dic;
    public MosterDataProxy(object data) : base(data)
    {
        dic = Data as Dictionary<int, MosterData>;
    }

    public MosterData GetByDic(int key)
    {
        if (dic.ContainsKey(key))
        {
            return dic[key];
        }
        Debug.Log($"没有找到键为{key}的Value——MosterDataProxy");
        return null;
    }
    public Dictionary<int, MosterData> GetDic()
    {
        return dic;
    }
}
