using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// This class handle Enemy behaviour. It make them walk back & forth as long as they aren't fixed, and then just idle
/// without being able to interact with the player anymore once fixed.
/// </summary>
public class Enemy : MonoBehaviour
{
	// ====== ENEMY MOVEMENT ========


	public bool horizontal;
    public Unit followPath;
    public bool startFollow = false;
    protected bool followLoop = true;
    protected Coroutine stopFollow = null;
    protected bool noMove;

    public GameObject player;

    public GameObject smokeParticleEffect;
	public ParticleSystem fixedParticleEffect;

	public AudioClip hitSound;
	public AudioClip fixedSound;
	
	Rigidbody2D rigidbody2d;
	
	Vector2 direction = Vector2.right;
	bool repaired = false;
	
	// ===== ANIMATION ========
	public Animator animator;
	
	// ================= SOUNDS =======================
	AudioSource audioSource;
	
	void Start ()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
		
        followPath = GetComponent<Unit>();
        direction = horizontal ? Vector2.right : Vector2.down;

		//animator = GetComponent<Animator>();

		audioSource = GetComponent<AudioSource>();

    }
	
	void Update()
	{
		if(repaired)
			return;


        if (startFollow)
        {
            startFollowing();
            doNotMove();
            ChaseBackPlayer();
            Debug.Log("following");
            startFollow = false;
        }
        //remainingTimeToChange -= Time.deltaTime;

        //if (remainingTimeToChange <= 0)
        //{
        //	remainingTimeToChange += timeToChange;
        //	direction *= -1;
        //}

        animator.SetFloat("ForwardX", direction.x);
		animator.SetFloat("ForwardY", direction.y);
	}

	void FixedUpdate()
	{
		//rigidbody2d.MovePosition(rigidbody2d.position + direction * speed * Time.deltaTime);
	}

    public virtual void startFollowing()
    {

        if (followLoop == true)
        {
            //   Debug.Log("start");
            // followPath.target = player.transform;
            stopFollow = StartCoroutine(followPath.RefreshPath());
            // Debug.Log(player.transform.position );
            followLoop = false;
        }
        else
        {

            Debug.Log("stop");
            //StartCoroutine(followPath.RefreshPath());
            //  StopCoroutine(stopFollow);
            followPath.target = this.transform;
            followLoop = true;
        }
        startFollow = false;
    }
    public virtual void doNotMove()
    {

        followPath.target = this.transform;
        noMove = true;

    }

    public void ChaseBackPlayer()
    {
        followPath.target = player.transform;
        Debug.Log("chaseBackPlayer");

        noMove = false;
    }
    
    public void goToThislocation(Transform toLocation)
    {

    }

    // go to player
    public virtual IEnumerator HeadOnWalk(float delay)
    {
        yield return new WaitForSeconds(delay);

        followPath.target = this.transform;

        yield break;

    }

    void OnCollisionStay2D(Collision2D other)
	{
		if(repaired)
			return;
		
		RubyController controller = other.collider.GetComponent<RubyController>();
		
		if(controller != null)
			controller.ChangeHealth(-1);
	}

	public void Fix()
	{
		animator.SetTrigger("Fixed");
		repaired = true;
		
		smokeParticleEffect.SetActive(false);

		Instantiate(fixedParticleEffect, transform.position + Vector3.up * 0.5f, Quaternion.identity);

		//we don't want that enemy to react to the player or bullet anymore, remove its reigidbody from the simulation
		rigidbody2d.simulated = false;
		
		audioSource.Stop();
		audioSource.PlayOneShot(hitSound);
		audioSource.PlayOneShot(fixedSound);
	}
}
