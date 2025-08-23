using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ControlSettings : MonoBehaviour {
    public Slider sensibilidadSlider;
    public Toggle invertirEjeYToggle;
    public TextMeshProUGUI numSense;

    public static float Sensibilidad = 1f;
    public static bool InvertirY = false;

    void Start() {
        LoadValores();
        numSense.text = sensibilidadSlider.value.ToString();
    }

    public void CambiarSensibilidad() {
        Sensibilidad = sensibilidadSlider.value;
        numSense.text = sensibilidadSlider.value.ToString();
    }

    public void CambiarInversionY() {
        InvertirY = !InvertirY;
    }

    public void ResetValores() {
        Sensibilidad = 1f;
        InvertirY = false;
        sensibilidadSlider.value = Sensibilidad;
        invertirEjeYToggle.isOn = InvertirY;
    }

    void LoadValores() {
        sensibilidadSlider.value = Sensibilidad;
        invertirEjeYToggle.isOn = InvertirY;
    }
}