using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairScript : MonoBehaviour
{
    public PlayerMovement pm;
    public GameObject sitText;
    public GameObject standText;
    public Transform player;
    public float xDisplace = -3f;
    public float zDisplace = -3f;
    Vector3 standPos;
    Outline outline;
    bool isSitting;

    // Start is called before the first frame update
    void Start()
    {
        isSitting = false;
        sitText.SetActive(false);
        standText.SetActive(false);
        outline = GetComponent<Outline>();
        DisableOutline();
        standPos = new Vector3(transform.position.x + xDisplace, transform.position.y + 3, transform.position.z + zDisplace);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSitting && Input.GetKey(KeyCode.F))
        {
            isSitting = false;
            player.position = standPos;
        }

        if (isSitting)
        {
            standText.SetActive(true);
            pm.playerCanMove = false;
            pm.enableHeadBob = false;
        }
        else
        {
            standText.SetActive(false);
            pm.playerCanMove = true;
            pm.enableHeadBob = true;
        }
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isSitting)
        {
            EnableOutline();
            sitText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                sitText.SetActive(false);
                isSitting = true;
                player.position = transform.position;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DisableOutline();
        sitText.SetActive(false);
    }
}
