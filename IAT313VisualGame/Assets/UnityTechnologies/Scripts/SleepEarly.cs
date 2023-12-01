using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepEarly : EnergyActiveItem
{
    public RubyController player;

    public void sleepEarly()
    {
        player.ChangeMode();
    }

    public override void PopInteractable(RubyController controller)
    {
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
        controller.canMove = false;
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
