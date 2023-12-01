using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementUnlock : MonoBehaviour
{
    public string unlockItemName;
    public bool unlocked = false;
    public GameObject wallGate1;
    public GameObject wallGate2;

    public dialogueTrigger dialogueWarning;

    public InventoryController itemCheckScript;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (unlocked == true)
            {
                col.GetComponent<RubyController>().flashlightSource.SetActive(true);
                return;
            }
            else
            {
                if (itemCheckScript._items.Count <= 0) return;
                for (int b = 0; b < itemCheckScript._items.Count; b++)
                {
                    if (unlockItemName == itemCheckScript._items[b].itemName)
                    {
                        wallGate1.SetActive(false);
                        wallGate2.SetActive(false);
                        unlocked = true;
                        col.GetComponent<RubyController>().flashlightSource.SetActive(true);
                        return;
                    }

                }

                dialogueWarning.TriggerDialogue();


            }
            

        }
    }
}
