using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataBig:DataBase
{
    /// <summary>
    /// 图集路径
    /// </summary>
    public string AtlasPath;
    /// <summary>
    /// 图集文件中的下标
    /// </summary>
    public int Index;

   
    public override void SetData(string str)
    {
        string[] arr = Cut(str);
        ID = int.Parse(arr[0]);
        AtlasPath = arr[1];
        Index = int.Parse(arr[2]);
    }
}
