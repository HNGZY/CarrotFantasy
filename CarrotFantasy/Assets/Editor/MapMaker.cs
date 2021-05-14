using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : EditorWindow
{
    [MenuItem("Editor/地图编辑器")]
    public static void Open()
    {
        if (Application.isPlaying)
        {
            map = EditorWindow.GetWindow<MapMaker>("地图编辑器");
            EditorDataManager.Ins.Init();
            dic = EditorDataManager.Ins.getData();
        }

    }
    static MapMaker map;

    private static Dictionary<string, MapData> dic;

    string nAME = "";

    MapSet mapSet;
    private void OnGUI()
    {
        if (Application.isPlaying==false)
        {
            map.Close();
        }
        if (dic == null)
            return;

        EditorGUILayout.BeginVertical();
        foreach (var item in dic.Values)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button(item.id.ToString()))
            {
                mapSet = EditorWindow.GetWindow<MapSet>("设置地图");
                mapSet.Set(item.id);
            }
            if (GUILayout.Button("删除",GUILayout.Width(80)))
            {
                dic.Remove(item.id);
                return;
            }

            EditorGUILayout.EndHorizontal();
        }

        GUILayout.Space(30);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("地图ID");
        nAME = GUILayout.TextField(nAME);
        if (GUILayout.Button("添加",GUILayout.Width(80)))
        {
            if (nAME!="")
            {
                EditorDataManager.Ins.ADD(nAME) ;
                nAME = "";
            }
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();

    }

    private void OnDisable()
    {
        if (mapSet!=null)
        {
            mapSet.Close();
        }
        EditorDataManager.Ins.Save();
    }
}
