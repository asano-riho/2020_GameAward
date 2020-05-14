using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardTracer : MonoBehaviour
{
    private GameObject PlayerObject;
    private Rigidbody Rigid;
    private bool isTracing;         //プレイヤー追跡中フラグ
    public float TraceSpeed;        //追いかける時のスピード
    public float NormalSpeed;       //通常時のスピード
    public Vector3 StartPoint;   //通常時の動きの始点
    public Vector3 EndPoint;     //通常時の動きの終点
    private bool isToEnd;           //終点に向かっているか、始点に向かっているか

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        Rigid = GetComponent<Rigidbody>();
        isTracing = false;
        isToEnd = true;
        transform.position = StartPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTracing == true)
        {
            //追跡中の動作
            Vector3 toPlayer = (PlayerObject.transform.position - transform.position).normalized;
            Rigid.velocity = toPlayer * TraceSpeed;
        }
        else
        {
            //通常時の動作
            Vector3 way = Vector3.zero;
            if (isToEnd == true)
            {
                way = (EndPoint - transform.position).normalized;
            }
            else
            {
                way = (StartPoint - transform.position).normalized;
            }

            Rigid.velocity = way * NormalSpeed;
        }

        if (isToEnd == true && transform.position == EndPoint)
        {
            //終点にたどり着いた時の処理
            transform.Rotate(Vector3.up, 180.0f, Space.World);
            isToEnd = false;
        }
        else if (isToEnd == false && transform.position == StartPoint)
        {
            //折り返して始点に再びたどり着いたとき
            transform.Rotate(Vector3.up, 180.0f, Space.World);
            isToEnd = true;
        }
    }

    public void SetIsTracing(bool isTrace)
    {
        isTracing = isTrace;
    }
}
