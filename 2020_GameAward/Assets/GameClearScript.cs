using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetEnable(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnable(bool isEnabled)
    {
        GetComponent<Canvas>().enabled = isEnabled;
    }
}
