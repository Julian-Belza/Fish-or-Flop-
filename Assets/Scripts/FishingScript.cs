using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class FishingScript : MonoBehaviour
{
    bool isFishing = false;
    public float fishingCastTime = 0.5f;
    int fishCaught;

    // Start is called before the first frame update
    void Start()
    {
        isFishing = false;
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
        StartCoroutine(ThrowLine(fishingCastTime));
    }

    void ReelLine()
    {
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
        Debug.Log("Fish Caught " + fishCaught);
    }
}
