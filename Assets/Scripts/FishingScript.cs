using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingScript : MonoBehaviour
{
    bool isFishing;

    // Start is called before the first frame update
    void Start()
    {
        isFishing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CastLine();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            PullLine();
        }
    }

    void CastLine()
    {
        isFishing = true;
        Debug.Log("true");
    }

    void PullLine()
    {
        isFishing = false;
        Debug.Log("false");
    }
}
