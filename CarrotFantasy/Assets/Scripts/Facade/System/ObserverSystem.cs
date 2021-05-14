using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverSystem : IGameSystem
{
    public ObserverSystem(Facade facade) : base(facade)
    {
        Initialize();
    }
    Dictionary<string, List<IObserver>> dic;
    public override void Initialize()
    {
        dic = new Dictionary<string, List<IObserver>>();
    }


    public override void Clear()
    {
        dic.Clear();
    }


    public void RegisterMessage(string key,IObserver observer)
    {
        if(!dic.ContainsKey(key))
        {
            dic.Add(key, new List<IObserver>());
        }
        dic[key].Add(observer);

    }

    public void RemoveMessage(string key,IObserver observer)
    {
        if (dic.ContainsKey(key))
        {
            List<IObserver> list = dic[key];
            foreach (var item in list)
            {
                if (item==observer)
                {
                    dic[key].Remove(item);
                    break;
                }
            }
        }
    }

    public void NotifyMessage(string key)
    {
        
        if (dic.ContainsKey(key))
        {
            List<IObserver> list = dic[key];
            foreach (var item in list)
            {
                item.DoSomething();
            }
        }

    }
}
