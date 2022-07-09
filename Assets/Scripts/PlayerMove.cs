using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    private int playerHp;
    private int playerBomb;
    //public GameObject gameOverText;
    //public GameObject retryBotton;

    // Start is called before the first frame update
    void Start()
    {
        playerHp = 5;
        playerBomb = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //もしhpが0になったら
        if (playerHp <= 0)
        {
            Destroy(this.gameObject);
        }

        //プレイヤーのワールド座標を取得
        Vector3 pos = transform.position;

        //右キーで右方向に移動
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += 0.2f;
        }

        //左キーで左方向に移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= 0.2f;
        }

        //上キーで上方向に移動
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.z += 0.2f;
        }

        //下キーで下方向に移動
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.z -= 0.2f;
        }

        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    public void pDamage()
    {
        playerHp--;
    }

    public void pBomb()
    {
        playerBomb--;
    }
}
