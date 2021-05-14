using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelDataSmall : DataBase
{
    /// <summary>
    /// 图集的路径
    /// </summary>
    public string AtlasPath;
    /// <summary>
    /// 图集中的下标
    /// </summary>
    public int Index;
    /// <summary>
    /// 本关的怪物的ID
    /// </summary>
    public int MosterID;
    /// <summary>
    /// 每一波怪物的数量
    /// </summary>
    public int Num;
    /// <summary>
    /// 怪物生成的波数
    /// </summary>
    public int Frequency;
    /// <summary>
    /// 可以建造的炮台
    /// </summary>
    public int[] BatteryIds;

    /// <summary>
    ///背景图集
    /// </summary>
    /// <param name="str"></param>
    public string AtlasPathBG;

    public int BGindex;

    public string AtlasPathBGLeft;

    public string AtlasPathBGRight;

    public string AtlasPathRoute;

    public int AtlasBGLeftID;

    public int AtlasBGRightID;

    public int AtlasBGRouteID;

    public int Money;
    public override void SetData(string str)
    {
        string[] arr = Cut(str);
        ID = int.Parse(arr[0]);
        AtlasPath = arr[1];
        Index = int.Parse(arr[2]);
        MosterID = int.Parse(arr[3]);
        Num = int.Parse(arr[4]);
        Frequency = int.Parse(arr[5]);
        BatteryIds = Array.ConvertAll<string, int>(arr[6].Split('/'), int.Parse);
        AtlasPathBG = arr[7];
        BGindex = int.Parse(arr[8]);
        AtlasPathBGLeft = arr[9];
        AtlasPathBGRight = arr[10];
        AtlasPathRoute = arr[11];
        AtlasBGLeftID = int.Parse(arr[12]);
        AtlasBGRightID = int.Parse(arr[13]);
        AtlasBGRouteID = int.Parse(arr[14]);
        Money = int.Parse(arr[15]);
    }
}
