using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    static private int ScoreCount;
    private Text ScoreView;
    // Start is called before the first frame update
    void Start()
    {
        ScoreCount = 0;
        ScoreView = GetComponent<Text>();
        ScoreView.text= "Score : " + ScoreCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int add)
    {
        ScoreCount += add;
        ScoreView.text = "Score : "+ ScoreCount.ToString();
    }
}
