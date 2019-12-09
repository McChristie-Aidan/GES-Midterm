using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] public int whichLevelToLoad;
    [SerializeField] public int enemiesKilledRequirement;

    public void LoadLevelAfterKills (int targetLevel, int targetKills)
    {
        if (ScoreManager.enemiesKilled >= targetKills)
        {
            switch (targetLevel)
            {
                case 1:
                    LoadLevel1();
                    break;
                case 2:
                    LoadLevel2();
                    break;
                case 3:
                    LoadLevel3();
                    break;
                default:
                    LoadLevel1();
                    break;
            }
        }
    }

    public void Update()
    {
        LoadLevelAfterKills(whichLevelToLoad, enemiesKilledRequirement);
    }

    public void LoadLevel1()
    {
        ScoreManager.health = 3;
        ScoreManager.enemiesKilled = 0;
        ScoreManager.score = 0;
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        ScoreManager.health = 3;
        ScoreManager.enemiesKilled = 0;
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        ScoreManager.health = 3;
        ScoreManager.enemiesKilled = 0;
        SceneManager.LoadScene("Level3");
    }

    public void LoadMenuScene()
    {
        ScoreManager.health = 3;
        ScoreManager.enemiesKilled = 0;
        ScoreManager.score = 0;
        SceneManager.LoadScene("Menu");
    }
}
