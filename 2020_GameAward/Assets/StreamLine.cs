using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamLine : MonoBehaviour
{
    public float Width;
    private List<StreamPoint> StreamPoints;
    private StreamPoint NowPoint;
    private Player PlayerObject;
    private LineRenderer LineRender;
    private float NowStreamSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] positions = new Vector3[transform.childCount];
        StreamPoints = new List<StreamPoint>();
        for (int i = 0; i < transform.childCount; i++)
        {
            StreamPoints.Add(transform.GetChild(i).GetComponent<StreamPoint>());
            positions[i] = StreamPoints[i].transform.position;
        }
        PlayerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        LineRender = GetComponent<LineRenderer>();
        LineRender.positionCount = positions.Length;
        LineRender.SetPositions(positions);
        LineRender.startWidth = Width;
        LineRender.endWidth = Width;        
    }

    // Update is called once per frame
    void Update()
    {       
        
        bool isOnStream=false;//流に乗っているかどうか
        bool isGameClear = false;
        Vector3 streamVec = Vector3.zero;
       for (int i = 0; i < StreamPoints.Count; i++)
        {
            if (StreamPoints[i].GetIsPassed() == true)
            {
                if(i==StreamPoints.Count - 1)
                {
                    isGameClear = true;
                    break;
                }

                //NowPoint（現在乗っている流れ）の更新
                //順番にポイントを通過しているか調べる
                NowPoint = StreamPoints[i];                
            }
            else
            {
                //通過していないポイントがあったら更新をやめ、その直前のポイントをNowPointとする
                                    
                isOnStream = GetIsOnStream(PlayerObject.transform.position,//プレイヤーの位置
                    StreamPoints[i - 1].transform.position,//流れの始点
                    StreamPoints[i].transform.position);//流れの終点

                streamVec = (StreamPoints[i].transform.position - StreamPoints[i - 1].transform.position).normalized;

                NowStreamSpeed = NowPoint.Speed;
                
                

                break;
            }
        }

        //流に乗っていたらプレイヤーに力を加える
        if (isOnStream)
        {
            PlayerObject.AddForcePlayer(NowPoint.Speed, ForceMode.Acceleration, streamVec);
        }
        //流から外れたらゲームオーバー処理
        else
        {
            if (isGameClear == false)
            {
                GameObject.Find("GameOverCanvas").GetComponent<GameOverScript>().SetEnable(true);
            }
            else
            {
                GameObject.Find("GameClearCanvas").GetComponent<GameClearScript>().SetEnable(true);
            }
        }

    }

    //オブジェクトが流れと当たっているか
    public bool GetIsOnStream(Vector3 pos, Vector3 streamStart, Vector3 streamEnd)
    {
        Vector3 nearest = Vector3.Project(pos - streamStart, streamEnd - streamStart) + streamStart;
        float distance = Vector3.Distance(pos, nearest);

        return (distance < Width);
    }

    public float GetNowStreamSpeed()
    {
        return NowStreamSpeed;
    }

    
}
