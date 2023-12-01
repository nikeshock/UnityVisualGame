using System;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // =========DAY SYSTEM================
    public DaySystem dayScript;
    //public EnergyActiveItem[] interactableHolder;
    public List<EnergyActiveItem> interactableHolder = new List<EnergyActiveItem>();

    // =========Hide UI================
    public GameObject energyUi;
    public GameObject sunUi;
    public GameObject NightUI;
    public GameObject inventoryUI;

    public PolygonCollider2D samRoomCamCollider;

    public GameObject flashlightSource;
    // ========= MOVEMENT =================
    public bool canMove;
    public float speed = 4;
    
    // ======== ENERGY ==========
    public int maxHealth = 5;
    public int bonusEnergy = 0;
    public float timeInvincible = 2.0f;
    public Transform respawnPosition;
    public ParticleSystem hitParticle;
    
    // ======== PROJECTILE ==========
    public GameObject projectilePrefab;

    // ======== AUDIO ==========
    public AudioClip hitSound;
    public AudioClip shootingSound;


    // ======== HEALTH ==========
    public int health
    {
        get { return currentHealth; }
    }
    
    // =========== MOVEMENT ==============
    Rigidbody2D rigidbody2d;
    Vector2 currentInput;
    
    // ======== HEALTH ==========
    int currentHealth;
    float invincibleTimer;
    bool isInvincible;
   
    // ==== ANIMATION =====
    public Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    
    // ================= SOUNDS =======================
    AudioSource audioSource;
    
    void Start()
    {
        // =========== MOVEMENT ==============
        rigidbody2d = GetComponent<Rigidbody2D>();
                
        // ======== HEALTH ==========
        invincibleTimer = -1.0f;
        currentHealth = maxHealth;
        
        // ==== ANIMATION =====
       // animator = GetComponent<Animator>();
        
        // ==== AUDIO =====
        audioSource = GetComponent<AudioSource>();
       
    }

    void Update()
    {
        // ================= HEALTH ====================
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        // ============== MOVEMENT ======================
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
                
        Vector2 move = new Vector2(horizontal, vertical);
        if(canMove == false)
        {
            move = new Vector2(0, 0);
        }
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        currentInput = move;


        // ============== ANIMATION =======================

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        // ============== PROJECTILE ======================

        //if (Input.GetKeyDown(KeyCode.C))
        //    LaunchProjectile();
        
        // ======== DIALOGUE ==========
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, 1 << LayerMask.NameToLayer("NPC"));
            RaycastHit2D hit2 = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, 1 << LayerMask.NameToLayer("Interactable"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    //if(character.dialogTriggerBox.GetComponent<dialogueTrigger>().dialogue.gameType == pong && )
                    if(dayScript.isTurningNight == false) character.dialogTriggerBox.TriggerDialogue();
                    else
                    character.DisplayDialog();
                }  
            }
            else if (hit2.collider != null)
            {
                EnergyActiveItem item = hit2.collider.GetComponent<EnergyActiveItem>();
                if (item != null)
                {
                    
                        item.PopInteractable(this);
                    interactableHolder.Add(item);
                }
            }
        }
 
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        
        position = position + currentInput * speed * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
    }

    // ===================== HEALTH ==================
    public void ChangeHealth()
    {
        
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
            
            animator.SetTrigger("Hit");
            //audioSource.PlayOneShot(hitSound);

        //Instantiate(hitParticle, transform.position + Vector3.up * 0.5f, Quaternion.identity);


        //currentHealth = Mathf.Clamp(currentHealth - 1, 0, maxHealth);
        if (bonusEnergy > 0)
        {
         
        }
        else
        currentHealth--;
        
        if(currentHealth < 0)
            ChangeMode();
        else
        {
            if(bonusEnergy > 0)
            {
                bonusEnergy--;
                UIHealthBar.Instance.useBonusEnergy();
            }
            else
            UIHealthBar.Instance.useEnergy(currentHealth );
        }
        //UIHealthBar.Instance.SetValue(currentHealth / (float)maxHealth);
      

    }

    public void hideUI()
    {
        energyUi.SetActive(false);
        inventoryUI.SetActive(false);
    }

    public void returnUI()
    {
        energyUi.SetActive(true);
        inventoryUI.SetActive(true);
    }

    public void clearEnergyOnObject()
    {
        if(interactableHolder.Count >= 1)
        {
            foreach(EnergyActiveItem energyObject in interactableHolder)
            {
                energyObject.spentEnergy = false;
                
            }
            interactableHolder.Clear();
        }
    }
    

    public void ChangeMode()
    {
        if(bonusEnergy > 0)
        {
            for(int i = 0; i > bonusEnergy ;i++)
            bonusEnergy--;
            UIHealthBar.Instance.useBonusEnergy();
        }
        currentHealth = maxHealth;
        transform.position = respawnPosition.position;
        CamController camScript = GameObject.Find("CM vcam1").GetComponent<CamController>();
        camScript.changeCamBox(samRoomCamCollider);
        clearEnergyOnObject();
        UIHealthBar.Instance.reFillEnergy();
        dayScript.UpdateTimeScene();
    }
    
    public void closeItemWindow(GameObject item)
    {
        item.SetActive(false);
        canMove = true;
    }
    
    // =============== SOUND ==========================

    //Allow to play a sound on the player sound source. used by Collectible
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
