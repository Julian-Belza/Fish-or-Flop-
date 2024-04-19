using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VanScript : MonoBehaviour
{
    public GameObject travelText;
    public TMP_Text fishLeftText;
    int fishCount = 0;
    public int neededFish = 10;

    // Start is called before the first frame update
    void Start()
    {
        travelText.SetActive(false);
        fishLeftText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (neededFish <= fishCount)
            {
                travelText.SetActive(true);
                if (Input.GetKey(KeyCode.X))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else
            {
                fishLeftText.SetText("Catch " + (neededFish - fishCount) + " more fish to travel");
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
