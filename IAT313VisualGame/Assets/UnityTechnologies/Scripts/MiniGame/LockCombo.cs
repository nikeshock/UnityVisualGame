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
    public DoorPad doorUnlockObject;

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
            doorUnlockObject.setDoorOpen();
            Debug.Log("you got the code");
            Delete();
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
