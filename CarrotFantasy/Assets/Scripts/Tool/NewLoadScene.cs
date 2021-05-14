using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewLoadScene : MonoBehaviour
{
    static string Name;
    public Slider slider;
    AsyncOperation async;
    int s;
    public static void LoadScene(string name)
    {
        Name = name;
        SceneManager.LoadScene("LoadScene");
    }


    void Start()
    {
        s = 0;
        YanShi();
        System.GC.Collect();
    }

    IEnumerator YanShi()
    {
        async = SceneManager.LoadSceneAsync(Name);
        async.allowSceneActivation = false;

        return null;
    }
    int m;
    void Update()
    {
        if (async == null)
        {
            return;
        }
        if (async.progress < 0.9f)
        {
            m = (int)(async.progress * 100);
        }
        else
        {
            m = 100;
        }
        if (s < m)
        {
            s++;
        }
        slider.value = s / 100f;
        if (s == 100)
        {
            async.allowSceneActivation = true;
        }
    }
}
