using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerCombo : MonoBehaviour
{


    public string Code = "mark";
    public string passCode = "pong";

    public string Code2 = "Eric";
    public string passCode2 = "forgetmenot";
    
    int NrIndex = 0;
    string alpha;
    public TMP_InputField userText = null;
    public TMP_InputField passwordText = null;
    public GameObject markWindow;
    public GameObject ericWindow;

    public void CodeFunction(string userInput, string passwordInput)
    {
        //NrIndex++;
        //userNr = userNr + userInput;
        //userText.text = userNr;
        //passNr = passNr + passwordInput;
        //passwordText.text = passNr;

    }
    public void Enter()
    {

        string userNr = userText.text;
        string passNr = passwordText.text;

        Debug.Log("enter:" + userNr + passNr);
        if (userNr == Code && passNr == passCode)
        {
            activateMarkOtherWindow();
            Debug.Log("Mark you got the code");
            Delete();
        }
        else if (userNr == Code2 && passNr == passCode2)
        {
            activateEricOtherWindow();
            Debug.Log("Eric you got the code");
            Delete();
        }
        else
        {
            Delete();
        }
    }
    public void Delete()
    {

        //userNr = null;
        //passNr = null;
        userText.text = "";
        passwordText.text = "";
    }

    public void activateMarkOtherWindow()
    {
        markWindow.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void activateEricOtherWindow()
    {
        ericWindow.SetActive(true);
    }

}
