using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryAI_Ping : MonoBehaviour
{
    public BatteryData data;
    private Transform target;
    public Dictionary<int, Image> dic_Guai;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("数据是：" + data);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = Facade.Instance().GetMuBiao(transform.position, data.AttackRange);
            if (target == null)
            {
                return;
            }
        }
        transform.eulerAngles = LookTargetAngle(transform, target.position);
        timer += Time.deltaTime*data.AttackSpeed;
        if (timer>2f)
        {
            timer = 0;
            //这里创建子弹   把伤害和目标赋值给子弹 子弹打到怪物时怪物掉血


            //子弹的图片暂时为一个白方块

            Image bullet = GameObject.Instantiate(Resources.Load<Image>("Prefab/Bullet"), transform, false);
            
            Bullet_Ping ping = bullet.gameObject.AddComponent<Bullet_Ping>();
            ping.target = target;
            ping.harm = data.Damage;
            ping.type = data.AddXiao;
            //target.GetComponent<Move>().Beating(data.Damage);
        }
    }

    float timer;
    private Vector3 LookTargetAngle(Transform playerTrans, Vector3 targetPos)
    {
        float dx = targetPos.x - playerTrans.transform.position.x;
        float dy = targetPos.y - playerTrans.transform.position.y;
        float rotationZ = Mathf.Atan2(dy, dx) * 180 / Mathf.PI;
        //得到最终的角度并且确保在 [0, 360) 这个区间内
        rotationZ -= 90;
        //获取增加的角度
        float originRotationZ = playerTrans.eulerAngles.z;
        float addRotationZ = rotationZ - originRotationZ;
        //超过 180 度需要修改为负方向的角度
        if (addRotationZ > 180)
        {
            addRotationZ -= 360;
        }
        //应用旋转
        return new Vector3(0, 0, playerTrans.eulerAngles.z + addRotationZ+180);
    }

}
