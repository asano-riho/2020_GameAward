using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRubberBall : MonoBehaviour
{
    private Player PlayerObject;
    private Rigidbody PlayerRigid;
    private Rigidbody Rigid;    //このオブジェクトのRigidBody
    public float ReflectForce;
    public float Speed;         //動く速さ
    public Vector3 StartPoint;   //動きの始点
    public Vector3 EndPoint;     //動きの終点
    private bool isToEnd;           //終点に向かっているか、始点に向かっているか

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        PlayerRigid = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        Rigid = GetComponent<Rigidbody>();
        isToEnd = true;
        transform.position = StartPoint;
    }

    private void Update()
    {

        if (isToEnd == true && Vector3.Distance(transform.position, EndPoint)<1.0f)
        {
            //終点にたどり着いた時の処理
            isToEnd = false;
        }
        else if (isToEnd == false && Vector3.Distance(transform.position, StartPoint)<1.0f)
        {
            //折り返して始点に再びたどり着いたとき
            isToEnd = true;
        }


        Vector3 way = Vector3.zero;
        if (isToEnd == true)
        {
            way = (EndPoint - transform.position).normalized;
        }
        else
        {
            way = (StartPoint - transform.position).normalized;
        }

        Rigid.velocity = way * Speed;
    

        
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
