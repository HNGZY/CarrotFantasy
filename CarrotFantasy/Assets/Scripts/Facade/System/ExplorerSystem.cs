using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 配置管理系统
/// </summary>
public class ExplorerSystem : IGameSystem
{
    Dictionary<string, Sprite[]> dic_Atlas = new Dictionary<string, Sprite[]>();
    public ExplorerSystem(Facade facade) : base(facade)
    {
    }

    public override void Clear()
    {

    }

    public override void Initialize()
    {

    }



    /// <summary>
    /// 通过图集获取图片
    /// </summary>
    public Sprite GetSpriteByAtlas(string path, int index)
    {
        if (!dic_Atlas.ContainsKey(path))
        {
            dic_Atlas.Add(path, Resources.LoadAll<Sprite>(path));
        }
        Sprite[] arr = dic_Atlas[path];
        return arr[index];
    }

}
