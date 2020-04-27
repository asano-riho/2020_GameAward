using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{
    private int TimeCountInteger;   // 表示時間の整数部
    private int TimeCountDecimal;   // 表示時間の小数部
    private float TimeElapsed;      // 経過時間を一時保管しておくやつ
    private Text TimeView;

    // Start is called before the first frame update
    void Start()
    {
        TimeView = GetComponent<Text>();
        TimeCountInteger = 0;
        TimeCountDecimal = 0;
        TimeElapsed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        TimeElapsed += Time.deltaTime;
        if (TimeElapsed > 0.1f)
        {
            TimeCountDecimal += Mathf.FloorToInt(TimeElapsed / 0.1f);
            TimeElapsed = 0.0f;

            if (TimeCountDecimal > 9)
            {
                TimeCountInteger += 1;
                TimeCountDecimal -= 10;
            }
        }

        TimeView.text ="Time : "+ TimeCountInteger.ToString() + "." + TimeCountDecimal.ToString();
    }
}
