using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーを押したら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //弾を生成する
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }
}
