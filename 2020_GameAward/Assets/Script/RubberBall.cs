using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberBall : MonoBehaviour
{
    private Player PlayerObject;
    private Rigidbody PlayerRigid;
    public float ReflectForce;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        PlayerRigid = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 reflectVec = Vector3.Reflect(PlayerRigid.velocity, collision.contacts[0].normal).normalized;
            PlayerObject.AddForcePlayer(ReflectForce, ForceMode.VelocityChange, reflectVec);
            PlayerObject.SetEnableUpDown(false);
        }
    }
}
