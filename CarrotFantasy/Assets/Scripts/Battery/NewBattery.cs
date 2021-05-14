using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBattery : MonoBehaviour
{
    private BatteryDataProxy proxy;
    // Start is called before the first frame update
    private void Awake()
    {
        proxy = Facade.Instance().GetProxy<BatteryDataProxy>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetSprite(int id)
    {
        BatteryData data = proxy.GetByDic(id + 1);

        GetComponent<Image>().sprite = Facade.Instance().GetSpriteByAtlas(data.Path, data.Index);
        //0 瓶子  1 狗屎  2风扇
        GetComponent<Image>().color = new Color(1, 1, 1, 1);
        if (id == 0)
        {
            Debug.Log("放置瓶子塔");
            gameObject.AddComponent<BatteryAI_Ping>().data = Facade.Instance().GetProxy<BatteryDataProxy>().GetByDic(id+1);
        }
        else if (id == 1)
        {
            Debug.Log("放置狗屎塔");
        }
        else if (id == 2)
        {
            Debug.Log("放置风扇塔");
        }
    }
}
