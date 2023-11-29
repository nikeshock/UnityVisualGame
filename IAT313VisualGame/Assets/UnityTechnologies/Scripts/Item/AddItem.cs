using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public GameObject _itemPrefabUI;
    public GameObject windowHolder;

    public bool isGiven = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void giveItem()
    {

        if (isGiven == false)
        {

            Debug.Log("picking item");
            //Try to add this item to our inventory (the UI)
            
            GameObject newItem = Instantiate(_itemPrefabUI);

            // if inventory is good to add
            if (InventoryController.Instance.AddItem(newItem, windowHolder))
            {
                Debug.Log("added item bb item");
                isGiven = true;
                //GameObject.Destroy(this.gameObject);

            }
            //else if (isGiven == false)
            //{
            //    Debug.Log("Inventory is full");

            //    //change the other scripted weapon to the new weapon UI
            //    //other.GetComponent<Gun>().weaponEquiped = _itemPrefabUI;

            //    //change the look of the weapon to the new weapon and everything
            //    //other.GetComponent<Gun>().pickUpStarter(_itemPrefabHolder);

            //    //


            //    //saving item after it finishes
            //    InventoryController.Instance.AddItem(newItem);

            //    GameObject.Destroy(this.gameObject);

            //}
        }
    }
}
