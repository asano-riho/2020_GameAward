using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    private Rigidbody Rigid;


    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {            
            GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().AddScore(100);
            GameObject.FindGameObjectWithTag("SESource").GetComponent<SESource>().PlayCoinSE();
            StartCoroutine(RotateCoin());
        }
    }

    IEnumerator RotateCoin()
    {
        for(int i = 0; i < 60; i++)
        {
            transform.Rotate(Vector3.up * 4.0f);
            yield return null;
        }
        Destroy(gameObject);
    }
}
