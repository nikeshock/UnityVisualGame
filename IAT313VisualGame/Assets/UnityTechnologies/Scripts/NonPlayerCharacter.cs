using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// This class handle Non player character. It store their lines of dialogues and the portrait to display.
/// The player controller will call the Advance function when the player press the interact button in front of the NPC
/// The advance function will return false as long as there is new dialogue line, but return true once finished.
/// (Used by Player Controller to block movement until the dialogue is finished)
/// </summary>
public class NonPlayerCharacter : MonoBehaviour
{
    public InventoryController itemCheckScript;
    public string wantedItemName = "sdfadf";
    public bool played = false;
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;

    public dialogueTrigger dialogTriggerBox;

    public dialogueTrigger momFlowerDialogue;

    public PlayableDirector playClip;

    void Start()
    {
        //dialogBox.SetActive(false);
        //timerDisplay = -1.0f;
    }

    void Update()
    {
        //if (timerDisplay >= 0)
        //{
        //    timerDisplay -= Time.deltaTime;
        //    if (timerDisplay < 0)
        //    {
        //        dialogBox.SetActive(false);
        //    }
        //}
    }
    
    public void DisplayDialog()
    {
        //timerDisplay = displayTime;
        //dialogBox.SetActive(true);
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogTriggerBox);
        for (int b = 0; b < itemCheckScript._items.Count; b++)
        {
            if (wantedItemName == itemCheckScript._items[b].itemName)
            {
                giveMission();
                Destroy(itemCheckScript._items[b].gameObject);
                return;
            }

        }
       
        if (played == true)
        dialogTriggerBox.TriggerDialogue();
        else
        {
            dialogBox.SetActive(true);
        }

       
    }

    public void giveMission()
    {
        playClip.Play();
    }
}
