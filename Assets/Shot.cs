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
        //�X�y�[�X�L�[����������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�e�𐶐�����
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }
}
