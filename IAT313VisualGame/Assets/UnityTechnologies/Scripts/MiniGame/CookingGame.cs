using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingGame : MonoBehaviour
{
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
           
           
        }
        else
        {
            //ResetGame();
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
            Debug.Log("you win");
            return;
            //you win
        }
        if (orderNum == num)
        {
            ResetGame();
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
