using System.Collections.Generic;
using System;

public class MessageManager
{

    static MessageManager ins;
    public static MessageManager Instance
    {
        get
        {
            if (ins==null)
            {
                ins = new MessageManager();
            }
            return ins;
        }
    }

    private Dictionary<string, Action<Mess>> dic = new Dictionary<string, Action<Mess>>();

    public void Add(string str, Action<Mess> action)
    {
        dic[str] = action;
    }
    public void Remove(string str,Action action)
    {
        if (dic.ContainsKey(str))
        {
            dic.Remove(str);
        }
    }
    public void Send(string str,Mess data)
    {
        if (dic.ContainsKey(str))
        {
            dic[str]?.Invoke(data);
        }
    }
    public void Clear()
    {
        dic.Clear();
    }

}

public class Mess
{
    private object[] data;

    public Mess(params object[] data)
    {
        this.data = data;
    }

    public object[] Data { get => data; }




}
