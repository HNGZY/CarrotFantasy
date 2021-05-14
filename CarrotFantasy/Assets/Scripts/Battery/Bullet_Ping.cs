using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Ping : MonoBehaviour
{

    public Transform target;//子弹的目标
    public float harm;//子弹的伤害
    public int type;//子弹附加的效果

    private void Start()
    {
        transform.localPosition = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        if (target==null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 10);
       
        if (Vector3.Distance(transform.position,target.position)<10)
        {
            target.GetComponent<Move>().Beating(harm);
            Destroy(gameObject);
        }
    }
}
