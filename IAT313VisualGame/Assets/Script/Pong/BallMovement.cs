using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class BallMovement : MonoBehaviour
{
    public float initialSpeed = 10;
    public float speedIncrease = 0.25f;

    public TextMeshProUGUI playerScore;
    private int playerScoreCount;
    public TextMeshProUGUI AiScore;
    private int aiScoreCount;

    public int hitCounter;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 1.5f);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }

    public void StartBall()
    {
        rb.velocity = new Vector2(-1, 0) * (initialSpeed + speedIncrease * hitCounter);
    }

    public void ResetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.localPosition = new Vector2(0, 0);
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }
    
    private void PlayerBounce(Transform myObject)
    {
        hitCounter++;
        Vector2 ballPos = transform.localPosition;
        Vector2 playerPos = myObject.localPosition;

        float xDirection, yDirection;
        if(transform.localPosition.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }

        yDirection = (ballPos.y - playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        if(yDirection == 0)
        {
            yDirection = 0.25f;
        }
        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (speedIncrease * hitCounter));

    }

    public void playerWins()
    {

    }
    public void aiWins()
    {

    }

    public void exitGame()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" || collision.gameObject.name == "AI")
        {
            PlayerBounce(collision.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.localPosition.x > 0)
        {
            ResetBall();
            playerScoreCount++;
            playerScore.text = (int.Parse(playerScore.text) + playerScoreCount).ToString();
        }else if(transform.localPosition.x < 0)
        {
            ResetBall();
            aiScoreCount++;
            AiScore.text = (int.Parse(AiScore.text) + aiScoreCount).ToString();
        }
    }


}
