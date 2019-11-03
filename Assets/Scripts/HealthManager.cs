using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    Text text;
    public int health;
    int maxHealth = 3;
    GameObject player;

    //technical debt this should be somewhere else
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject spawner;
    SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        text = this.GetComponent<Text>();
        player = GameObject.Find("Player");
        spawnManager = spawner.GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {        
        text.text = "Health: " + health;
        CheckForDeath();
    }

    // technical debt should be its own class
    public void CheckForDeath()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || this.health <= 0)
        {
            player.SetActive(false);
            gameOver.SetActive(true);
            spawnManager.CancelInvoke();
            spawner.SetActive(false);
        }
    }
}
