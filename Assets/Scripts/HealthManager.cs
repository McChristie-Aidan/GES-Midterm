using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    Text text;
    PlayerScript player;
    int Health;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerScript>();
        text = GetComponent<Text>();
        int Health = player.health;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Health: " + Health;
    }
}
