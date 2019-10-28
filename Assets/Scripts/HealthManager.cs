using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    Text text;
    PlayerScript player;
    int Health;
    GameObject playerObject;
    private void Awake()
    {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<PlayerScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        Health = player.health;
    }

    // Update is called once per frame
    void Update()
    {
        Health = player.health;
        text.text = "Health: " + Health;
    }
}
