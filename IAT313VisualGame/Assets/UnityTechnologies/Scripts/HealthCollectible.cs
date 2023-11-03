using UnityEngine;

/// <summary>
/// Will handle giving health to the character when they enter the trigger.
/// </summary>
public class HealthCollectible : MonoBehaviour 
{
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
                controller.ChangeHealth(-1);
                Destroy(gameObject);
            }

        }
    }

}
