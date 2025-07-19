using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSaver : MonoBehaviour
{
    public ControlSettings controlSettings;
    public GraphicsSettings graphicsSettings;
 

    void Start()
    {
        controlSettings = GetComponent<ControlSettings>();
        graphicsSettings = GetComponent<GraphicsSettings>();
        LoadSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Sensibilidad", ControlSettings.Sensibilidad);
        PlayerPrefs.SetInt("InvertirY", ControlSettings.InvertirY ? 1 : 0);
       
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        ControlSettings.Sensibilidad = PlayerPrefs.GetFloat("Sensibilidad", 1f);
        ControlSettings.InvertirY = PlayerPrefs.GetInt("InvertirY", 0) == 1;


    }

    public void ResetearValoresPorDefecto()
    {
        controlSettings.ResetValores();
        graphicsSettings.ResetValores();

    }
}
