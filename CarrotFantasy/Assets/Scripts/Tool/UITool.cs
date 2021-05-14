using UnityEngine;
public class UITool
{
    static UITool instance;
    Transform canvas;
    public static UITool Instance
    {
        get
        {
            if (instance == null)
                instance = new UITool();

            return instance;
        }
    }

    /// <summary>
    /// 通过类型和名字找UI组件
    /// </summary>
    /// <typeparam name="T">要找的UI组件的类型</typeparam>
    /// <param name="Name">要找的UI组件的名字</param>
    /// <returns>查找的结果</returns>
    public T GetUI<T>(string Name) where T : Component
    {
        T[] list = GameObject.FindObjectsOfType<T>();
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i].name == Name)
            {
                return list[i];
            }
        }
        Debug.LogError($"没有找到名为{Name}的{typeof(T)}");
        return null;
    }

    /// <summary>
    /// 在传入的位置下找对应名字的组件
    /// </summary>
    /// <typeparam name="T">要返回的类型</typeparam>
    /// <param name="parent">从此节点下找</param>
    /// <param name="Name">要找的物体的名称</param>
    /// <returns></returns>
    public T Find<T>(Transform parent,string Name,bool bo=false) where T:Component
    {
        T result = null;
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.name == Name)
            {
                result = parent.GetChild(i).GetComponent<T>();
                break;
            }
            if (child.childCount>0)
            {
                T obj = Find<T>(child, Name,true);
                if (obj!=null)
                {
                    result = obj;
                    break;
                }
            }
        }

        if (bo==false&& result ==null)
            Debug.LogError($"没有找到名字为{Name}的{typeof(T)}");

        return result;
        

    }
    /// <summary>
    /// 找父级为Canvas的面板
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    public GameObject GetUIObj(string Name)
    {
        if (GetCanvas() == false)
            return null;
        for (int i = 0; i < canvas.childCount; i++)
        {
            if (canvas.GetChild(i).name==Name)
            {
                return canvas.GetChild(i).gameObject;
            }
        }
        Debug.LogError($"没有找到{Name}这个面板!");
        return null;

    }

    /// <summary>
    /// 获取Canvas
    /// </summary>
    /// <returns></returns>
    private bool GetCanvas()
    {
        canvas = GameObject.FindObjectOfType<Canvas>().transform;
        if (canvas == null)
        {
            Debug.LogError("没有找到Canvas！");
            return false;
        }
        return true;
    }

}
