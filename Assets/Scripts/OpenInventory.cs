using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenInventory : MonoBehaviour
{
    public GameObject inventory;
    bool inventoryOpen;
    public TMP_Text txt;
    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false);
        inventoryOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!inventoryOpen)
            {
                inventory.SetActive(true);
                txt.SetText("Press TAB to close");
                inventoryOpen = true;
            }
            else
            {
                inventory.SetActive(false);
                txt.SetText("Press TAB to open inventory");
                inventoryOpen = false;
            }
        }
    }
}
