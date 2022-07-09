using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedShot : MonoBehaviour
{
    //�v���C���[
    private GameObject player;

    //�e�̃Q�[���I�u�W�F�N�g������
    public GameObject bullet;

    //1��őł��o���e�̊Ԋu�����߂�
    public int bulletWayNum = 3;

    //�ł��o���e�̊Ԋu�𒲐�����
    public float billetWaySpace = 30;

    //�ł��o���e�̊p�x�𒲐�����
    public int bulletWayAxis = 0;

    //�ł��o���Ԋu�����߂�
    public float time = 1;

    //�ŏ��ɑł��o���܂ł̎��Ԃ����߂�
    public float delayTime = 1;

    //���݂̃^�C�}�[����
    public float nowTime = 0;

    public float ShotLine = 20;

    // Start is called before the first frame update
    void Start()
    {
        nowTime = delayTime;
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
            nowTime -= Time.deltaTime;
        }

        if (nowTime <= 0)
        {
            float bulletwaySpaceSplit = 0;

            for(int i = 0; i < bulletWayNum; i++)
            {
                CreateShotObject(
                    billetWaySpace - bulletwaySpaceSplit + bulletWayAxis - transform.localEulerAngles.y);

                bulletwaySpaceSplit += (billetWaySpace / (bulletWayNum - 1)) * 2;
            }

            nowTime = time;
        }
    }

    private void CreateShotObject(float axis)
    {
        GameObject bulletClone=
            Instantiate(bullet,transform.position,Quaternion.identity);

        var bulletObject=bulletClone.GetComponent<EnemyBullet>();

        bulletObject.SetCharacterObject(gameObject);

        bulletObject.SetForwardAxis(Quaternion.AngleAxis(axis, Vector3.up));
    }
}
