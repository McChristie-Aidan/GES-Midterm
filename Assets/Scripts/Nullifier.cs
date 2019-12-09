using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nullifier : MonoBehaviour
{
    ScoreManager score;

    // Start is called before the first frame update
    void Start()
    {
        score = (ScoreManager)FindObjectOfType(typeof(ScoreManager));
        if (score == null)
        {
            Debug.Log("that shit dont work");
        }

        score.scoreObject = null;
        score.healthObject = null;
        score.ekObject = null;
        score.gameOver = null;
        score.spawner = null;
        score.player = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
