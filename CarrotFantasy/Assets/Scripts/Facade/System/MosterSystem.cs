using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MosterSystem : IGameSystem
{

    private Dictionary<int, Image> dic;

    public MosterSystem(Facade facade) : base(facade)
    {
        dic = new Dictionary<int, Image>();
        MessageManager.Instance.Add("添加怪物到列表", Add);
        MessageManager.Instance.Add("移除怪物列表", Remove);
    }

    private void Remove(Mess obj)
    {
        int id = (int)obj.Data[0];
        if (dic.ContainsKey(id))
        {
            GameObject.Destroy(dic[id].gameObject);
            dic.Remove(id);
        }
        if (dic.Count==0&&PlayerPrefs.GetString("是否正在创建")=="否")
        {
            m_facade.NotifyMessage("怪物全部死亡");
            Clear();

        }
    }
   public bool IsHasKey(int key)
    {
        if (dic.ContainsKey(key))
        {
            return true;
        }
        return false;
    }
    private void Add(Mess obj)
    {
        int id = (int)obj.Data[0];
        Image ima = (Image)obj.Data[1];
        dic.Add(id, ima);
    }
    public override void Clear()
    {
        dic.Clear();
    }

    public Transform Get(Vector3 pos,float juli)
    {
        foreach (var item in dic.Values)
        {
            if (Vector3.Distance(item.transform.position,pos) <= juli)
            {
                return item.transform;
            }
        }
        return null;
    }


}
