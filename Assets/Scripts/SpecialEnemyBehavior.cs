using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    Vector3 currentLocation;
    public float min = 2f;
    public float max = 3f;
    [SerializeField] public float moveDistance;
    Random r;
    
    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + moveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.tag == "Speeder")
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * 3, max - min) + min, transform.position.y, transform.position.z);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (this.transform.tag == "UFO")
        {
            if (other.transform.tag == "Player")
            {
                Instantiate(enemyBullet, this.transform.position, this.transform.rotation);
            }
        }
    }
}
