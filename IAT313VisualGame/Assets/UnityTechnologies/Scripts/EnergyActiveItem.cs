using UnityEngine;

/// <summary>
/// Will handle taking energy to the character when they enter the trigger.
/// </summary>
public class EnergyActiveItem : MonoBehaviour 
{

    public bool spentEnergy;
    public GameObject setWindow;
    public GameObject pressXBox;

    public void PopInteractable(RubyController controller)
    {
        if(spentEnergy == false)
        {
            controller.ChangeHealth();
            spentEnergy = true;
        }
        if (setWindow.activeSelf == true)
        {
            setWindow.SetActive(false);
        }
        controller.canMove = false;
        setWindow.SetActive(true);
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
