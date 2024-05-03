using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Van2 : MonoBehaviour
{
    public FishingScript fishscript;
    public GameObject travelText;
    public TMP_Text fishLeftText;
    public int neededFish = 10;

    // Start is called before the first frame update
    void Start()
    {
        travelText.SetActive(false);
        fishLeftText.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (neededFish <= fishscript.totalFishCaught)
            {
                travelText.SetActive(true);
                if (Input.GetKey(KeyCode.X))
                {
                    SceneManager.LoadScene("WinScreen");
                }
            }
            else
            {
                fishLeftText.SetText("Catch " + (neededFish - fishscript.totalFishCaught) + " more fish to return home");
                fishLeftText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        travelText.SetActive(false);
        fishLeftText.gameObject.SetActive(false);
    }
}
