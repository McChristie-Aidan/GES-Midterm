using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemyBehavior : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    Vector3 currentLocation;
    // Update is called once per frame
    void Update()
    {
        
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
