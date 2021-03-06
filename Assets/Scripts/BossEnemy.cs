using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public Gmanager gameManager;
    private int enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        GameObject managerObject = GameObject.Find("Gmanager1");
        gameManager = managerObject.GetComponent<Gmanager>();
        //生成時に体力を指定する
        enemyHp = 30;
    }

    // Update is called once per frame
    void Update()
    {
        //もしhpが0になったら
        if (enemyHp <= 0)
        {
            gameManager.CountScore();
            Destroy(this.gameObject);
        }
    }

    public void Damage()
    {
        enemyHp--;
    }
}
