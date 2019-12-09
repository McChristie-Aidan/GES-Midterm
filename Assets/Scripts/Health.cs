using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    GameObject health;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        health = this.gameObject;
        text = health.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Health: " + ScoreManager.health;
    }
}
