using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundEffect : MonoBehaviour
{
    private void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Level1") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Level2"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("SFX");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
