using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceRod : MonoBehaviour
{
    public GameObject stationRod;
    public GameObject playerRod;
    public PickUpRod pickuprod;
    public GameObject placeDownText;

    // Start is called before the first frame update
    void Start()
    {
        placeDownText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && pickuprod.hasRod)
        {
            placeDownText.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                placeDownText.SetActive(false);
                pickuprod.hasRod = false;
                playerRod.SetActive(false);
                stationRod.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        placeDownText.SetActive(false);
    }
}
