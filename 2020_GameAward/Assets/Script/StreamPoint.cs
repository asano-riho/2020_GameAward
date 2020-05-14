using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamPoint : MonoBehaviour
{
    public float Speed;
    private bool IsPassed;
    private Player PlayerObject;
    private Collider PlayerCollider;

    public bool GetIsPassed()
    {
        return IsPassed;
    }

    private void OnEnable()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        IsPassed = false;
        PlayerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        PlayerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == PlayerCollider)
        {
            IsPassed = true;
        }
    }

}
