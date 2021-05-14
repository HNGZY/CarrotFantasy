using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    SceneStateController m_SceneStateController = new SceneStateController();
    private void Awake()
    {
        Debug.Log("游戏启动");
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        NewInvoke.Instance.Init();
        m_SceneStateController.SetState<StartState>();
    }

    // Update is called once per frame
    void Update()
    {
        NewInvoke.Instance.Update();
        m_SceneStateController.StateUpdate();

    }
}
