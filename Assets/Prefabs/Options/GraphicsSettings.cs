using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GraphicsSettings : MonoBehaviour
{
    public TMP_Dropdown calidadDropdown;
    public Toggle vsyncToggle;
    public TMP_Dropdown resolucionDropdown;
    public Toggle pantallaCompletaToggle;

    Resolution[] resoluciones;
 
    void Start()
    {
        calidadDropdown.onValueChanged.AddListener(SetCalidad);
        vsyncToggle.onValueChanged.AddListener(SetVSync);
        pantallaCompletaToggle.onValueChanged.AddListener(SetPantallaCompleta);
        List<string> opcionesCalidad = new List<string>(QualitySettings.names);
        calidadDropdown.ClearOptions();
        calidadDropdown.AddOptions(opcionesCalidad);
        resoluciones = Screen.resolutions;
        List<string> opcionesResolucion = new List<string>();
        foreach (var res in resoluciones)
        {
            opcionesResolucion.Add(res.ToString());
        }
        resolucionDropdown.ClearOptions();
        resolucionDropdown.AddOptions(opcionesResolucion);
        resolucionDropdown.onValueChanged.AddListener(SetResolucion);

        LoadValores();
    }

    public void SetCalidad(int index) => QualitySettings.SetQualityLevel(index);
    public void SetVSync(bool activo) => QualitySettings.vSyncCount = activo ? 1 : 0;
    public void SetResolucion(int index) => Screen.SetResolution(resoluciones[index].width, resoluciones[index].height, Screen.fullScreen);
    public void SetPantallaCompleta(bool activo) => Screen.fullScreen = activo;

    public void ResetValores()
    {
        calidadDropdown.value = 2;
        vsyncToggle.isOn = true;
        resolucionDropdown.value = resoluciones.Length - 1;
        pantallaCompletaToggle.isOn = true;
        SetCalidad(2);
        SetVSync(true);
        SetResolucion(resoluciones.Length - 1);
        SetPantallaCompleta(true);
    }

    void LoadValores()
    {
        calidadDropdown.value = QualitySettings.GetQualityLevel();
        vsyncToggle.isOn = QualitySettings.vSyncCount > 0;
        pantallaCompletaToggle.isOn = Screen.fullScreen;
    }
}