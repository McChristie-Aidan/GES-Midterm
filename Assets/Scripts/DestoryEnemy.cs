using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEnemy : MonoBehaviour
{
    GameObject scoreManager;
    ScoreManager score;
    AudioPlayer audio;
    BoxCollider box;
    public Renderer rend;
    private void Awake()
    {
        box = GetComponent<BoxCollider>();
        box.enabled = true;
        audio = GetComponent<AudioPlayer>();
        scoreManager = GameObject.Find("Score");
        score = scoreManager.GetComponent<ScoreManager>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Player" || other.transform.tag == null)
        {
            box.enabled = false;
            audio.PlayAudio();
            rend.enabled = false;
            Destroy(gameObject, audio.clip.length);
            Destroy(other.gameObject);
            score.score += 10;
        }
    }
}
