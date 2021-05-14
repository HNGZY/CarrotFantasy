using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryDataProxy : Iproxy
{
    private Dictionary<int, BatteryData> dic;
    public BatteryDataProxy(object data) : base(data)
    {
        dic = Data as Dictionary<int, BatteryData>;
    }

    public BatteryData GetByDic(int key)
    {
        if (dic.ContainsKey(key))
        {
            return dic[key];
        }
        Debug.Log($"没有找到键为{key}的Value——BatteryDataProxy");
        return null;
    }
    public Dictionary<int, BatteryData> GetDic()
    {
        return dic;
    }


}
