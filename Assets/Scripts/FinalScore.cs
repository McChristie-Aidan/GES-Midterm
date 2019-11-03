using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] GameObject scoreObject;
    ScoreManager scoreManager;
    Text text;

    void Start()
    {
        scoreManager = scoreObject.GetComponent<ScoreManager>();
        text = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        text.text = $"You're score is {scoreManager.score}";
    }
}
