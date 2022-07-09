using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Gmanager gameManager;
    private int enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        GameObject managerObject = GameObject.Find("Gmanager1");
        gameManager = managerObject.GetComponent<Gmanager>();
        //�������ɑ̗͂��w�肷��
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //����hp��0�ɂȂ�����
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
