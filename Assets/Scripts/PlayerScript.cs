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

    GameObject healthManager;
    HealthManager health;
    AudioPlayer audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioPlayer>();
        healthManager = GameObject.Find("Health");
        health = healthManager.GetComponent<HealthManager>();
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

   
        //Fires a projectile if the player is off Cooldown
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

    private void OnTriggerEnter(Collider other)
    {
        //if player collides with an enemy the take damage.
        if (other.transform.tag != "Player" || other.transform.tag == null)
        {
            //debug player collision
            //Debug.Log("collided with enemy");
            audio.PlayAudio();
            health.health -= 1;
            Destroy(other.gameObject);
        }
    }

    //allows the player to shoot again
    public void EndCooldown()
    {
        Cooldown = false;
    }
}
