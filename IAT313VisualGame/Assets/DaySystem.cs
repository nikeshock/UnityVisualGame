using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DaySystem : MonoBehaviour
{

    public int dayCounter = 1;
    //public UIHealthBar energyScript;
    public int bonusEnergy;
    public TextMeshProUGUI dayNumberText;
    public PlayableDirector dayScenePlayable;

    //night time
    public bool isTurningNight;
    public GameObject nightLight;
    //day time
    public GameObject dayLight;

    //maincharacter
    public RubyController mainCharacterScript;

    // Start is called before the first frame update
    void Start()
    {
       // Day1Scene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeNight()
    {
        nightLight.SetActive(true);
        dayLight.SetActive(false);
    }
    public void makeDay()
    {
        nightLight.SetActive(false);
        dayLight.SetActive(true);

    }
    public void UpdateDayNumber()
    {
        dayCounter++;
    }
    public void UpdateTimeScene()
    {
        if(isTurningNight == true)
        {
            makeNight();
            isTurningNight = false;
        }
        else
        {
            UpdateDayNumber();
            makeDay();
            PlayDayScene();
            isTurningNight = true;
          
        }
    }

    public void PlayDayScene()
    {
        StartCoroutine(pauseCharacterMovement());
        dayNumberText.SetText("Day: " + dayCounter);
        dayScenePlayable.Play();
    }

    public void Day1Scene()
    {
        StartCoroutine(pauseCharacterMovement());
        dayNumberText.SetText("Day: " + dayCounter);
        dayScenePlayable.Play();

    }

    public IEnumerator pauseCharacterMovement()
    {
        mainCharacterScript.canMove = false;
        yield return new WaitForSeconds(3);
        mainCharacterScript.canMove = true;
    }

}
