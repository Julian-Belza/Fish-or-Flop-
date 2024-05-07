using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    public AudioSource audioSource;
    private string sceneName;
    public Animator transition;
    public float transitionTime = 1f;
    public GameObject pauseMenu;
    private bool pauseLoaded = false;



    public Button startButton;
    public Button quitButton;
    public Button creditsButton;
    public Button helpButton;
    public Button mainMenuButton;


    IEnumerator PlayAudioAndLoadScene()
    {
        // Play AudioSource
        //audioSource.Play();
        // Set trigger
        //transition.SetTrigger("Start");
        // Wait for half a second
        yield return new WaitForSeconds(transitionTime);

        // Load your scene
        Time.timeScale = 1f;
        LoadScene(sceneName);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pauseLoaded == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            LoadMainMenu();
        }
        

    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseLoaded = true;
        pauseMenu.SetActive(true);


    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseLoaded = false;
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void LoadStart()
    {
        sceneName = "Level1";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void Load2()
    {
        sceneName = "Level2";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void LoadHelp()
    {
        sceneName = "Help";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void LoadCredits()
    {
        sceneName = "Credits";
        //LoadScene(sceneName);
        StartCoroutine(PlayAudioAndLoadScene());
    }

    public void LoadMainMenu()
    {
        if (pauseMenu != null)
        {
            Time.timeScale = 1f;
            sceneName = "TitleScreen";
            //LoadScene(sceneName);
            StartCoroutine(PlayAudioAndLoadScene());
        }
        else 
        {
            sceneName = "TitleScreen";
            //LoadScene(sceneName);
            StartCoroutine(PlayAudioAndLoadScene());
        }
        
    }

    public void OnClickQuit()
    {
        Debug.Log("QuitClicked");
        Application.Quit();
    }
}

