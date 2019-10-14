using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10;
    public float CooldownTime = 1f;
    public GameObject projectilePrefab;
    public bool Cooldown;

    // Start is called before the first frame update
    void Start()
    {
        Cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        // keep player in the midle
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //move player via input
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //debug movement
        //if(horizontalInput > 0)
        //{
        //    Debug.Log("Player is moving right");
        //}
        //if(horizontalInput < 0)
        //{
        //    Debug.Log("Player is moving left");
        //}
        if (Cooldown == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                Cooldown = true;
                Invoke("EndCooldown", CooldownTime);
            }
        }
    }
    public void EndCooldown()
    {
        Cooldown = false;
    }
}
