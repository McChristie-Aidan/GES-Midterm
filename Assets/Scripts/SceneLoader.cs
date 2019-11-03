using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Prototype 2");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
