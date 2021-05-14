using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterData : DataBase
{
    /// <summary>
    /// 怪物的移动速度
    /// </summary>
    public float Speed;
    /// <summary>
    /// 怪物对萝卜的伤害
    /// </summary>
    public float Harm;
    /// <summary>
    /// 怪物的血量
    /// </summary>
    public float Hp;
    /// <summary>
    /// 怪物的路径
    /// </summary>
    public string Path;
   

    public override void SetData(string str)
    {
        string[] arr = Cut(str);
        ID = int.Parse(arr[0]);
        Speed = float.Parse(arr[1]);
        Harm = float.Parse(arr[2]);
        Hp = float.Parse(arr[3]);
        Path = arr[4];
    }
}
