using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using TMPro;

public class FishingScript : MonoBehaviour
{
    bool isFishing = false;
    public float fishingCastTime = 0.5f;
    public TMP_Text fishText;
    int fishCaught;

    // Start is called before the first frame update
    void Start()
    {
        isFishing = false;
        fishText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CastLine();
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            ReelLine();
        }
    }

    void CastLine()
    {
        transform.Rotate(0, 0, -30);
        StartCoroutine(ThrowLine(fishingCastTime));
    }

    void ReelLine()
    {
        transform.Rotate(0, 0, 30);
        isFishing = false;
        Debug.Log("false");
    }

    void Fish()
    {
        float waitTime = Random.Range(0.5f, 6.0f);
        while (isFishing)
        {
            StartCoroutine(WaitForFish(waitTime));
            break;
        }
    }

    IEnumerator ThrowLine(float secs)
    {
        yield return new WaitForSeconds(secs);
        if (Input.GetKey(KeyCode.Q))
        {
            isFishing = true;
            Debug.Log("true");
            Fish();
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            isFishing = false;
            Debug.Log("false");
        }
    }

    IEnumerator WaitForFish(float secs)
    {
        yield return new WaitForSeconds(secs);
        fishCaught = Random.Range(1, 4);
        fishText.SetText("Caught fish number " + fishCaught);
        fishText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        fishText.gameObject.SetActive(false);
    }
}
