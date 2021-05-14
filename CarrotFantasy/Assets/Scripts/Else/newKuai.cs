using System;
using UnityEngine;
using UnityEngine.UI;

public class newKuai : MonoBehaviour
{

    public MapItemData Info;
    public MapData data;
    void Awake()
    {
        gameObject.AddComponent<Button>().onClick.AddListener(()=>
        {
            if (Info.type==0)
            {
                MessageManager.Instance.Send("弹出UI选择建造炮台", new Mess(Info.id));
            }
        });

    }
    private void Update()
    {

        //获取敌人（范围内） 在mostersystem里判断
        //如果要转向就转
        //发射子弹攻击敌人
        
    }

    public void SetSprite(int id)
    {
        
    }


}
