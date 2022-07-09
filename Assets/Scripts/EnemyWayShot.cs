using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayShot : MonoBehaviour
{
    //�v���C���[
    private GameObject player;

    //�e�̃Q�[���I�u�W�F�N�g������
    public GameObject bullet;

    //1��őł��o���e�̐������߂�
    public int bulletWayNum = 3;

    //�ł��o���e�̊Ԋu�𒲐�����
    public float bulletWaySpace = 30;

    //�ł��o���e�̊Ԋu
    public float time = 1;

    //�ŏ��ɑł��o���܂ł̎���
    public float delayTime = 1;

    //���݂̃^�C�}�[����
    float nowtime = 0;

    public float ShotLine = 20;

    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[������
        nowtime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (transform.position.z < ShotLine)
        {
            //�^�C�}�[�����炷
            nowtime -= Time.deltaTime;
        }

        if(nowtime <= 0)
        {
            float bulletWaySpaceSplit = 0;

            for(int i = 0; i < bulletWayNum; i++)
            {
                CreateShotObject(bulletWaySpace - bulletWaySpaceSplit + transform.localEulerAngles.y);
                bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
            }
            nowtime = time;
        }
    }

    private void CreateShotObject(float axis)
    {
        var direction = player.transform.position - transform.position;

        direction.y = 0;

        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);

        GameObject bulletClone =
            Instantiate(bullet, transform.position, Quaternion.identity);

        var bulletObject = bulletClone.GetComponent<EnemyBullet>();

        bulletObject.SetCharacterObject(gameObject);

        bulletObject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }
}
