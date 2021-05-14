using System.Collections.Generic;
using UnityEngine;
using System;

public class NewInvoke
{
    List<int> indexs_Now;
    MyInv[] myInvs = new MyInv[100];

    static NewInvoke ins;
    public static NewInvoke Instance
    {
        get
        {
            if (ins==null)
            {
                ins = new NewInvoke();
            }
            return ins;
        }
    }

    public void Init()
    {
        indexs_Now = new List<int>();
        for (int i = 0; i < 100; i++)
        {
            indexs_Now.Add(i);
        }

    }

    public void Add(MyInv inv)
    {
        if (indexs_Now.Count<=0)
        {
            Debug.Log("MyInvoke只支持一百个，扩容！");
            return;
        }
        //拿出来可以用的索引
        int index = indexs_Now[0];
        //把它从可以用的索引集合中移除
        indexs_Now.RemoveAt(0);

        //索引赋值给myinv
        inv.Index = index;

        myInvs[index] = inv; 




    }

    public void Update()
    {
        for (int i = 0; i < myInvs.Length; i++)
        {
            if (myInvs[i]==null)
            {
                continue;
            }
            if (myInvs[i].CiNow == 0)
            {
                myInvs[i].Start?.Invoke();
            }
            myInvs[i].NowTime += Time.deltaTime;
            if (myInvs[i].NowTime >= myInvs[i].Time)
            {
                myInvs[i].Playing?.Invoke();
                myInvs[i].NowTime = 0;
                myInvs[i].CiNow++;
                if (myInvs[i].Ci == myInvs[i].CiNow)
                {
                    myInvs[i].End?.Invoke();
                    indexs_Now.Add(myInvs[i].Index);
                    Debug.Log("置空");
                    myInvs[i] = null;
                }
            }
        }
    }
}


public class MyInv
{
    public int Index;
    public Action Start;
    public Action Playing;
    public Action End;
    public float Time;
    public float NowTime;
    public int Ci;
    public int CiNow;

    public MyInv(Action playing, float time, int ci)
    {
        Playing = playing;
        Time = time;
        Ci = ci;
        CiNow = 0;
        NowTime = 0;
    }

    public MyInv(Action start, Action playing, Action end, float time, int ci)
    {
        Start = start;
        Playing = playing;
        End = end;
        Time = time;
        Ci = ci;
        CiNow = 0;
        NowTime = 0;
    }
}
