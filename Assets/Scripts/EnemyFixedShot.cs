using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;

    //弾のゲームオブジェクトを入れる
    public GameObject bullet;

    //1回で打ち出す弾の間隔を決める
    public int bulletWayNum = 3;

    //打ち出す弾の間隔を調整する
    public float billetWaySpace = 30;

    //打ち出す弾の角度を調整する
    public int bulletWayAxis = 0;

    //打ち出す間隔を決める
    public float time = 1;

    //最初に打ち出すまでの時間を決める
    public float delayTime = 1;

    //現在のタイマー時間
    public float nowTime = 0;

    public float ShotLine = 20;

    // Start is called before the first frame update
    void Start()
    {
        nowTime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (transform.position.z < ShotLine)
        {
            //タイマーを減らす
            nowTime -= Time.deltaTime;
        }

        if (nowTime <= 0)
        {
            float bulletwaySpaceSplit = 0;

            for(int i = 0; i < bulletWayNum; i++)
            {
                CreateShotObject(
                    billetWaySpace - bulletwaySpaceSplit + bulletWayAxis - transform.localEulerAngles.y);

                bulletwaySpaceSplit += (billetWaySpace / (bulletWayNum - 1)) * 2;
            }

            nowTime = time;
        }
    }

    private void CreateShotObject(float axis)
    {
        GameObject bulletClone=
            Instantiate(bullet,transform.position,Quaternion.identity);

        var bulletObject=bulletClone.GetComponent<EnemyBullet>();

        bulletObject.SetCharacterObject(gameObject);

        bulletObject.SetForwardAxis(Quaternion.AngleAxis(axis, Vector3.up));
    }
}
