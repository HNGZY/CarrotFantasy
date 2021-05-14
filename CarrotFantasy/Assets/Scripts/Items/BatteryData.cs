using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 炮台的数据结构
/// </summary>
public class BatteryData : DataBase
{
    /// <summary>
    /// 炮台的价格
    /// </summary>
    public float Price;
    /// <summary>
    /// 炮台的攻击范围
    /// </summary>
    public float AttackRange;
    /// <summary>
    /// 炮台的攻击速度
    /// </summary>
    public float AttackSpeed;
    /// <summary>
    /// 炮台的伤害值
    /// </summary>
    public float Damage;
    /// <summary>
    /// 炮台的子弹ID
    /// </summary>
    public int BulletID;

    public int AddXiao;

    public string Path;

    public int Index;
  
    public override void SetData(string str)
    {
        string[] arr = Cut(str);
        ID = int.Parse(arr[0]);
        Price = float.Parse(arr[1]);
        AttackRange = float.Parse(arr[2]);
        AttackSpeed = float.Parse(arr[3]);
        Damage = float.Parse(arr[4]);
        BulletID = int.Parse(arr[5]);
        AddXiao = int.Parse(arr[6]);
        Path = arr[7];
        Index = int.Parse(arr[8]);
    }
}
