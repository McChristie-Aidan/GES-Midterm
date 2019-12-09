using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnStart : MonoBehaviour
{
    public float fadeTime;
    IEnumerator fade;

    // Start is called before the first frame update
    void Start()
    {
        fade = Fade();
        StartCoroutine(fade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(fadeTime);
        this.gameObject.SetActive(false);
    }
}
