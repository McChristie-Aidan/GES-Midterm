using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    GameObject gameOver;
    GameObject deathScreen;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = this.gameObject;
        deathScreen = GameObject.Find("DeathScreen");
        deathScreen.SetActive(false);
    }

    public void Update()
    {
        if (ScoreManager.health <= 0 || Input.GetKeyDown(KeyCode.Backspace))
        {
            deathScreen.SetActive(true);
        }
    }
}
