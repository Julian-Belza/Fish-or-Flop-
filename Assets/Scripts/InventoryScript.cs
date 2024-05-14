using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InventoryScript : MonoBehaviour
{
    public TMP_Text fish1Txt;
    public TMP_Text fish2Txt;
    public TMP_Text fish3Txt;
    public TMP_Text fish4Txt;
    public TMP_Text fish5Txt;
    public TMP_Text fish6Txt;
    public TMP_Text fish7Txt;
    public TMP_Text fish8Txt;
    public FishingScript fishScript;

    // Update is called once per frame
    void Update()
    {
        if (fishScript.fishCount1 <= 0)
        {
            fish1Txt.gameObject.SetActive(false);
        }
        else
        {
            fish1Txt.gameObject.SetActive(true);
            fish1Txt.SetText("Goldfish: " + fishScript.fishCount1);
        }

        if (fishScript.fishCount2 <= 0)
        {
            fish2Txt.gameObject.SetActive(false);
        }
        else
        {
            fish2Txt.gameObject.SetActive(true);
            fish2Txt.SetText("Eel: " + fishScript.fishCount2);
        }

        if (fishScript.fishCount3 <= 0)
        {
            fish3Txt.gameObject.SetActive(false);
        }
        else
        {
            fish3Txt.gameObject.SetActive(true);
            fish3Txt.SetText("Wood Fish: " + fishScript.fishCount3);
        }

        if (fishScript.fishCount4 <= 0)
        {
            fish4Txt.gameObject.SetActive(false);
        }
        else
        {
            fish4Txt.gameObject.SetActive(true);
            fish4Txt.SetText("Boots: " + fishScript.fishCount4);
        }

        if (fishScript.fishCount5 <= 0)
        {
            fish5Txt.gameObject.SetActive(false);
        }
        else
        {
            fish5Txt.gameObject.SetActive(true);
            fish5Txt.SetText("Starfish: " + fishScript.fishCount5);
        }

        if (fishScript.fishCount6 <= 0)
        {
            fish6Txt.gameObject.SetActive(false);
        }
        else
        {
            fish6Txt.gameObject.SetActive(true);
            fish6Txt.SetText("Blue Tangs: " + fishScript.fishCount6);
        }

        if (fishScript.fishCount7 <= 0)
        {
            fish7Txt.gameObject.SetActive(false);
        }
        else
        {
            fish7Txt.gameObject.SetActive(true);
            fish7Txt.SetText("Urchins: " + fishScript.fishCount7);
        }

        if (fishScript.fishCount8 <= 0)
        {
            fish8Txt.gameObject.SetActive(false);
        }
        else
        {
            fish8Txt.gameObject.SetActive(true);
            fish8Txt.SetText("Treasure Chests: " + fishScript.fishCount8);
        }
    }
}
