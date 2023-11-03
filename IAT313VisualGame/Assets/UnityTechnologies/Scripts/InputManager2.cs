using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InputManager2 : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler

{
  
    public GameObject itemSelected;
   // public Gun gunscript;


    //  public GameObject select;

    // public GameObject selectedItem;

    void Start()
    {
       // gunscript = GameObject.Find("CharacterFox").GetComponent<Gun>();

    }





    public virtual void OnDrag(PointerEventData ped)
    {
        return;
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {


      
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        if (ped.pointerEnter.gameObject.GetComponent<IClickable>() != null && ped.pointerEnter.gameObject.GetComponentInParent<NameOfPrefab>().myName == "Slot")
        {
            if (ped.pointerEnter.gameObject == itemSelected)
            {
                Debug.Log("I selected twice");
                ped.pointerEnter.gameObject.GetComponent<IClickable>().OnRightClickDown();
            }


            if (GameObject.Find("Select Hotbar Indicator(Clone)") == null)
            {
                if (ped.pointerEnter.gameObject.GetComponent<WeaponItem>() != null)
                {
                    //GameObject selectPic = Instantiate(select, ped.pointerEnter.gameObject.transform.position, Quaternion.identity);
                    //selectPic.transform.SetParent(gameObject.transform, true);
                    //select = selectPic;
                    itemSelected = ped.pointerEnter.gameObject;

                    //gunscript.weaponEquiped = itemSelected;
                    //gunscript.RefreshGun();

                }
            }
            else
            {
                if (ped.pointerEnter.gameObject.GetComponent<WeaponItem>() != null)
                {
                    //  select.transform.position = ped.pointerEnter.gameObject.transform.position;
                    Debug.Log("selected input2");
                    itemSelected = ped.pointerEnter.gameObject;

                    //gunscript.weaponEquiped = itemSelected;
                    //gunscript.RefreshGun();
                }
            }
        }
    }
}
