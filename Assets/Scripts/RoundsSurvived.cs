using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundsSurvived : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI roundsText;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnEnable() {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText() {
        roundsText.SetText("0");
        int round = 0;

        yield return new WaitForSeconds(0.7f);

        while (round < PlayerStats.rounds) {
            round++;
            roundsText.SetText(round.ToString());

            yield return new WaitForSeconds(0.05f);
        }
    }
}