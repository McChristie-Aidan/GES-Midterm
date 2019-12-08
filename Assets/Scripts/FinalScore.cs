using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] GameObject scoreObject;
    Text text;

    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        text.text = $"You scored {ScoreManager.score} points!";
    }
}
