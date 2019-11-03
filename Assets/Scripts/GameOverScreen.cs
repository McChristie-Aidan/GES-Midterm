using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);      
    }

    public void ShowGameOver()
    {
            gameOver.SetActive(true);
    }
}
