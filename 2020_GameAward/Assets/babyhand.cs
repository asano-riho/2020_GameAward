using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babyhand : MonoBehaviour
{

    public Vector3 handpos;//手の位置
    public float startposY;//手のyのスタート位置
    private float move;//動く量
    public float movemax;//動くMAX量
    public GameObject babyhandobj;//手オブジェクト
    private bool babyhandflg;//当たってるかあたってないか
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        handpos = new Vector3(this.transform.position.x, this.transform.position.y+startposY, this.transform.position.z);
        babyhandflg = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (!babyhandflg) {
            // プレハブからインスタンスを生成
            obj = (GameObject)Instantiate(babyhandobj, handpos, Quaternion.identity);
            // 作成したオブジェクトを子として登録
            obj.transform.parent = this.transform;
            babyhandflg = true;
        }

        if (move<movemax)
        {
            move+=0.1f;
        }
        obj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + startposY-move, this.transform.position.z);
    }
}
