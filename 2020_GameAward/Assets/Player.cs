using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody PlayerRigid;

    public float PlayerDashForce;   //ダッシュ時に加えるちから
    public float PlayerUpDownForce; //上下時に加えるちから

    private bool EnableUpDown;  //プレイヤーが動けるかどうか
    private int BanUpDownCount; 
    public int BanUpDownCountMax;//プレイヤーが動けるようになるまでの時間

    private bool IsDash;

    private StreamLine StreamLine;


    void Start()
    {
        PlayerRigid = GetComponent<Rigidbody>();

        EnableUpDown = true;
        BanUpDownCount = 0;

        IsDash = false;

        StreamLine = GameObject.Find("StreamLine").GetComponent<StreamLine>();

        transform.position = StreamLine.gameObject.transform.GetChild(0).transform.position;
    }

    void Update()
    {
        if (EnableUpDown)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                AddForcePlayer(PlayerUpDownForce, ForceMode.Acceleration, Vector3.up);
                if (IsDash == false)
                {
                    NormalizePlayerVelocity();
                }
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                AddForcePlayer(PlayerUpDownForce, ForceMode.Acceleration, Vector3.down);
                if (IsDash == false)
                {
                    NormalizePlayerVelocity();
                }
            }
        }
        else
        {
            BanUpDownCount++;
            if (BanUpDownCount > BanUpDownCountMax)
            {
                SetEnableUpDown(true);
                
            }
        }

    }


    public void AddForcePlayer(float force, ForceMode forcemode, Vector3 forcedirection)
    {
        forcedirection *= force;
        PlayerRigid.AddForce(forcedirection, forcemode);
        
    }   


    public void SetEnableUpDown(bool isenable)
    {
        EnableUpDown = isenable;
        BanUpDownCount = 0;
    }

    public void SetIsDash(bool dash)
    {
        IsDash = dash;
    }

    public void NormalizePlayerVelocity()
    {
        float mag = StreamLine.GetNowStreamSpeed() / PlayerRigid.velocity.magnitude;
        PlayerRigid.velocity *= mag;
    }
}