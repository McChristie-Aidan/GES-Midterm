using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    Playing,
    Invincible,
    Dead
}

public class PlayerScript : MonoBehaviour
{
    private PlayerState playerState;
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10;
    public float CooldownTime = 1f;
    public float flashSpeed;
    
    public bool Cooldown;
    public float invincibleTime;

    public GameObject projectilePrefab;
    GameObject hurtShield;
    AudioPlayer audio;
    HurtFlash hurtFlash;
    IEnumerator Flash;

    // Start is called before the first frame update
    void Start()
    {
        PlayerState playerState = PlayerState.Playing;
        audio = GetComponent<AudioPlayer>();
        hurtShield = GameObject.Find("HurtShield");
        hurtFlash = hurtShield.GetComponent<HurtFlash>();
        Cooldown = false;

        Flash = hurtFlash.Flash();
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
            if (playerState != PlayerState.Invincible)
            {
                audio.PlayAudio();
                ScoreManager.health -= 1;
                playerState = PlayerState.Invincible;
                Invoke("EndInvicibility", invincibleTime);
                hurtFlash.StartCoroutine(Flash);
            }
            Destroy(other.gameObject);
        }
    }

    //allows the player to shoot again
    public void EndCooldown()
    {
        Cooldown = false;
    }

    public void EndInvicibility()
    {
        playerState = PlayerState.Playing;
        hurtFlash.StopCoroutine(Flash);
        hurtFlash.SetColor(new Color(1f, 0f, 0f, 0f));
    }

}
