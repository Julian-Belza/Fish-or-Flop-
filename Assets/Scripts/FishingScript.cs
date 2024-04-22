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
    bool spamStop;
    float cooldown = 0.5f;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && fishingspot.canFish && !isFishing&& spamStop)
        {
            CastLine();
        }
        if (Input.GetKeyUp(KeyCode.Q) && isFishing)
        {
            ReelLine();
        }
        if (Input.GetKeyUp((KeyCode.Q)))
        {
            spamStop = false;
            StartCoroutine(SpamStopper(cooldown));
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
        if (!fishGot)
        {
            StopAllCoroutines();
        }
        transform.Rotate(0, 0, 30);
        isFishing = false;
    }

    void Fish()
    {
        float waitTime = Random.Range(0.5f, 4.0f);
        StartCoroutine(WaitForFish(waitTime));
    }

    
    IEnumerator ThrowLine(float secs)
    {
        yield return new WaitForSeconds(secs);
        if (Input.GetKey(KeyCode.Q))
        {
            Fish();
        }
        else
        {
            isFishing = false;
        }
    }
    

    IEnumerator WaitForFish(float secs)
    {
        yield return new WaitForSeconds(secs);
        fishCaught = Random.Range(1, 4);
        fishGot = true;
        float caughtTime = Random.Range(0.5f, 3.0f);
        fishText.SetText("Something's got the line!");
        fishText.gameObject.SetActive(true);
        yield return new WaitForSeconds(caughtTime);
        if (!Input.GetKey(KeyCode.Q))
        {
            fishText.SetText("Caught fish number " + fishCaught);
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
            fishGot = false;
            yield return new WaitForSeconds(2f);
            fishText.gameObject.SetActive(false);
            fish1.SetActive(false);
            fish2.SetActive(false);
            fish3.SetActive(false);
        }
        else
        {
            fishText.SetText("You lost the fish..");
            yield return new WaitForSeconds(1f);
            fishText.gameObject.SetActive(false);
        }
        StopAllCoroutines();
    }

    IEnumerator SpamStopper(float secs)
    {
        yield return new WaitForSeconds(secs);
        spamStop = true;
    }
    
}
