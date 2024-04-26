using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBottle : MonoBehaviour
{
    public GameObject stationBottle;
    public GameObject playerBottle;
    public PickupBottle pickupbot;
    public GameObject placeDownBotText;
    /*
    public Transform bottle;
    Vector3 defaultBotPos;
    Vector3 drinkingPos;
    bool isDrinking;
    */

    // Start is called before the first frame update
    void Start()
    {
        placeDownBotText.SetActive(false);
        /*
        isDrinking = false;
        defaultBotPos = bottle.position;
        drinkingPos = new Vector3(-0.355f, 0.6f, 0.558f);
        */
    }


    private void Update()
    {
        /*
        if (pickupbot.hasBottle && Input.GetKey(KeyCode.R))
        {
            isDrinking = true;
        }
        else
        {
            isDrinking = false;
        }
        */
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
