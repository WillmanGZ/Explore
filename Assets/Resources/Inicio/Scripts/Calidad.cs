using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calidad : MonoBehaviour
{
    public Dropdown dropdown;
    public int quality;
    // Start is called before the first frame update
    void Start()
    {
        quality = PlayerPrefs.GetInt("numeroDeCalidad", 2);
        dropdown.value = quality;
        AdjustQuality();
    }

    public void AdjustQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        quality = dropdown.value;
    }
}
