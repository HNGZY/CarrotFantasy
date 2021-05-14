using UnityEngine;
using UnityEngine.UI;
public class DiKuai : MonoBehaviour
{
    public MapItemData data;
    private void Start()
    {
        gameObject.AddComponent<Button>().onClick.AddListener(() => { EditorDataManager.Ins.Click(data); });
    }

    private void Update()
    {
        if (data.type == 0)
        {
            GetComponent<Image>().color = Color.white;
            return;
        }
        else if (data.type == 1)
        {
            GetComponent<Image>().color = Color.black;//  (0 空地  1 建筑物  2 炮台 3 路径)
        }
        else if (data.type == 2)
        {
            GetComponent<Image>().color = Color.green;
        }
        else if (data.type == 3)
        {
            GetComponent<Image>().color = Color.red;
        }
        else if (data.type==4)
        {
            GetComponent<Image>().color = Color.yellow;
        }
    }
     

}
