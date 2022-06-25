using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings_Manager : MonoBehaviour
{
    public Toggle ldm;

    public void toggleLdm()
    {
        Debug.Log("Toggled");
        if(ldm.isOn)
        {
            QualitySettings.SetQualityLevel(0);
        }
        else
        {
            QualitySettings.SetQualityLevel(3);
        }
    }
}
