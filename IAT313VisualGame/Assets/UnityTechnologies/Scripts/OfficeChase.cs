using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OfficeChase : MonoBehaviour
{
    public bool isChasing;
    public GameObject player;
    public GameObject fatherChaser;
    public Enemy fatherChaseScript;

    public PlayableDirector playClipBeginChase;

    public PlayableDirector playClipEndChase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playChaseClip()
    {
        playClipBeginChase.Play();
    }

    public void startChasing()
    {
        fatherChaseScript.startFollow = true;
        fatherChaseScript.isChasingPlayer = true;
        isChasing = true;
    }

    public void stopChase()
    {
        fatherChaseScript.doNotMove();
        fatherChaseScript.isChasingPlayer = false;
        fatherChaser.SetActive(false);
        playClipEndChase.Play();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isChasing == true)
        {
            stopChase();
            isChasing = false;
        }
    }

}
