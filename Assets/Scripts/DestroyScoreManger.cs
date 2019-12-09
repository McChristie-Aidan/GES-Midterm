using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScoreManger : MonoBehaviour
{

    GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("ScoreManager");
        if(score != null)
        {
            Destroy(score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
