using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject scoreObject;
    [SerializeField] GameObject healthObject;
    [SerializeField] GameObject ekObject;

    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject spawner;

    SpawnManager spawnManager;
    GameObject player;

    Text scoreText, healthText, ekText;

    public static int health;
    public static int score;
    public static int enemiesKilled;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        ifNull();

        health = 3;
        score = 0;
        enemiesKilled = 0;
    }
   
    // Update is called once per frame
    void Update()
    {
        ifNull();
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
        ekText.text = "Enemies killed: " + enemiesKilled;

        CheckForDeath();
    }

    public void ifNull()
    {
        if (scoreObject == null)
        {
            scoreObject = GameObject.Find("Score");
        }
        if (healthObject == null)
        {
            healthObject = GameObject.Find("Health");
        }
        if (ekObject == null)
        {
            ekObject = GameObject.Find("EnemiesKilled");
        }
        if (gameOver == null)
        {
            gameOver = GameObject.Find("GameOver");
        }
        if (spawner == null)
        {
            spawner = GameObject.Find("SpawnManager");
        }
        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        scoreText = scoreObject.GetComponent<Text>();
        healthText = healthObject.GetComponent<Text>();
        ekText = ekObject.GetComponent<Text>();

    }

    public void CheckForDeath()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || health <= 0)
        {
            player.SetActive(false);
            gameOver.SetActive(true);
            spawnManager.CancelInvoke();
            spawner.SetActive(false);
        }
    }
}
