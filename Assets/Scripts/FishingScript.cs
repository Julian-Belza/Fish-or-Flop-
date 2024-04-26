using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    bool fishGot;
    bool fishIsCaught;
    //bool spamStop;
    //float cooldown = 0.5f;
    float time = 1.0f;
    float timer;
    public Coroutine tl;

    public AudioSource caughtFish;
    public AudioSource failFish;
    public AudioSource splash;

    // Start is called before the first frame update
    void Start()
    {
        //spamStop = true;
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
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            if (Input.GetKey(KeyCode.Q) && fishingspot.canFish && !isFishing/* && spamStop*/ && canFish)
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
        /*
        if (Input.GetKeyUp((KeyCode.Q)))
        {
            spamStop = false;
            StartCoroutine(SpamStopper(cooldown));
        }
        */
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
            fishText.SetText("Caught fish number " + fishCaught);
            caughtFish.Play();
            switch (fishCaught)
            {
                case 1:
                    fish1.SetActive(true);
                    break;
                case 2:
                    fish2.SetActive(true);
                    break;
                case 3:
                    fish3.SetActive(true);
                    break;
                default:
                    break;
            }
            totalFishCaught++;
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
            fishCaught = Random.Range(1, 4);
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
            canFish = true;
            fishIsCaught = false;
            StopAllCoroutines();
        }
    }
    /*
    IEnumerator SpamStopper(float secs)
    {
        yield return new WaitForSeconds(secs);
        spamStop = true;
    }
    */
}
