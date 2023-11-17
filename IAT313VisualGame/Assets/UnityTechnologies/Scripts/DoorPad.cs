using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPad : MonoBehaviour
{
    public GameObject unlockDoor;
    public bool doorLocked = true;
    public GameObject lockScript;

    public GameObject cutScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDoorOpen()
    {
        doorLocked = false;
        unlockDoor.SetActive(true);
        if (lockScript.activeSelf == true)
        {
            lockScript.SetActive(false);
        }
        StartCoroutine(playScene());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && doorLocked == true)
        {
            if(lockScript.activeSelf == false)
            {
                lockScript.SetActive(true);
                lockScript.GetComponent<LockCombo>().doorUnlockObject = this;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && doorLocked == true)
        {
            if (lockScript.activeSelf == true)
            {
                lockScript.SetActive(false);
                lockScript.GetComponent<LockCombo>().doorUnlockObject = null;
            }
        }

    }

    IEnumerator playScene()
    {
        yield return new WaitForSeconds(1f);
        cutScene.SetActive(true);
        yield return new WaitForSeconds(12f);
        cutScene.SetActive(false);
    }

}
