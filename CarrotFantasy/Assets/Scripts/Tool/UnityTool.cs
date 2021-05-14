using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityTool
{
    static UnityTool ins;
    public static UnityTool Instance
    {
        get
        {
            if (ins == null)
                ins = new UnityTool();

            return ins;
        }
    }




}
