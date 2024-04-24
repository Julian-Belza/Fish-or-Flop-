using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBottle : MonoBehaviour
{
    Outline outline;
    public GameObject playerBottle;
    public GameObject pickupBotText;
    public bool hasBottle;
    public AudioSource pickup;

    // Start is called before the first frame update
    void Start()
    {
        hasBottle = false;
        playerBottle.SetActive(false);
        pickupBotText.SetActive(false);
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasBottle)
        {
            EnableOutline();
            pickupBotText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                pickup.Play();
                pickupBotText.SetActive(false);
                hasBottle = true;
                this.gameObject.SetActive(false);
                playerBottle.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DisableOutline();
        pickupBotText.SetActive(false);
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
