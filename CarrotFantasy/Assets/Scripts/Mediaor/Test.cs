using System;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    Scrollbar scrollbar;
    public Action<int> action;
    public Transform conent;
    /// <summary>
    /// 每一步的值
    /// </summary>
    float value;
    /// <summary>
    /// 当前的位置
    /// </summary>
    int NowIndex;
    /// <summary>
    /// 总共有几个
    /// </summary>
    int count;
    /// <summary>
    /// 是否需要更新
    /// </summary>
    bool IsNeedUpdate = false;

    float MuBiao;
    private void Start()
    {
        count = conent.childCount;
        scrollbar = GetComponent<Scrollbar>();
        value = (float)(1) / (count - 1);
        scrollbar.onValueChanged.AddListener((val) =>
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (val > MuBiao)NowIndex++;
                else  NowIndex--;
                if (NowIndex < 0)NowIndex = 0;
                if (NowIndex > count - 1)NowIndex = count - 1;
                MuBiao = NowIndex * value;
                IsNeedUpdate = true;
            }
        });
    }

    private void Update()
    {
        if (IsNeedUpdate == false)
            return;

        scrollbar.value = Mathf.MoveTowards(scrollbar.value, MuBiao, Time.deltaTime * 0.5f);
        if (Mathf.Abs(value * NowIndex - scrollbar.value) < 0.003f)
        {
            IsNeedUpdate = false;
            action?.Invoke(NowIndex);
            scrollbar.value = value * NowIndex;
        }

    }

}
