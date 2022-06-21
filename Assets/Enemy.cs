using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        //¶¬‚É‘Ì—Í‚ğw’è‚·‚é
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //‚à‚µhp‚ª0‚É‚È‚Á‚½‚ç
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
