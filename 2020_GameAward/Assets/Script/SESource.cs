using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SESource : MonoBehaviour
{
    private AudioSource Source;
    [SerializeField]
    private AudioClip Coin;
    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCoinSE()
    {
        Source.PlayOneShot(Coin);
    }
}
