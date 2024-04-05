using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class FishingScript : MonoBehaviour
{
    bool isFishing;
    public float fishingCastTime = 0.5f;

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
            PullLine();
        }
    }

    void CastLine()
    {
        StartCoroutine(ThrowLine(fishingCastTime));
    }

    void PullLine()
    {
        isFishing = false;
        Debug.Log("false");
    }

    IEnumerator ThrowLine(float secs)
    {
        yield return new WaitForSeconds(secs);
        if (Input.GetKey(KeyCode.Q))
        {
            isFishing = true;
            Debug.Log("true");
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            isFishing = false;
            Debug.Log("false");
        }
    }
}
