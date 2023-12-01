using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorSpawnPoint;
    public AudioClip doorOpenClip;

    public bool requireItemToUnlock = false;
    public string[] unlockItemName;
   
    public PolygonCollider2D telepDoorCamLimiter;

    public InventoryController itemCheckScript;

    // Start is called before the first frame update
    void Start()
    {
        itemCheckScript = GameObject.Find("UI/Inventory").GetComponent<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (requireItemToUnlock == false)
            {
                CamController camScript = GameObject.Find("CM vcam1").GetComponent<CamController>();
                camScript.changeCamBox(telepDoorCamLimiter);
                col.transform.position = doorSpawnPoint.position;
                col.GetComponent<RubyController>().PlaySound(doorOpenClip);
            }
            else
            {
                if(unlockItemName.Length >= 0)
                {
                    if (itemCheckScript._items.Count <= 0) return;

                    int itemNum = unlockItemName.Length;
                    int itemMatchNum = 0;

                    foreach(string i in unlockItemName)
                    {
                        for (int b = 0; b < itemCheckScript._items.Count; b++)
                        {
                            if(i == itemCheckScript._items[b].itemName)
                            {
                                itemMatchNum ++;
                            }
                           
                        }
                       
                    }

                    if(itemMatchNum >= itemNum)
                    {
                        CamController camScript = GameObject.Find("CM vcam1").GetComponent<CamController>();
                        camScript.changeCamBox(telepDoorCamLimiter);
                        col.transform.position = doorSpawnPoint.position;
                        requireItemToUnlock = false;
                    }

                }
            }
            
        }
    }

}
