using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Gmanager gameManager;

    //弾のスピード
    public float speed = 1;

    //自然消滅までのタイマー
    public float time = 1;

    //進行方向
    protected Vector3 forward =
        new Vector3(0, 0, 1);

    //打ち出す時の角度
    protected Quaternion forwardAxis =
        Quaternion.identity;

    //Rigidbody用変数
    protected Rigidbody rb;

    //Enemy用変数
    protected GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        GameObject managerObject = GameObject.Find("Gmanager1");
        gameManager = managerObject.GetComponent<Gmanager>();


        //Rigidbody変数を初期化
        rb =this.GetComponent<Rigidbody>();

        //生成時に進行方向を決める
        if (enemy != null)
        {
            forward = enemy.transform.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //移動量を進行方向にスピード分だけ加える
        rb.velocity = forwardAxis * forward * speed;

        //空中に浮かばないようにする
        rb.velocity=new Vector3(rb.velocity.x,0,rb.velocity.z);

        //時間制限が来たら自然消滅する
        time -= Time.deltaTime;

        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerBody")
        {
            other.gameObject.GetComponent<PlayerMove>().pDamage();
            gameManager.CountHp();
            Destroy(this.gameObject);
        }
    }

    //弾を打ち出したキャラクターの情報を渡す関数
    public void SetCharacterObject(GameObject character)
    {
        //弾を打ち出したキャラクターの情報を受け取る
        this.enemy = character;
    }

    //打ち出す角度を決定するための関数
    public void SetForwardAxis(Quaternion axis)
    {
        //設定された角度を受け取る
        this.forwardAxis = axis;
    }
}