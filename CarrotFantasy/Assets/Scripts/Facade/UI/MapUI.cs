using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
public class MapUI : IUserInterface
{
    public MapUI(Facade facade) : base(facade)
    {
        Initialize();
    }
    Dictionary<int, string> dic_Path;

    private Text Money;
    private Text Bo;
    private Button Speed;
    private Button Stop;
    private Button Menu;
    private Image BG;
    private Image Route;
    private Image Cloud_Left;
    private Image Cloud_Right;
    private Transform Up;
    public override void Initialize()
    {
        m_UIRoot = UITool.Instance.GetUIObj("Map");
        Money = UITool.Instance.GetUI<Text>("Money");
        Bo = UITool.Instance.GetUI<Text>("Bo");
        Speed = UITool.Instance.GetUI<Button>("Speed");
        Stop = UITool.Instance.GetUI<Button>("Stop");
        Menu = UITool.Instance.GetUI<Button>("Menu");
        BG = UITool.Instance.GetUI<Image>("BG");
        Cloud_Left = UITool.Instance.Find<Image>(m_UIRoot.transform, "Cloud_Left");
        Cloud_Right = UITool.Instance.Find<Image>(m_UIRoot.transform, "Cloud_Right");
        Route = UITool.Instance.Find<Image>(m_UIRoot.transform, "Route");
        Up = UITool.Instance.Find<Transform>(m_UIRoot.transform, "Up");
        dic_Path = new Dictionary<int, string>();
        dic_Path[0]= "Prefab/white";
        dic_Path[1]= "Prefab/black";
        dic_Path[2]= "Prefab/green";
        dic_Path[3]= "Prefab/red";
        dic_Path[4]= "Prefab/yellow";
    }

    public override void Release()
    {
        dic_Path.Clear();
        Money = null;
        Bo = null;
        Speed = null;
        Stop = null;
        Menu = null;
        BG = null;
        Cloud_Left = null;
        Cloud_Right = null;
        Route = null;
        Up = null;
    }

    public Image  CreateGuai(string path,List<int> ids,int id,Action<int> action,Action eat,MosterData data)
    {
        Image ima = GameObject.Instantiate(Resources.Load<Image>(path), Up, false);
        ima.transform.position = BG.transform.GetChild(id).position;
        Move move = ima.gameObject.AddComponent<Move>();
        move.SetData(id, ids, BG.transform, action,eat,data.Hp,data.Speed);
        return ima;
    }
    public void SetDiTu(MapData data)
    {
            foreach (var item in data.dic.Values)
            {
                Image image;
                Debug.Log(item.type);
                string path = dic_Path[item.type];
                image = GameObject.Instantiate(Resources.Load<Image>(path), BG.transform, false);
                newKuai kuai = image.GetComponent<newKuai>();
                kuai.Info = item;
            }
    }
    public void SetGuaiStart(int  index)
    {
        Image image = GameObject.Instantiate(Resources.Load<Image>("Prefab/GuaiStart"),Up,false);
        image.transform.position = BG.transform.GetChild(index).position;
        //image.rectTransform.localPosition = Vector3.zero;
    }
    public void SetLuoBo(int index)
    {
        Image image = GameObject.Instantiate(Resources.Load<Image>("Prefab/Luo"),Up, false);
        image.transform.position = BG.transform.GetChild(index).position;
        //image.rectTransform.localPosition = Vector3.zero;
    }
    public void SetMoney(string str)
    {
        Money.text = str;
    }
    public void SetRoute(Sprite sprite)
    {
        Route.sprite = sprite; 
    }
    public void SetCloud_Left(Sprite sprite)
    {
        Cloud_Left.sprite = sprite;
    }
    public void SetCloud_Right(Sprite sprite)
    {
        Cloud_Right.sprite = sprite;
    }
    public void SetBo(string str)
    {
        Bo.text = str;
    }
    public void SetBG(Sprite sprite)
    {
        BG.sprite = sprite;
    }


}
