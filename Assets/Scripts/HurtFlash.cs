using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtFlash : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color hurtColor;
    public float flashTime;
    Color color;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        this.meshRenderer.material.color = new Color(1.0f, 0f, 0f, 0f);
        //Color color = meshRenderer.material.color;
        //color.a = 0;
        //meshRenderer.material.color = color;
    }

    public void SetColor(Color color)
    {
        this.meshRenderer.material.color = color;
    }

    public IEnumerator Flash()
    {
        for (; ; )
        {
            this.meshRenderer.material.color = new Color(1f, 0f, 0f, 0f);

            yield return new WaitForSeconds(flashTime);

            this.meshRenderer.material.color = new Color(1f, 0f, 0f, 1f);

            yield return new WaitForSeconds(flashTime);
        }
    }
}
