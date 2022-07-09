using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;

    //弾のゲームオブジェクトを入れる
    public GameObject bullet;

    //1回で打ち出す弾の数を決める
    public int bulletWayNum = 3;

    //打ち出す弾の間隔を調整する
    public float bulletWaySpace = 30;

    //打ち出す弾の間隔
    public float time = 1;

    //最初に打ち出すまでの時間
    public float delayTime = 1;

    //現在のタイマー時間
    float nowtime = 0;

    public float ShotLine = 20;

    // Start is called before the first frame update
    void Start()
    {
        //タイマー初期化
        nowtime = delayTime;
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
            nowtime -= Time.deltaTime;
        }

        if(nowtime <= 0)
        {
            float bulletWaySpaceSplit = 0;

            for(int i = 0; i < bulletWayNum; i++)
            {
                CreateShotObject(bulletWaySpace - bulletWaySpaceSplit + transform.localEulerAngles.y);
                bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
            }
            nowtime = time;
        }
    }

    private void CreateShotObject(float axis)
    {
        var direction = player.transform.position - transform.position;

        direction.y = 0;

        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        GameObject bulletClone =
            Instantiate(bullet, transform.position, Quaternion.identity);

        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        bulletObject.SetCharacterObject(gameObject);

        bulletObject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }
}
