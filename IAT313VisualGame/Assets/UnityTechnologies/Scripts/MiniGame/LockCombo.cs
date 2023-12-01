using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LockCombo : MonoBehaviour
{
    public string Code = "123";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public TextMeshProUGUI UiText = null;
    public GameObject doorUnlockObject;
    public GameObject otherDoorUnlockWindow;

   public GameObject lockComboWindow;

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;

    }
    public void Enter()
    {
        if (Nr == Code)
        {
            //doorUnlockObject.setDoorOpen();
            doorUnlockObject.SetActive(true);
            otherDoorUnlockWindow.SetActive(true);
            Debug.Log("you got the code");
            Delete();
            lockComboWindow.SetActive(false);
        }
        else
        {
            Delete();
        }
    }
    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }
}
