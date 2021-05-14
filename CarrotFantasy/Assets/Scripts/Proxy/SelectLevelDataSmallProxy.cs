using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelDataSmallProxy : Iproxy
{
    private Dictionary<int, LevelDataSmall> dic; 
    public SelectLevelDataSmallProxy(object data) : base(data)
    {
        dic = Data as Dictionary<int, LevelDataSmall>;
    }


    public LevelDataSmall GetByDic(int key)
    {
        if (dic.ContainsKey(key))
        {
            return dic[key];
        }
        Debug.Log($"没有找到键为{key}的Value——SelectLevelDataSmallProxy");
        return null;
    }
    public Dictionary<int, LevelDataSmall> GetDic()
    {
        return dic;
    }



}
