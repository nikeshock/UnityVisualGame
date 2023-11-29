using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class UnlockItemScreen : EnergyActiveItem
{

    public string[] unlockItemName;
    public InventoryController itemCheckScript;
    public PlayableDirector playClip;

    public bool isGiven;
    public GameObject rewardItem;
    public GameObject rewardInspectWindow;
    // Start is called before the first frame update

    public GameObject closedBox;
    public GameObject openBox;
    public GameObject closeButton;
    public GameObject grabKeyColliderBox;

    void Start()
    {
        itemCheckScript = GameObject.Find("UI/Inventory").GetComponent<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PopInteractable(RubyController controller)
    {
        if (spentEnergy == false)
        {
            controller.ChangeHealth();
            spentEnergy = true;
        }
        if (setWindow.activeSelf == true)
        {
            setWindow.SetActive(false);
            if (otherWindows.Length > 0)
            {
                for (int i = 0; i < otherWindows.Length; i++)
                {
                    otherWindows[i].SetActive(false);
                }

            }
        }
        
        controller.canMove = false;
        setWindow.SetActive(true);
        checkIfHaveItem();
        if (otherWindows.Length > 0)
        {
            for (int i = 0; i < otherWindows.Length; i++)
            {
                otherWindows[i].SetActive(true);
            }

        }
    }

    public void checkIfHaveItem()
    {
        if (unlockItemName.Length >= 0)
        {
            if (itemCheckScript._items.Count <= 0) return;

            int itemNum = unlockItemName.Length;
            int itemMatchNum = 0;

            foreach (string i in unlockItemName)
            {
                for (int b = 0; b < itemCheckScript._items.Count; b++)
                {
                    if (i == itemCheckScript._items[b].itemName)
                    {
                        itemMatchNum++;
                        
                    }

                }

                if (itemMatchNum >= itemNum)
                {
                    for (int t = 0; t < itemCheckScript._items.Count; t++)
                    {
                        if (i == itemCheckScript._items[t].itemName)
                        {
                            Destroy(itemCheckScript._items[t].gameObject,1f);

                        }

                    }
                    playAnimation();
                   
                }

            }
        }
    }

    public void playAnimation()
    {
        closeButton.SetActive(false);
        playClip.Play();
    }

    public void turnOffCloseBox()
    {

        
       
        closeButton.SetActive(true);
        grabKeyColliderBox.SetActive(true);
        openBox.SetActive(true);
        closedBox.SetActive(false);
    }

    public void giveReward()
    {
        if (isGiven == false)
        {

            Debug.Log("picking item");
            //Try to add this item to our inventory (the UI)

            GameObject newItem = Instantiate(rewardItem);

            // if inventory is good to add
            if (InventoryController.Instance.AddItem(newItem, rewardInspectWindow))
            {
                Debug.Log("added item bb item");
                isGiven = true;
                //GameObject.Destroy(this.gameObject);

            }
        }
    }

}
