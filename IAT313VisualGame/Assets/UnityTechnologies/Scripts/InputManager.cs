using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

	public static InputManager instance;

	public delegate void InputEvent();
	public static event InputEvent OnPressDown;
	public static event InputEvent OnPressUp;
	public static event InputEvent OnTap;
	public static event InputEvent KeyPressDown;

   
    //select

    //public GameObject select;
    public GameObject itemSelected;

    public Color lol;
    public Color lol2;
    //public NameOfPrefab currentSlot;
    //public Gun gunscript;
   // public GameObject selectedItem;

    // Use this for initialization
    void Start () {
		if(instance == null) instance = this;


        //gunscript.weaponEquiped = itemSelected;
        //gunscript.RefreshGun();

       

    }


    // Update is called once per frame
    void Update()
    {



        
        if (Input.GetMouseButtonUp(0))
        {
            if (OnPressUp != null) OnPressUp();
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Check if we are clicking on UI
            
            if (IsPointerOverUIObject())
            {
                //	Debug.Log("Clicked over UI");
                //Check if is Iclickable on UI
               
                foreach (RaycastResult result in UIObjectsUnderPointer())
                {
               
                   
                    if (result.gameObject.GetComponent<IClickable>() != null)
                    {
                      



                        if (result.gameObject.GetComponent<WeaponItem>() != null)
                        {

                            //select.GetComponent<Image>().color = lol2;
                            Debug.Log("selected2");
                            itemSelected = result.gameObject;
                            itemSelected.GetComponent<WeaponItem>().useSkill();
                            //gunscript.weaponEquiped = itemSelected;
                            //gunscript.RefreshGun();

                            //currentSlot = result.gameObject.GetComponentInParent<NameOfPrefab>();
                            //select.transform.position = currentSlot.transform.position;
                        }






                        break;
                    }
                }
            }
            //Raycas for 3D Objects
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                //Check if is IClickable
                if (hit.transform.GetComponent<IClickable>() != null)
                {
                    IClickable clickable = hit.transform.GetComponent<IClickable>();
                    clickable.OnRightClickDown();
                }
                else
                {
                    //Block
                }
            }



        }
    

    


    }

                 

     private bool IsPointerOverUIObject(int i)
     {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        //eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        eventDataCurrentPosition.position = Input.GetTouch(i).position;
        List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	 }

	private List<RaycastResult> UIObjectsUnderPointer(int i)
    {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Input.GetTouch(i).position;
        //eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results;
	}

    //for mouse
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private List<RaycastResult> UIObjectsUnderPointer()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results;
    }

}
