using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenGauge : MonoBehaviour
{
    private bool IsDash;
    private Slider GaugeUI;
    private Player Player;
    private Rigidbody PlayerRigid;
    public int MaxOxygen;                                   //酸素の最大値
    public int UseOxygen;                                   //1フレームダッシュ毎に使用する酸素使用量
    private int NowOxygen;                                   //酸素の現在値

    // Start is called before the first frame update
    void Start()
    {
        IsDash = false;
        GaugeUI = GetComponent<Slider>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        PlayerRigid = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        NowOxygen = MaxOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        //ダッシュ処理、ダッシュキー(SPACEキー)押下時
        if (Input.GetKey(KeyCode.Space))
        {
            if(NowOxygen > UseOxygen)                       //酸素の現在値が使用量より上なら
            {
                NowOxygen = NowOxygen - UseOxygen;          //酸素現在値から使用量分減らす
                GaugeUI.value = NowOxygen;                  //酸素ゲージを処理後にする
                IsDash = true;
                DushPlayer();
            }
        }
        else
        {
            NowOxygen++;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsDash = false;
        }

        Player.SetIsDash(IsDash);
        
    }

    private void DushPlayer()
    {
        Player.AddForcePlayer(Player.PlayerDashForce, ForceMode.VelocityChange, PlayerRigid.velocity.normalized);
    }
}
