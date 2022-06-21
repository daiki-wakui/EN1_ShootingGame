using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        //生成時に体力を指定する
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //もしhpが0になったら
        if (enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Damage()
    {
        enemyHp--;
    }
}
