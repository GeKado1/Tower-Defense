using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour {
    [SerializeField] private RawImage img;
    [SerializeField] private AnimationCurve fadeCurve;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn() {
        float t = 1f;

        while (t > 0f) {
            float a = fadeCurve.Evaluate(t);

            t = t - Time.deltaTime;

            //For raw images this must be done to change their alpha
            //Per les raw images s'ha de fer això per canviar el seu alpha
            Color color = img.color;
            color.a = a;
            img.color = color;

            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene) {
        float t = 0f;

        while (t < 1f) {
            float a = fadeCurve.Evaluate(t);

            t = t + Time.deltaTime;

            Color color = img.color;
            color.a = a;
            img.color = color;

            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

    public void FadeTo(string scene) {
        StartCoroutine(FadeOut(scene));
    }
}