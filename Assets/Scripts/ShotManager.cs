using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    [SerializeField] GameObject ShotPrefab;
    public float shootDelay = .5f;
    public float shootRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Shoot", shootDelay, shootRate);
        Invoke("Shoot", shootDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Instantiate(ShotPrefab, transform.position, gameObject.transform.rotation);
    }
}
