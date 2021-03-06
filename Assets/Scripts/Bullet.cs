using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioSource hitAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //弾のワールド座標を取得
        Vector3 pos = transform.position;

        //上に飛ばす
        pos.z += 0.5f;

        //弾の移動
        transform.position = new Vector3(pos.x, pos.y, pos.z);

        //一定距離進んだら消滅する
        if (pos.z >= 20)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            hitAudioSource.Play();
            other.gameObject.GetComponent<Enemy>().Damage();
        }

        if(other.gameObject.tag == "BossEnemy")
        {
            hitAudioSource.Play();
            other.gameObject.GetComponent<BossEnemy>().Damage();
        }
    }
}
