using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarHitDetection : MonoBehaviour
{
    public string objectName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("HitMarker"))
        {
           
            if (collision.GetComponent<CookingGame>().buttonPressToStop == true && collision.GetComponent<CookingGame>().isMovingMoverObject == true)
            {
                collision.GetComponent<CookingGame>().isMovingMoverObject = false;
                collision.GetComponent<CookingGame>().hitValid(objectName);
            }
           
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("HitMarker"))
        {
            
            if (collision.GetComponent<CookingGame>().buttonPressToStop == true && collision.GetComponent<CookingGame>().isMovingMoverObject == true)
            {
                collision.GetComponent<CookingGame>().isMovingMoverObject = false;
                collision.GetComponent<CookingGame>().hitValid(objectName);
            }
               

        }
    }

}
