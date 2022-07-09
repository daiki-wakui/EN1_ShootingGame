using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject particle;
    public Gmanager gameManager;
    private int bombCount;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        bombCount = 5;
        GameObject managerObject = GameObject.Find("Gmanager1");
        gameManager = managerObject.GetComponent<Gmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            audioSource.Play();
            if (bombCount > 0)
            {
                bombCount--;
                gameManager.CountBomb();

                GameObject[] enemyBulletObjects =
                GameObject.FindGameObjectsWithTag("EnemyBullet");

                for (int i = 0; i < enemyBulletObjects.Length; i++)
                {
                    Destroy(enemyBulletObjects[i].gameObject);
                }
                Instantiate(particle, Vector3.zero, Quaternion.identity);
            }
        }
    }
}
