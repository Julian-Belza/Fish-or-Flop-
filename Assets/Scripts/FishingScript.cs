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
    public GameObject quickReelText;
    public int totalFishCaught;
    public TMP_Text fishCaughtText;

    // Start is called before the first frame update
    void Start()
    {
        isFishing = false;
        fishText.gameObject.SetActive(false);
        fishCaught = 0;
        isFishing = false;
        quickReelText.SetActive(false);
        totalFishCaught = 0;
        fishCaughtText.SetText("Fish caught: " + totalFishCaught);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && fishingspot.canFish && !isFishing)
        {
            CastLine();
        }
        if (Input.GetKeyUp(KeyCode.Q) && isFishing)
        {
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
        transform.Rotate(0, 0, 30);
        isFishing = false;
    }

    void Fish()
    {
        float waitTime = Random.Range(0.5f, 6.0f);
        StartCoroutine(WaitForFish(waitTime));
    }

    IEnumerator ThrowLine(float secs)
    {
        yield return new WaitForSeconds(secs);
        if (Input.GetKey(KeyCode.Q))
        {
            Fish();
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            isFishing = false;
            StopAllCoroutines();
        }
    }

    IEnumerator WaitForFish(float secs)
    {
        yield return new WaitForSeconds(secs);
        fishCaught = Random.Range(1, 4);
        float caughtTime = Random.Range(0.5f, 3.0f);
        fishText.SetText("Something's got the line!");
        fishText.gameObject.SetActive(true);
        yield return new WaitForSeconds(caughtTime);
        if (!Input.GetKey(KeyCode.Q))
        {
            fishText.SetText("Caught fish number " + fishCaught);
            yield return new WaitForSeconds(1f);
            fishText.gameObject.SetActive(false);
            totalFishCaught++;
            fishCaughtText.SetText("Fish caught: " + totalFishCaught);
        }
        else
        {
            fishText.SetText("You lost the fish..");
            yield return new WaitForSeconds(1f);
            fishText.gameObject.SetActive(false);
        }
    }
}
