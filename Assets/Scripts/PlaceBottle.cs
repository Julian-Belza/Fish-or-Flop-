using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBottle : MonoBehaviour
{
    public GameObject stationBottle;
    public GameObject playerBottle;
    public PickupBottle pickupbot;
    public GameObject placeDownBotText;

    // Start is called before the first frame update
    void Start()
    {
        placeDownBotText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && pickupbot.hasBottle)
        {
            placeDownBotText.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                placeDownBotText.SetActive(false);
                pickupbot.hasBottle = false;
                playerBottle.SetActive(false);
                stationBottle.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        placeDownBotText.SetActive(false);
    }
}
