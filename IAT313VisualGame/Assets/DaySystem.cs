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

    public AudioClip dayBgSound;
    public AudioClip nightBgSound;
    public AudioSource backgroundMusic;

    public NonPlayerCharacter pongGame;
    public NonPlayerCharacter momGame;

    public GameObject hideMom;

    public BasementStair basementNightScript;
    public BasementStair gardenDoorScript;
    public OfficeScript officeBlocker;
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
        mainCharacterScript.flashlightSource.SetActive(false);
        backgroundMusic.clip = nightBgSound;
        backgroundMusic.Play();
        basementNightScript.nightWall();
        gardenDoorScript.nightWall();
        officeBlocker.dayWall();
        basementNightScript.isNight = true;
        gardenDoorScript.isNight = true;
        officeBlocker.isNight = true;
    }
    public void makeDay()
    {
        nightLight.SetActive(false);
        dayLight.SetActive(true);
        mainCharacterScript.flashlightSource.SetActive(false);
        backgroundMusic.clip = dayBgSound;
        backgroundMusic.Play();
        momGame.played = false;
        pongGame.played = false;
        basementNightScript.dayWall();
        gardenDoorScript.dayWall();
        officeBlocker.nightWall();
        basementNightScript.isNight = false;
        gardenDoorScript.isNight = false;
        officeBlocker.isNight = false;
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
            hideMom.SetActive(false);
        }
        else
        {
            UpdateDayNumber();
            makeDay();
            PlayDayScene();
            isTurningNight = true;
            hideMom.SetActive(true);
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
