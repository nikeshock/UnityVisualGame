using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : Item{


    public string weaponType;  
 
 
    public bool undroppable = false;
    //public string weaponName;

    public GameObject player;

    public GameObject setWindow;
   

    //public AbilityCoolDown SkillCDScript;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       // SkillCDScript.weaponHolder = player;
    }

   
    public override void Use()
    {
        base.Use();
        useSkill();
        //if(skillGauge <= 100)
        //  {
        //      if(haveDirectionSkillShot == true)
        //      {

        //      }
        //      else
        //      Deplete();
        // }


    }

    

    public void showIndicator()
    {
        //change joystick

    }

    public void useSkill()
    {
        if (setWindow.activeSelf == true)
        {
            setWindow.SetActive(false);
           
        }
        player.GetComponent<RubyController>().canMove = false;
        setWindow.SetActive(true);
       
        Debug.Log("show window UI used");

    }

    void useHighSkill()
    {
        Debug.Log("high skill used");
    }



}
