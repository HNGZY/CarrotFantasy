using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    public string id;
    public Dictionary<int, MapItemData> dic = new Dictionary<int, MapItemData>();
    public List<int> paths = new List<int>();

    public void ClearPath()
    {
        foreach (var item in paths)
        {
            dic[item].type = 0;
        }
        paths.Clear();
    }
    public MapData(string id)
    {
        this.id = id;
        for (int i = 0; i < 55; i++)
        {
            dic.Add(i, new MapItemData(i));
        }
    }
}

public class MapItemData
{
    public int id;
    public int type=0;//(0 空地  1 建筑物  2 炮台 3 路径 4 不可用)

    public MapItemData(int id)
    {
        this.id = id;
    }
}


