using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gmanager : MonoBehaviour
{
    private GameObject[] enemy;
    private GameObject[] bossEnemy;

    public GameObject panel;
    public GameObject panel2;
    public GameObject panelOver;
    public GameObject panelRetry;

    private int PlayerHpCount;
    private int bombCount;
    private int scoreCount;
    public Text textComponet;
    public Text textBomb;
    public Text textScore;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        Application.targetFrameRate = 60;
        PlayerHpCount = 5;
        bombCount = 5;
        scoreCount = 0;
        panel.SetActive(false);
        panel2.SetActive(false);
        panelOver.SetActive(false);
        panelRetry.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        bossEnemy = GameObject.FindGameObjectsWithTag("BossEnemy");

        //“G‚ª‘S–Å‚µ‚½‚ç
        if (enemy.Length == 0 && bossEnemy.Length == 0) 
        {
            panel.SetActive(true);
            panel2.SetActive(true);
        }

        if (PlayerHpCount <= 0) 
        {
            panelOver.SetActive(true);
            panelRetry.SetActive(true);

            if(enemy.Length == 0 && bossEnemy.Length == 0)
            {
                panelOver.SetActive(false);
                panelRetry.SetActive(false);
            }
        }
    }
    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void CountHp()
    {
        audioSource.Play();
        PlayerHpCount--;
        Debug.Log("HP :" + PlayerHpCount.ToString());
        textComponet.text = "HP : " + PlayerHpCount.ToString();
    }

    public void CountBomb()
    {
        bombCount--;
        Debug.Log("Bomb :" + bombCount.ToString());
        textBomb.text = "Bomb : " + bombCount.ToString();
    }

    public void CountScore()
    {
        scoreCount += 300;
        Debug.Log("Score :" + scoreCount.ToString());
        textScore.text = "Score : " + scoreCount.ToString();
    }
}
