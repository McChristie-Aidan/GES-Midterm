using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEnemy : MonoBehaviour
{
    GameObject scoreManager;
    ScoreManager score;
    private void Awake()
    {
        scoreManager = GameObject.Find("Score");
        score = scoreManager.GetComponent<ScoreManager>();
    }
    public void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            score.score += 10;
        }
    }
}
