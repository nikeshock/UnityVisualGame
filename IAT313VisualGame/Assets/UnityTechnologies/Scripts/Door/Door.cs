using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorSpawnPoint;
 
   
    public PolygonCollider2D telepDoorCamLimiter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            CamController camScript =  GameObject.Find("CM vcam1").GetComponent<CamController>();
            camScript.changeCamBox(telepDoorCamLimiter);
            col.transform.position = doorSpawnPoint.position;
        }
    }

}
