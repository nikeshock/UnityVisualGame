using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool triggerOnce = true;
 

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
       // Debug.Log("working");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && triggerOnce == true)
        {
            TriggerDialogue();
            triggerOnce = false;
        }
    
    }

}
