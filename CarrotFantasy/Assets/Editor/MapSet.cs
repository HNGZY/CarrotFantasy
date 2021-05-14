using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapSet : EditorWindow
{
    string id;
    public void Set(string id)
    {
        this.id = id;
        EditorDataManager.Ins.CreateByData(id);
    }


    void OnGUI()
    {
        EditorGUILayout.BeginVertical();


        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("地图ID");
        GUILayout.Label(id);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("设置空地"))
        {
            EditorDataManager.Ins.State = 0;
        }
        if (GUILayout.Button("设置建筑物"))
        {
            EditorDataManager.Ins.State = 1;
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("设置炮台"))
        {

            EditorDataManager.Ins.State = 2;
        }
        if (GUILayout.Button("设置路径"))
        {
            EditorDataManager.Ins.State = 3;
            EditorDataManager.Ins.ClearPath();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("设为不可用"))
        {
            EditorDataManager.Ins.State = 4;
        }
        if (GUILayout.Button("停止设置"))
        {
            EditorDataManager.Ins.State = -1;

        }
        EditorGUILayout.EndHorizontal();







        EditorGUILayout.EndVertical();
    }

    private void OnDisable()
    {

        EditorDataManager.Ins.Clear2();
    }

}
