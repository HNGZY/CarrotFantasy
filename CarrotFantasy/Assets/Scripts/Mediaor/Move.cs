using System;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    int ID;
    List<int> Path;
    Transform trans;
    Action<int> action;
    float HP;
    float Speed;
    Action Eat;
    public void SetData(int id,List<int> paths,Transform trans,Action<int> action,Action Eat,float hp,float speed)
    {
        this.ID = id;
        this.Path = paths;
        this.trans = trans;
        this.action = action;
        this.HP = hp;
        this.Speed = speed;
        this.Eat = Eat;
    }
    int index = 0;
    Vector3 mubiao;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = trans.GetChild(Path[0]).position;
        SetMoBiao();
    }
    /// <summary>
    /// 设置目标
    /// </summary>
    void SetMoBiao()
    {
        index++;
        if (index>=Path.Count)
        {
            action?.Invoke(ID);
            Eat?.Invoke();
            return;
        }
        mubiao = trans.GetChild(Path[index]).position;


    }
    /// <summary>
    /// 挨打
    /// </summary>
    /// <param name="id"></param>
    public void Beating(float harm)
    {

        HP -= harm;
        if (HP<=0)
        {
            action?.Invoke(ID);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,mubiao)>=0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, mubiao, Time.deltaTime * Speed*150);
        }
        else
        {
            SetMoBiao();
        }
    }
}
