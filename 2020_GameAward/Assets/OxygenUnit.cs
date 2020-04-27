using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenUnit : MonoBehaviour
{
    private bool IsDash;                                  //現在ダッシュしているかの判別
    private List<GameObject> LeftOxygenUI;                 //残りダッシュ回数UI                                                       
    private Player Player;
    private Rigidbody PlayerRigid;
    public int MaxOxygen;                                 //最大ダッシュ回数
    private int NowOxygen;                                 //残りダッシュ回数
    public int MaxDushCount;                                //ダッシュの有効時間
    private int NowDushCount;

    // Start is called before the first frame update
    void Start()
    {
        IsDash = false;

        LeftOxygenUI = new List<GameObject>();
        GameObject unit = Resources.Load("OxygenUnit") as GameObject;
        for(int i = 0; i < MaxOxygen; i++)
        {
            LeftOxygenUI.Add(Instantiate(unit, new Vector3(i * 10, 5.0f, 0.0f), Quaternion.identity));
        }
        
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        PlayerRigid = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        NowOxygen = MaxOxygen;
        NowDushCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))                  //ダッシュキー(Enrer)押下中
        {
            if (NowOxygen > 0)                            //酸素の現在値が0より上の時
            {
                MinusOxygen();
                IsDash = true;
                DushPlayer();
            }
        }

        if (IsDash == true)
        {
            NowDushCount++;
        }
        if (NowDushCount > MaxDushCount)
        {
            IsDash = false;
            NowDushCount = 0;
        }

        Player.SetIsDash(IsDash);
    }

    private void MinusOxygen()
    {
        NowOxygen = NowOxygen - 1;                //酸素減少
        for (int i = 0; i < MaxOxygen; i++)
        {
            if (LeftOxygenUI[i].activeSelf == true)
            {
                LeftOxygenUI[i].SetActive(false);
                break;
            }
        }
    }

    private void DushPlayer()
    {
        Player.AddForcePlayer(Player.PlayerDashForce, ForceMode.VelocityChange, PlayerRigid.velocity.normalized);
    }
}