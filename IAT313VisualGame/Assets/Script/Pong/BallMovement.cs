using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class BallMovement : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip scoreSound;
    public AudioClip hitSound;


    public UIHealthBar characterHpScript;
    public RubyController playerControllerScript;
    public GameObject pongWindowBox;
    public NonPlayerCharacter gamePlayerScript;
    public PlayableDirector playWinClip;
    public PlayableDirector playLoseClip;

    public float initialSpeed = 10;
    public float speedIncrease = 0.25f;

    public TextMeshProUGUI playerScore;
    private int playerScoreCount;
    public TextMeshProUGUI AiScore;
    private int aiScoreCount;

    public int hitCounter;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Invoke("StartBall", 1.5f);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }

    public void StartBall()
    {
        rb.velocity = new Vector2(-1, 0) * (initialSpeed + speedIncrease * hitCounter);
    }

    public void ResetGame()
    {
        rb.velocity = new Vector2(0, 0);
        transform.localPosition = new Vector2(0, 0);
        hitCounter = 0;
        playerScoreCount = 0;
        aiScoreCount = 0;
        playerScore.text = (playerScoreCount).ToString();
        AiScore.text = ( aiScoreCount).ToString();
        //Invoke("StartBall", 2f);
    }
    public void playBall()
    {
        ResetGame();
        Invoke("StartBall", 1.5f);
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
        audioSource.PlayOneShot(hitSound);
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
        ResetGame();
        //winDialogue.TriggerDialogue();
       
        characterHpScript.addBonusEnergy();
        playerControllerScript.bonusEnergy++;
        Debug.Log("you win");
        gamePlayerScript.played = true;
        playWinClip.Play();
        playerControllerScript.returnUI();
        pongWindowBox.SetActive(false);
        //playerControllerScript.closeItemWindow(pongWindowBox);
    }
    public void aiWins()
    {
        ResetGame();
        gamePlayerScript.played = true;
        playLoseClip.Play();
        playerControllerScript.returnUI();
        pongWindowBox.SetActive(false);
    }

    public void exitGame()
    {
        playerControllerScript.closeItemWindow(pongWindowBox);
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
            audioSource.PlayOneShot(scoreSound);
            playerScoreCount++;
            playerScore.text = ( playerScoreCount).ToString();
            if (playerScoreCount >= 3)
            {
                playerWins();
                return;
            }
            if (aiScoreCount >= 3)
            {
                aiWins();
                return;
            }
            ResetBall();
        }
        else if(transform.localPosition.x < 0)
        {
            audioSource.PlayOneShot(scoreSound);
            aiScoreCount++;
            AiScore.text = ( aiScoreCount).ToString();
            if (playerScoreCount >= 3)
            {
                playerWins();
                return;
            }
            if (aiScoreCount >= 3)
            {
                aiWins();
                return;
            }
            ResetBall();
        }
      
    }


}
