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
    GameObject healthManager;
    HealthManager health;
    AudioPlayer audio;
    MeshRenderer[] meshRenderers;
    
    Color hurtColor;
    List<Color> normalColors;

    // Start is called before the first frame update
    void Start()
    {
        PlayerState playerState = PlayerState.Playing;
        audio = GetComponent<AudioPlayer>();
        healthManager = GameObject.Find("Health");
        health = healthManager.GetComponent<HealthManager>();
        Cooldown = false;
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        normalColors = new List<Color>();

        hurtColor = Color.red;
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            for (int j = 0; j < meshRenderers[i].materials.Length; j++)
            {
                normalColors.Add(meshRenderers[i].materials[j].color);
            }
        }
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

    //technical debt should probably be in its own class
    private IEnumerable HurtFlash()
    {
        for (;;)
        {
            for(int i = 0; i < meshRenderers.Length; i++)
            {
                for (int j = 0; j < meshRenderers[i].materials.Length; j++)
                {
                    meshRenderers[i].materials[j].color = hurtColor;
                }
            }
            
            yield return new WaitForSeconds(flashSpeed);

            for (int i = 0; i < meshRenderers.Length; i++)
            {
                for (int j = 0; j < meshRenderers[i].materials.Length; j++)
                {
                    meshRenderers[i].materials[j].color = normalColors[j];
                }
            }

            yield return new WaitForSeconds(flashSpeed);
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
                health.health -= 1;
                playerState = PlayerState.Invincible;
                Invoke("EndInvicibility", invincibleTime);
                StartCoroutine("HurtFlash");
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
        StopCoroutine("HurtFlash");
    }

}
