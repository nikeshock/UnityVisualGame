using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playgame : EnergyActiveItem
{
    public bool canBePlayed;
    public bool oncePerDay;

    public GameObject gameWindow;
    public RubyController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PopInteractable(RubyController controller)
    {
        base.PopInteractable(controller);
    }

    public void openGame()
    {
        if (spentEnergy == false)
        {
            playerControllerScript.ChangeHealth();
            spentEnergy = true;
        }
        if (setWindow.activeSelf == true)
        {
            setWindow.SetActive(false);
            if (otherWindows.Length > 0)
            {
                for (int i = 0; i < otherWindows.Length; i++)
                {
                    otherWindows[i].SetActive(false);
                }

            }
        }
        playerControllerScript.canMove = false;
        setWindow.SetActive(true);
        if (otherWindows.Length > 0)
        {
            for (int i = 0; i < otherWindows.Length; i++)
            {
                otherWindows[i].SetActive(true);
            }

        }
    }

}
