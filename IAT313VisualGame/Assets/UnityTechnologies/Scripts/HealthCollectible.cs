using UnityEngine;

/// <summary>
/// Will handle giving health to the character when they enter the trigger.
/// </summary>
public class HealthCollectible : MonoBehaviour 
{

    public bool spentEnergy;
    public GameObject setWindow;

    void OnTriggerEnter2D(Collider2D other)
    {
        //RubyController controller = other.GetComponent<RubyController>();

        //if (controller != null)
        //{
        //    if( Input.GetKeyDown("x"))
        //    {
        //        controller.ChangeHealth(-1);
        //        Destroy(gameObject);
        //    }
       
        //}
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (Input.GetKeyDown("x"))
            {
                if(spentEnergy == false)
                {
                    controller.ChangeHealth();
                    spentEnergy = true;
                    setWindow.SetActive(true);
                }
                else if(setWindow.activeSelf == false)
                {
                    setWindow.SetActive(true);
                }
              
                //Destroy(gameObject);
            }

        }
    }

}
