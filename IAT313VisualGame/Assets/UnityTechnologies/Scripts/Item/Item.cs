using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : InputManager2, IClickable {

	public int quantity = 1;
    public string weaponName;
    public bool stackable = false;
    public bool unDeletable = false;

    public Item GetCopy()
    {
        return this;
    }

    public void OnLeftClick()
    {
       
    }
    public void OnRightClickDown()
    {
        Use();

    }

    public void OnTouchStay()
    {

    }

    public void OnTouchExit()
    {

    }


    public virtual void actionButton()
    {


    }

    public void SetQuantityText()
    {
        //transform.Find("QuantityText").GetComponent<Text>().text = quantity.ToString();
    }

    public virtual void Use()
    {
        //Debug.Log("Used item: " + name);
    }

    public virtual void Deplete()
    {
        quantity--;
        SetQuantityText();
        if (quantity == 0) GameObject.Destroy(this.gameObject);
    }
    public void Add(int amount)
    {
        quantity += amount;
        SetQuantityText();

        //Add limitation here

    }


    private void OnDestroy()
    {
        InventoryController.Instance.RemoveItem(this);
    }




    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        //Try to add this item to our inventory
    //        GameObject newItem = GameObject.Instantiate(itemReference);
    //        if (InventoryController.Instance.AddItem(newItem))
    //        {
    //            GameObject.Destroy(this.gameObject);
    //        }
    //        else
    //        {
    //            Debug.Log("Inventory is full");
    //        }
    //    }
    //}

    //   // Use this for initialization
    //   void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
}
