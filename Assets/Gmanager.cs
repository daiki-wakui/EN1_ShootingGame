using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gmanager : MonoBehaviour
{
    private GameObject[] enemy;

    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //“G‚ª‘S–Å‚µ‚½‚ç
        if (enemy.Length == 0)
        {
            panel.SetActive(true);
        }
    }
}
