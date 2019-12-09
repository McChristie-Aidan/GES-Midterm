using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesKilled : MonoBehaviour
{
    GameObject ek;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        ek = this.gameObject;
        text = ek.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Enemies Killed: " + ScoreManager.enemiesKilled;
    }
}
