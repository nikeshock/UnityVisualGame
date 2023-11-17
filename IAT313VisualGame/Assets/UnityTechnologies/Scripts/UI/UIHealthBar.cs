using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class take care of scaling the UI image that is used as a health bar, based on the ratio sent to it.
/// It is a singleton so it can be called from anywhere (e.g. PlayerController SetHealth)
/// </summary>
public class UIHealthBar : MonoBehaviour
{
	public static UIHealthBar Instance { get; private set; }

	public Image[] bar;
    private List<GameObject> bonusEnergy = new List<GameObject>();
    public GameObject extraHp;

	float originalSize;

	// Use this for initialization
	void Awake ()
	{
		Instance = this;
	}

	void OnEnable()
	{
		//originalSize = bar.rectTransform.rect.width;
	}

	public void SetValue(float value)
	{		
		//bar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);

	}

    public void useEnergy(int currrentEnergy)
    {
        bar[currrentEnergy].color = new Color32(90, 90, 90,255);

    }

    public void reFillEnergy()
    {
        for (int i = 0; i < bar.Length; i++)
        {
            bar[i].color = new Color(255, 255, 255);
        }
    }

    public void useBonusEnergy()
    {
        if (bonusEnergy.Count <= 0) return;
        GameObject energy = bonusEnergy[0];
        bonusEnergy.Remove(energy);
        Destroy(energy);
    }

    public void addBonusEnergy()
    {
      GameObject newEnergy =  Instantiate(extraHp, transform.position, transform.rotation);
        bonusEnergy.Add(newEnergy);
    }


}
