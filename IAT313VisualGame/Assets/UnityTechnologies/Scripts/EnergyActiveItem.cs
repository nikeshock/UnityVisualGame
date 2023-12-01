using UnityEngine;

/// <summary>
/// Will handle taking energy to the character when they enter the trigger.
/// </summary>
public class EnergyActiveItem : MonoBehaviour 
{

    public bool spentEnergy;
    public GameObject setWindow;
    public GameObject[] otherWindows;
    public GameObject pressXBox;

    public virtual void PopInteractable(RubyController controller)
    {
        if(spentEnergy == false)
        {
            if(controller.health <= 0)
            {
                controller.ChangeMode();
                return;
            }
            controller.ChangeHealth();
            spentEnergy = true;
        }
        if (setWindow.activeSelf == true)
        {
            setWindow.SetActive(false);
            if(otherWindows.Length > 0)
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        pressXBox.SetActive(true);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        RubyController controller = collision.GetComponent<RubyController>();
        if (controller != null)
        {
            
                if (setWindow.activeSelf == true)
                {
                    setWindow.SetActive(false);
                }
            pressXBox.SetActive(false);
            //Destroy(gameObject);
        }
        }

}
