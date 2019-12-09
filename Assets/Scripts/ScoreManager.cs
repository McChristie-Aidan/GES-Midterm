using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public GameObject scoreObject;
    [SerializeField] public GameObject healthObject;
    [SerializeField] public GameObject ekObject;

    [SerializeField] public GameObject gameOver;
    [SerializeField] public GameObject spawner;

    public static ScoreManager instance;

    public SpawnManager spawnManager;
    public GameObject player;

    public Text scoreText, healthText, ekText;

    public static int health;
    public static int score;
    public static int enemiesKilled;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

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

    public void OnLevelWasLoaded(int level)
    {
        scoreObject = null;
        healthObject = null;
        ekObject = null;
        gameOver = null;
        spawner = null;
        player = null;
        scoreText = null;
        healthText = null;
        ekText = null;
    }

    // Update is called once per frame
    void Update()
    {
        ifNull();
        //if (gameOver.active == true && health > 0)
        //{
        //    gameOver.SetActive(false);
        //}

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
        if (spawnManager == null)
        {
            spawnManager = spawner.GetComponent<SpawnManager>();
        }

        //scoreObject = GameObject.Find("Score");
        //healthObject = GameObject.Find("Health");
        //ekObject = GameObject.Find("EnemiesKilled");
        //gameOver = GameObject.Find("GameOver");
        //spawner = GameObject.Find("SpawnManager");
        //player = GameObject.Find("Player");

        scoreText = scoreObject.GetComponent<Text>();
        healthText = healthObject.GetComponent<Text>();
        ekText = ekObject.GetComponent<Text>();
    }

    public void CheckForDeath()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || health <= 0)
        {
            player.SetActive(false);
            if (gameOver == null)
            {
                Debug.Log("Can't find gameOver");
            }
            gameOver.SetActive(true);
            spawnManager.CancelInvoke();
            spawner.SetActive(false);
        }
    }
}
