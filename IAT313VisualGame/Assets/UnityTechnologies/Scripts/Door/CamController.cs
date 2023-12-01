using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
  


   // public PolygonCollider2D currentBox;
    public CinemachineConfiner2D confiner;
    public CinemachineVirtualCamera mainCam;

    public Transform fatherPos;
    public Transform PlayerPos;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeToFather()
    {
        mainCam.Follow = fatherPos;
    }
    public void changeToPlayer()
    {
        mainCam.Follow = PlayerPos;
    }

    public void changeCamBox(PolygonCollider2D camLimit)
    {

        confiner.m_BoundingShape2D = camLimit;
        confiner.InvalidateCache();

    }
}
