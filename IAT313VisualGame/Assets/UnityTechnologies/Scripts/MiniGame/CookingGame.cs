using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingGame : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip correctSizzleSound;
    public AudioClip wrongSizzleSound;

    public UIHealthBar characterHpScript;
    public RubyController characterScript;

    public GameObject cookingWindow;
    public dialogueTrigger winDialogue;
    public dialogueTrigger loseDialogue;
    public int numTry = 5;
    public NonPlayerCharacter gamePlayerScript;

    public bool isPlaying;
    public int orderNum = 0;
    public GameObject[] hitBar;

    public string[] orderName;
    public GameObject[] objectOrder;

    public Transform startingPos;
    public Rigidbody2D moverObject;
    public bool isMovingMoverObject = true;
    public float remainingTimeToChange;
    public float timeToChange;
    public Vector2 direction = new Vector2 (1,0);
    public float speed;
    //private BoxCollider2D colliderTriggerObject;
    public bool buttonPressToStop;

    // Start is called before the first frame update
    void Start()
    {
        remainingTimeToChange = timeToChange;
        //colliderTriggerObject = this.GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        remainingTimeToChange -= Time.deltaTime;

        if (remainingTimeToChange <= 0)
        {
            remainingTimeToChange += timeToChange;
            direction *= -1;
        }

        if (Input.GetKeyDown("space") && buttonPressToStop == false)
        {
            StartCoroutine(pressTime());
           



        }

    }

    void FixedUpdate()
    {
        
            if (buttonPressToStop == false)
            moverObject.MovePosition(moverObject.position + direction * speed * Time.deltaTime);
       
     
    }

    public void hitValid(string name)
    {
     
        if (orderName[orderNum] == name)
        {
            Debug.Log(name);
            orderNum++;
            audioSource.PlayOneShot(correctSizzleSound);
           
        }
        else
        {
            //ResetGame();
            //numTry--;
            //if(numTry <= 0)
            //{
            //    ResetGame();
            //    numTry = 2;
            //    loseDialogue.TriggerDialogue();
            //    cookingWindow.SetActive(false);
            //}
            audioSource.PlayOneShot(wrongSizzleSound);
            Debug.Log(name + ": You Lose");
        }


    }

    public void ResetGame()
    {
        orderNum = 0;
        this.transform.position = startingPos.position;
        buttonPressToStop = false;
        remainingTimeToChange = timeToChange;
        direction = new Vector2(1, 0);
        int randomNum = Random.Range(1, 4);
        if (randomNum == 1)
            changeOrderFood();
        else if (randomNum == 2) changeOrderFood2();
        else changeOrderFood3();
    }
   
    public void changeOrderFood()
    {
        hitBar[1].transform.position = objectOrder[2].transform.position;
        hitBar[0].transform.position = objectOrder[1].transform.position;
        hitBar[2].transform.position = objectOrder[0].transform.position;
    }

    public void changeOrderFood2()
    {
        hitBar[1].transform.position = objectOrder[0].transform.position;
        hitBar[0].transform.position = objectOrder[2].transform.position;
        hitBar[2].transform.position = objectOrder[1].transform.position;
    }
    public void changeOrderFood3()
    {
        hitBar[1].transform.position = objectOrder[1].transform.position;
        hitBar[0].transform.position = objectOrder[2].transform.position;
        hitBar[2].transform.position = objectOrder[0].transform.position;
    }

    public void nextPoint()
    {
        this.transform.position = startingPos.position;
        remainingTimeToChange = timeToChange;
        direction = new Vector2(1, 0);
    }

    public void checkNumber(int num)
    {
        if (orderName.Length <= orderNum)
        {
            ResetGame();
            winDialogue.TriggerDialogue();
            numTry = 5;

            characterHpScript.addBonusEnergy();
            characterScript.bonusEnergy++;
            
            Debug.Log("you win");
            gamePlayerScript.played = true;
            //cookingWindow.SetActive(false);
            audioSource.PlayOneShot(correctSizzleSound);
            characterScript.closeItemWindow(cookingWindow);
            return;
            //you win
        }
        if (orderNum == num)
        {
            ResetGame();
            numTry--;
            if (numTry <= 0)
            {
      
                numTry = 5;
                loseDialogue.TriggerDialogue();
                characterScript.closeItemWindow(cookingWindow);
                //cookingWindow.SetActive(false);
            }
        }
        else
        {
            nextPoint();
        }

    }

    public IEnumerator pressTime()
    {
        int numberTracker = orderNum;

        buttonPressToStop = true;
        Debug.Log(orderNum + ":number");
       
        //colliderTriggerObject.enabled = true;
        yield return new WaitForSeconds(1f);
        // colliderTriggerObject.enabled = false;
        Debug.Log(orderNum + ":number" + numberTracker);
        checkNumber(numberTracker);
        buttonPressToStop = false;
        isMovingMoverObject = true;
    }


}
