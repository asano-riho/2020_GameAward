using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchLight : MonoBehaviour
{
    private GameObject PlayerObject;
    private ForwardTracer Tracer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        Tracer = transform.parent.parent.GetComponent<ForwardTracer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerObject)
        {
            //本体がプレイヤーを追いかける
            Tracer.SetIsTracing(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerObject)
        {
            //追跡をやめる
            Tracer.SetIsTracing(false);
        }
    }
}
