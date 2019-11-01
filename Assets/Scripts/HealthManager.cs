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
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        text = this.GetComponent<Text>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //disable the player if they run out of lives
        if (this.health <= 0)
        {
            player.SetActive(false);
        }
        // reloads the scene if the player dies
        // technical debt should be its own class
        if (Input.GetKeyDown(KeyCode.Backspace) || this.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        text.text = "Health: " + health;
    }
}
