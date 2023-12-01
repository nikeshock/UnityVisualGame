using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementStair : MonoBehaviour
{
    public bool isNight;
    public GameObject wallCollider;
    public dialogueTrigger dialogueWarningTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nightWall()
    {
        wallCollider.SetActive(true);
    }

    public void dayWall()
    {
        wallCollider.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(isNight == true)
            {
                dialogueWarningTrigger.TriggerDialogue();
            }

        }
    }

}
