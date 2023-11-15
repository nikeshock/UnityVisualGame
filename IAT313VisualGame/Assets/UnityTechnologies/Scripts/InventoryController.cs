using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour {

    public static InventoryController Instance;
    private bool dontDestroy = true;
    public InputManager inputScript;

    GraphicRaycaster graphicRaycaster;
	PointerEventData pointerEventData;
	List<RaycastResult> raycastResults;

	GameObject draggedItem;
	Transform draggedItemParent;

   public List<Item> _items = new List<Item>();
   public List<Transform> _slots = new List<Transform>();

    //weapon buff catag

  
    //public List<WeaponItem> _school = new List<WeaponItem>();
    //public List<WeaponItem> _divine = new List<WeaponItem>();
    //public List<WeaponItem> _ninja = new List<WeaponItem>();
    //public List<WeaponItem> _element = new List<WeaponItem>();

    // for upgrading 
    //public GameObject weaponSlot1;
    //public GameObject weaponSlot2;
    //public GameObject weaponSlot3Merge;
    // public GameObject firstWeapon;
    //public  GameObject secondWeapon;

    //public ItemSaveManager itemSaveManager;

    // Use this for initialization
    void Start () {

        Instance = this;

        foreach (Transform slot in transform.Find("Background/Content"))
        {
            _slots.Add(slot);
            if (slot.GetComponentInChildren<Item>() != null)
            {
                _items.Add(slot.GetComponentInChildren<Item>());
              
            }
        }

      

        graphicRaycaster = GameObject.Find("UI").GetComponent<GraphicRaycaster>();
		pointerEventData = new PointerEventData(null);
		raycastResults = new List<RaycastResult>();

        //set the Cancel button
        //transform.Find("Background/Buttons/Cancel").GetComponent<Button>().onClick.AddListener(() =>
        //{
        //    StartCoroutine(ToggleOff());
        //});

        //stop for now
       // itemSaveManager.LoadInventory(this);

        // resfreshInv();
    }

    IEnumerator ToggleOff() {
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {

        //for mouseWork
		DragItems();

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //     clearInventory();DragItems()
        //   // itemSaveManager.LoadInventory(this);
        //    SaveInGameItems();

        //    Debug.Log("Space key was pressed.");
        //}


    }



    public void clearInventory()
    {
        if (_items == null) return;

        for (int i = 1; i < _items.Count; i++)
        {
            //GameObject itemRemove = _items[i].gameObject;
            Destroy(_items[i].gameObject);

           //  Destroy(_items[i].GetComponent<GameObject>());
            //  Debug.Log("delete item");
        }

    }

    public void SaveInGameItems()
    {
      
    }


    public void resfreshInv()
    {


        if (_items != null)
        {
            for (int i = 1; i < _items.Count; i++)
            {
                if (_items[i].GetComponent<WeaponItem>() == null) return;
                recheckBuff(_items[i].GetComponent<WeaponItem>());

                // Destroy(_items[i].GetComponent<GameObject>());
                // Debug.Log("weapon name" + _items[i].GetComponent<WeaponItem>());
            }



        }
    }

    //public void lvlUpWeapon()
    //{
     

    //    if (weaponSlot1.transform.childCount > 0 && weaponSlot2.transform.childCount > 0 && weaponSlot3Merge.transform.childCount == 0)
    //    {
            
    //      WeaponItem  firstWeapon = weaponSlot1.transform.GetChild(0).gameObject.GetComponent<WeaponItem>();

    //        WeaponItem secondWeapon = weaponSlot2.transform.GetChild(0).gameObject.GetComponent<WeaponItem>();
    //        Debug.Log("Same Item 2");

    //        //  if (firstWeapon.GetInstanceID() == secondWeapon.GetInstanceID())
    //        if (firstWeapon.weaponName == secondWeapon.weaponName)
    //        {
    //            Debug.Log("Same Item 3");
    //            GameObject newWeapon = Instantiate(weaponSlot1.transform.GetChild(0).gameObject, weaponSlot3Merge.transform.position, Quaternion.identity);
    //            newWeapon.transform.SetParent(weaponSlot3Merge.transform);
    //            newWeapon.transform.localScale = new Vector3(1, 1, 1);
    //            newWeapon.gameObject.transform.localPosition = Vector3.zero;
    //            newWeapon.GetComponent<WeaponItem>().weaponLvl += 1;
    //            GameObject.Destroy(weaponSlot1.transform.GetChild(0).gameObject);
    //            GameObject.Destroy(weaponSlot2.transform.GetChild(0).gameObject);

    //        }


    //    }

    //}

    public void recheckBuff(WeaponItem weapon)
    {
    
       

    }

    public void removeBuff(WeaponItem weaponName)
    {

    

    }

   






    void DragItems(){
		if(Input.GetMouseButtonDown(0))
        {
			pointerEventData.position = Input.mousePosition;
			graphicRaycaster.Raycast(pointerEventData, raycastResults);
			if(raycastResults.Count > 0)
            {
                if (raycastResults[0].gameObject.GetComponent<Item>())
                {

                    if (raycastResults[0].gameObject.GetComponent<Item>().unDeletable == true)
                    {

                        raycastResults.Clear();
                        return;
                    }
                    draggedItem = raycastResults[0].gameObject;
                    draggedItemParent = draggedItem.transform.parent;
                    //draggedItem.transform.SetParent(UIManager.instance.canvas);
                }
                //if raycast result is not an item
                else
                {
                    raycastResults.Clear();
                }
			}
		}


      

        //check if dragged item is null
        if (draggedItem == null) return;

        //Item follows mouse
        //if (draggeditem != null)
        //{
        //    draggeditem.getcomponent<recttransform>().localposition = uimanager2.instance.screentocanvaspoint(input.mouseposition);
        //}

        //End Dragging
        if (Input.GetMouseButtonUp(0)){
			pointerEventData.position = Input.mousePosition;
			raycastResults.Clear();
			graphicRaycaster.Raycast(pointerEventData, raycastResults);

			//Set old parent
			draggedItem.transform.SetParent(draggedItemParent);

			if(raycastResults.Count > 0)
            {

				foreach(var result in raycastResults){
					//Skip the draggedItem when it is the result
					if(result.gameObject == draggedItem) continue;

                    //merge slot can not be have items dragged
                    //if(result.gameObject == weaponSlot3Merge)
                    //{
                    //    raycastResults.Clear();

                    //    return;
                    //}
                
                    //weapon
                    if (result.gameObject.CompareTag("weaponLvlSlot"))
                    {



                        //Set New Parent
                        draggedItem.transform.SetParent(result.gameObject.transform);

                        Debug.Log("hi");
                        //lvlUpWeapon();

                        break;
                    }

                    //Empty Slot
                    if (result.gameObject.CompareTag("Slot") )
                    {
                     

                        //Set New Parent

                        draggedItem.transform.SetParent(result.gameObject.transform);

						break;
					}
					//Another Item
					if(result.gameObject.CompareTag("ItemIcon")){
                        //Swap Items
                        if (result.gameObject.transform.GetComponent<WeaponItem>().unDeletable == true)
                        {
                            Debug.Log("cant not be moved");
                            return;

                        }

                        //upgrade items
                        if (result.gameObject.transform.CompareTag("weaponLvlSlot"))
                        {
                            draggedItem.transform.SetParent(result.gameObject.transform);

                            Debug.Log("put slot");
                            //lvlUpWeapon();

                            break;
                        }
                        if (result.gameObject.name != draggedItem.name && result.gameObject.GetComponentInParent<NameOfPrefab>().myName == "WeaponLvlSlot")
                        {
                            Debug.Log("switch slot upgrade");
                            draggedItem.transform.SetParent(result.gameObject.transform.parent);
                            result.gameObject.transform.SetParent(draggedItemParent);
                            result.gameObject.transform.localPosition = Vector3.zero;
                            //lvlUpWeapon();
                            break;
                        }
                        //Swap Items
                        if (result.gameObject.name != draggedItem.name)
                        {
                            Debug.Log("swaping");
                           
                            draggedItem.transform.SetParent(result.gameObject.transform.parent);
							result.gameObject.transform.SetParent(draggedItemParent);
							result.gameObject.transform.localPosition = Vector3.zero;

                            inputScript.select.transform.position = result.gameObject.transform.position;
                            inputScript.currentSlot = result.gameObject.GetComponentInParent<NameOfPrefab>();


                            break;
						}
						//Stack items (IF THE ARE THE SAME)
						else
                        {
                          
                            if (result.gameObject.transform.Find("QuantityText") == null)
                            {
               
                                return;
                            }
							result.gameObject.GetComponent<Item>().quantity += draggedItem.GetComponent<Item>().quantity;
							result.gameObject.transform.Find("QuantityText").GetComponent<Text>().text = result.gameObject.GetComponent<Item>().quantity.ToString();

                            //dontDestroy = true;
                            RemoveItem(result.gameObject.GetComponent<Item>());
                            //GameObject.Destroy(draggedItem);
							draggedItem = null;
							raycastResults.Clear();
                            
							return;
						}

                       


                    }

                 
                }
			}
            //if (dontDestroy == false)
            //{
            //    Debug.Log("noting");
            //    GameObject dropitem = draggedItem.gameObject.GetComponent<WeaponItem>().weaponHoldObject;
            //    Instantiate(dropitem, FindObjectOfType<PlayerControl>().gameObject.transform.position, Quaternion.identity);
            //    Destroy(draggedItem);
            //}

            //Reset position to zero
            draggedItem.transform.localPosition = Vector3.zero;
            draggedItem = null;
            //dontDestroy = false;
      
        }

		raycastResults.Clear();
	}

    public bool AddItem(GameObject itemGo)
    {
        Item item = itemGo.GetComponent<Item>();

        //Check all items
        foreach (Item i in _items)
        {
            //if item is already inside
            if (i.itemName == item.itemName && i.stackable == true)
            {
                i.Add(1);
                Debug.Log("added");
               // GameObject.Destroy(itemGo);
               
                return true;
            }
        }


        //Check all slots
        foreach (Transform slot in _slots)
        {
            //if does not contain an item
            if (slot.GetComponentInChildren<Item>() == null)
            {
                Debug.Log("added2");
                itemGo.transform.SetParent(slot);
                itemGo.transform.localScale = Vector3.one;
                itemGo.transform.localPosition = Vector3.zero;
                _items.Add(item);
               SaveInGameItems();
                resfreshInv();
                return true;
            }
        }

        //If inventory is full
        //GameObject.Destroy(itemGo);
       
        return false;
    }

    public void RemoveItem(Item item)
    {
        if (_items.Contains(item))
        {
            _items.Remove(item);
            resfreshInv();


        }
      
    }


}
