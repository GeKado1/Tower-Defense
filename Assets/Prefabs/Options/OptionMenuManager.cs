using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OptionMenuManager : MonoBehaviour {
    public GameObject panelGraficos;
    public GameObject panelControles;
    public GameObject panelSonido;

    public GameObject hud;

    private float savedSensibilidad;
    private bool savedInvertirY;
    private int savedCalidad;
    private bool savedVSync;
    private int savedResolucion;
    private bool savedPantallaCompleta;
    private float savedVolumenGeneral;
    private float savedVolumenMusica;
    private float savedVolumenEfectos;

    public void SaveCurrentState() {
        savedSensibilidad = ControlSettings.Sensibilidad;
        savedInvertirY = ControlSettings.InvertirY;

        savedVSync = GetComponent<GraphicsSettings>().vsyncToggle.isOn;
        savedResolucion = GetComponent<GraphicsSettings>().resolucionDropdown.value;
        savedPantallaCompleta = GetComponent<GraphicsSettings>().pantallaCompletaToggle.isOn;
        
        /*savedVolumenGeneral = SoundSettings.VolumenGeneral;
        savedVolumenMusica = SoundSettings.VolumenMusica;
        savedVolumenEfectos = SoundSettings.VolumenEfectos;*/
    }

    // Llamar cuando se cierra el menú SIN guardar
    public void RevertState() {
        GetComponent<ControlSettings>().sensibilidadSlider.value = savedSensibilidad;
        GetComponent<ControlSettings>().invertirEjeYToggle.isOn = savedInvertirY;

        GetComponent<GraphicsSettings>().calidadDropdown.value = savedCalidad;
        GetComponent<GraphicsSettings>().vsyncToggle.isOn = savedVSync;
        GetComponent<GraphicsSettings>().resolucionDropdown.value = savedResolucion;
        GetComponent<GraphicsSettings>().pantallaCompletaToggle.isOn = savedPantallaCompleta;

      /*soundSettings.volumenGeneral.value = savedVolumenGeneral;
        soundSettings.volumenMusica.value = savedVolumenMusica;
        soundSettings.volumenEfectos.value = savedVolumenEfectos;*/
    }

    private void OnDisable() {
        //hud.GetComponent<HUD>().Back();

        RevertState();
    }

    private void OnEnable() {
        //hud.GetComponent<HUD>().Back();

        GetComponent<SettingsSaver>().LoadSettings();
    }

    public void GuardarCambios() {
        
        GetComponent<SettingsSaver>().SaveSettings();
        SaveCurrentState();
    }

    public void MostrarPanel(GameObject panel) {
        panelGraficos.SetActive(false);
      
        panelControles.SetActive(false);
        panelSonido.SetActive(false);

        panel.SetActive(true);
    }
}