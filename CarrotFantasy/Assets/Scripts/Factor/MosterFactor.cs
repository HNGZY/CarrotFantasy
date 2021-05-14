using UnityEngine;
using UnityEngine.UI;

public class MosterFactor : IFactor
{

    
    public MosterFactor()
    {

    }

    /// <summary>
    /// 在这里生成怪物
    /// </summary>
    public override void Create(params object[] datas)
    {

        string path = datas[0].ToString();
        int id = (int)datas[1];
        Image game = GameObject.Instantiate(Resources.Load<Image>(path));



    }

}
