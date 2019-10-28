using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10;
    public float CooldownTime = 1f;
    public GameObject projectilePrefab;
    public bool Cooldown;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        Cooldown = false;
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace) || this.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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

        if (this.health <= 0)
        {
            this.enabled = false;
        }
        if (Cooldown == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                Cooldown = true;
                Invoke("EndCooldown", CooldownTime);
            }
        }
        Debug.Log($"Health: {this.health}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Player" || other.transform.tag == null)
        {
            Debug.Log("collided with enemy");
            this.health = health - 1;
            Destroy(other.gameObject);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "Enemy")
    //    {
    //        Debug.Log("collided with enemy");
    //        this.health = health - 1;
    //        Destroy(collision.gameObject);
    //    }
    //}

    public void EndCooldown()
    {
        Cooldown = false;
    }
}
