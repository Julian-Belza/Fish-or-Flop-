using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMusicSingleton : MonoBehaviour
{
    private void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("TitleScreen") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Help") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Credits") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("WinScreen"))
        {
            Destroy(this.gameObject);
        }
    }
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MenuTheme");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
