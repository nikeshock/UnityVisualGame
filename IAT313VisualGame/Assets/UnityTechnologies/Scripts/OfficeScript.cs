using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeScript : BasementStair
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isNight == false)
            {
                dialogueWarningTrigger.TriggerDialogue();
            }

        }
    }
}
