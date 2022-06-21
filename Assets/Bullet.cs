using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�e�̃��[���h���W���擾
        Vector3 pos = transform.position;

        //��ɔ�΂�
        pos.z += 0.05f;

        //�e�̈ړ�
        transform.position = new Vector3(pos.x, pos.y, pos.z);

        //��苗���i�񂾂���ł���
        if (pos.z >= 20)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().Damage();
        }
    }
}
