using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.HighDefinition;
using TMPro;
using Unity.VisualScripting;

public class FishingScript : MonoBehaviour
{
    bool isFishing;
    public float fishingCastTime = 0.5f;
    public TMP_Text fishText;
    int fishCaught;
    public PickUpRod pickuprod;
    public FishingSpotScript fishingspot;
    public bool canFish;
    public int totalFishCaught;
    public TMP_Text fishCaughtText;
    public GameObject fish1;
    public GameObject fish2;
    public GameObject fish3;
    public GameObject flop;

    bool fishGot;
    bool fishIsCaught;
    float time = 1.0f;
    float timer;
    public Coroutine tl;

    public AudioSource caughtFish;
    public AudioSource failFish;
    public AudioSource splash;

    int currentLevel;
    string sceneName;
    Scene currentScene;

    public int fishCount1;
    public int fishCount2;
    public int fishCount3;
    public int fishCount4;
    public int fishCount5;
    public int fishCount6;
    public int fishCount7;
    public int fishCount8;

    // Start is called before the first frame update
    void Start()
    {
        isFishing = false;
        fishText.gameObject.SetActive(false);
        fishCaught = 0;
        isFishing = false;
        totalFishCaught = 0;
        fishCaughtText.SetText("Fish caught: " + totalFishCaught);
        fishGot = false;
        timer = Time.time;
        tl = StartCoroutine(ThrowLine(fishingCastTime));
        canFish = true;
        fishIsCaught = false;

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        fishCount1 = 0;
        fishCount2 = 0;
        fishCount3 = 0;
        fishCount4 = 0;
        fishCount5 = 0;
        fishCount6 = 0;
        fishCount7 = 0;
        fishCount8 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            if (Input.GetKey(KeyCode.Q) && fishingspot.canFish && !isFishing && canFish)
            {
                CastLine();
            }
        }
        if (Input.GetKeyUp(KeyCode.Q) && isFishing)
        {
            isFishing = false;
            timer = 0;
            ReelLine();
        }
    }

    void CastLine()
    {
        transform.Rotate(0, 0, -30);
        isFishing = true;
        StartCoroutine(ThrowLine(fishingCastTime));
    }

    void ReelLine()
    {
        StopCoroutine(tl);
        if (fishGot)
        {
            fishIsCaught = true;
            if (sceneName == "Level1" || sceneName == "Level2")
            {
                switch (fishCaught)
                {
                    case 1:
                        caughtFish.Play();
                        fish1.SetActive(true);
                        fishText.SetText("You caught a gold fish!");
                        fishCount1++;
                        totalFishCaught++;
                        break;
                    case 2:
                        caughtFish.Play();
                        fish2.SetActive(true);
                        fishText.SetText("You caught an eel!");
                        fishCount2++;
                        totalFishCaught++;
                        break;
                    case 3:
                        caughtFish.Play();
                        fish3.SetActive(true);
                        fishText.SetText("You caught a wooden fish!");
                        fishCount3++;
                        totalFishCaught++;
                        break;
                    case 4:
                        failFish.Play();
                        flop.SetActive(true);
                        fishText.SetText("You caught a boot...");
                        fishCount4++;
                        break;
                    default:
                        break;
                }
            }
            else if (sceneName == "Level3")
            {
                switch (fishCaught)
                {
                    case 1:
                        caughtFish.Play();
                        fish1.SetActive(true);
                        fishText.SetText("You caught a starfish!");
                        fishCount5++;
                        totalFishCaught++;
                        break;
                    case 2:
                        caughtFish.Play();
                        fish2.SetActive(true);
                        fishText.SetText("You caught a blue tang!");
                        fishCount6++;
                        totalFishCaught++;
                        break;
                    case 3:
                        caughtFish.Play();
                        fish3.SetActive(true);
                        fishText.SetText("You caught a sea urchin!");
                        fishCount7++;
                        totalFishCaught++;
                        break;
                    case 4:
                        caughtFish.Play();
                        flop.SetActive(true);
                        fishText.SetText("You caught a treasure chest??");
                        fishCount8++;
                        break;
                    default:
                        break;
                }
            }
            fishCaughtText.SetText("Fish caught: " + totalFishCaught);
        }
        splash.Stop();
        transform.Rotate(0, 0, 30);
    }

    void Fish()
    {
        float waitTime = Random.Range(0.5f, 4.0f);
        StartCoroutine(WaitForFish(waitTime));
    }

    
    IEnumerator ThrowLine(float secs)
    {
        yield return new WaitForSeconds(secs);
        if (isFishing)
        {
            Fish();
        }
    }
    

    IEnumerator WaitForFish(float secs)
    {
        yield return new WaitForSeconds(secs);
        if (isFishing)
        {
            canFish = false;
            fishCaught = Random.Range(1, 5);
            fishGot = true;
            float caughtTime = Random.Range(0.5f, 3.0f);
            fishText.SetText("Something's got the line!");
            splash.Play();
            fishText.gameObject.SetActive(true);
            yield return new WaitForSeconds(caughtTime);
            if (Input.GetKey(KeyCode.Q) && !fishIsCaught)
            {
                fishText.SetText("You lost the fish..");
                splash.Stop();
                failFish.Play();
            }
            fishGot = false;
            yield return new WaitForSeconds(1f);
            fishText.gameObject.SetActive(false);
            fish1.SetActive(false);
            fish2.SetActive(false);
            fish3.SetActive(false);
            flop.SetActive(false);
            canFish = true;
            fishIsCaught = false;
            StopAllCoroutines();
        }
    }
}
