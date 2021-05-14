using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelDataBigProxy : Iproxy
{
    private Dictionary<int, LevelDataBig> dic;
    public SelectLevelDataBigProxy(Dictionary<int,LevelDataBig> data) : base(data)
    {
        dic = Data as Dictionary<int, LevelDataBig>;
    }
    public LevelDataBig GetByDic(int key)
    {
        if(dic.ContainsKey(key))
        {
            return dic[key];
        }
        Debug.Log($"没有找到键为{key}的Value——SelectLevelBigProxy");
        return null;
    }
    public Dictionary<int,LevelDataBig> GetDic()
    {
        return dic;
    }
    

}
