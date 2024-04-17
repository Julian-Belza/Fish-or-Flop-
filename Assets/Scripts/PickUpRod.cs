using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRod : MonoBehaviour
{
    Outline outline;
    public GameObject playerRod;
    public GameObject pickupText;
    public bool hasRod;

    // Start is called before the first frame update
    void Start()
    {
        hasRod = false;
        playerRod.SetActive(false);
        pickupText.SetActive(false);
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasRod)
        {
            EnableOutline();
            pickupText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                pickupText.SetActive(false);
                hasRod = true;
                this.gameObject.SetActive(false);
                playerRod.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DisableOutline();
        pickupText.SetActive(false);
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }
}
