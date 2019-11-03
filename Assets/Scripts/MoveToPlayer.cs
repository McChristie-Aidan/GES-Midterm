using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    GameObject Player;
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
        if (Player == null)
        {
            Destroy(this.gameObject);
        }
        
        this.gameObject.transform.LookAt(Player.transform);
        rb.AddForce(transform.forward * speed);
        
    }
}
