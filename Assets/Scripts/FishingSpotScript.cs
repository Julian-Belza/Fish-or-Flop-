using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpotScript : MonoBehaviour
{
    public PickUpRod pickuprod;
    public GameObject instructions;
    public bool canFish;

    private void Start()
    {
        instructions.SetActive(false);
        canFish = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && pickuprod.hasRod)
        {
            canFish = true;
            instructions.SetActive(true);
            if(Input.GetKey(KeyCode.Q))
            {
                instructions.SetActive(false);
            }
            if(Input.GetKeyUp(KeyCode.Q))
            {
                instructions.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canFish = false;
        instructions.SetActive(false);
    }
}
