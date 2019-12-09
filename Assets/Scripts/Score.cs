using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    GameObject score;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        score = this.gameObject;
        text = score.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + ScoreManager.score;
    }
}
