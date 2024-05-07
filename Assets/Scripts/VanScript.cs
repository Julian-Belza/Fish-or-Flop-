using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VanScript : MonoBehaviour
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
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else
            {
                fishLeftText.SetText("Catch " + (neededFish - fishscript.totalFishCaught) + " more fish to travel");
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
