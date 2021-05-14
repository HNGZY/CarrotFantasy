using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase
{
    public int ID;
    public virtual string[] Cut(string str)
    {
        string[] arr = str.Split(',');
        return arr;
    }

    public virtual void  SetData(string str)
    {

    }
}
