using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEnemy : MonoBehaviour
{
    //technical debt i should put this somewhere else its just faster to do it here.
    AudioPlayer audio;
    BoxCollider box;
    public Renderer rend;
    private void Awake()
    {
        box = GetComponent<BoxCollider>();
        box.enabled = true;
        audio = GetComponent<AudioPlayer>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Player" || other.transform.tag == null)
        {
            if (other.transform.tag == "Speeder" || other.transform.tag == "UFO" || other.transform.tag == "Rocket")
            {
                ScoreManager.enemiesKilled += 1;
                ScoreManager.score += 10;
            }
            if (other.transform.tag == "Enemy")
            {
                ScoreManager.score += 5;
            }

            box.enabled = false;
            audio.PlayAudio();
            rend.enabled = false;
            Destroy(gameObject, audio.clip.length);
            Destroy(other.gameObject);
        }
    }
}
