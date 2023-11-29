using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject _itemPrefabUI;
    public GameObject _itemPrefabHolder;
    public GameObject windowHolder;


    public bool canPickUP;

    public void Start()
    {
      

    }


    //public void OnTriggerEnter2D(Collider2D other)
    //{

    //    if (other.CompareTag("Player"))
    //    {
    //        if (other.GetComponent<PlayerControl>().noAttack == true)
    //        {

    //            Debug.Log("l");
    //            //Try to add this item to our inventory
    //            GameObject newItem = GameObject.Instantiate(_itemPrefab);
    //            if (InventoryController.Instance.AddItem(newItem))
    //            {
    //                GameObject.Destroy(this.gameObject);
    //            }
    //            else
    //            {
    //                Debug.Log("Inventory is full");
    //            }
    //        }
    //    }
    //}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<Gun>().aJoystick.actionButton();

        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {




            if (canPickUP)
            {
              
                Debug.Log("picking item");
                //Try to add this item to our inventory (the UI)
               GameObject newItem = Instantiate(_itemPrefabUI);

                // if inventory is good to add
                if (InventoryController.Instance.AddItem(newItem, windowHolder))
                {
                    Debug.Log("added item bb item");
                    GameObject.Destroy(this.gameObject);

                }
                else if(canPickUP)
                {
                    Debug.Log("Inventory is full");
       
                    //change the other scripted weapon to the new weapon UI
                    //other.GetComponent<Gun>().weaponEquiped = _itemPrefabUI;

                    //change the look of the weapon to the new weapon and everything
                    //other.GetComponent<Gun>().pickUpStarter(_itemPrefabHolder);

                    //


                    //saving item after it finishes
                    InventoryController.Instance.AddItem(newItem, windowHolder);

                    GameObject.Destroy(this.gameObject);

                }
            }
        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<Gun>().aJoystick.nonActionButton();

        }
    }



}
