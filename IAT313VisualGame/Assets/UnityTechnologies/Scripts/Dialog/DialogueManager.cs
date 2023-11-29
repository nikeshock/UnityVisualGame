using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dialogueUIBox;
    public Text nameText;
    public Text dialogueText;
    public Image characterSprite;

    //public Animator animator;

    private Queue<string> sentences;


    public GameObject pongGame;
    public GameObject foodGame;
    public bool playPongGame;
    public bool playFoodGame;
    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //    animator.SetBool("IsOpen", true);
        dialogueUIBox.SetActive(true);
        nameText.enabled = true;
        dialogueText.enabled = true;
        nameText.text = dialogue.name;
        characterSprite.overrideSprite = dialogue.characterSprite.sprite;
        characterSprite.enabled = true;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        if(dialogue.gameType == "FoodGame")
        {
            playFoodGame = true;
        }
        else if(dialogue.gameType == "PongGame")
        {
            playPongGame = true;
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        //  animator.SetBool("IsOpen", false);
        if(playPongGame == true)
        {
            if(pongGame.activeSelf == false)
            pongGame.SetActive(true);
            playPongGame = false;
        }
        if(playFoodGame == true)
        {
            if (foodGame.activeSelf == false)
                foodGame.SetActive(true);
            playFoodGame = false;
        }

        nameText.enabled = false;
        dialogueText.enabled = false;
        characterSprite.enabled = false;
        dialogueUIBox.SetActive(false);
    }

}
