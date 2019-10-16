using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    GameObject Player = null;
    Vector3 PlayerPosition;
    public float speed = 30f;
    Rigidbody rb;
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        //PlayerPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.x);
        //this.gameObject.transform.LookAt(PlayerPosition);
        this.gameObject.transform.LookAt(Player.transform);
        rb.AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
