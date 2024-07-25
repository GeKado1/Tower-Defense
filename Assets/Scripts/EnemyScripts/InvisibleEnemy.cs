using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class InvisibleEnemy : MonoBehaviour {
    [SerializeField] private float timeToGoInvisible;
    [SerializeField] private float invisibleTime;
    private float actualTime;

    private bool isInvisible;

    private Renderer rend;
    private Color startColor;
    [SerializeField] private Color invisibleColor;

    // Start is called before the first frame update
    void Start() {
        actualTime = 0f;
        isInvisible = false;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    // Update is called once per frame
    void Update() {
        if (actualTime >= timeToGoInvisible && !isInvisible) {
            isInvisible = true;
            actualTime = 0f;
        }

        if (actualTime >= invisibleTime && isInvisible) {
            isInvisible = false;
            actualTime = 0f;
        }

        TurnInvisible();

        actualTime += Time.deltaTime;
    }

    private void TurnInvisible() {
        if (isInvisible) {
            tag = "Invisible";
            rend.material.color = invisibleColor;
        }
        else {
            tag = "Enemy";
            rend.material.color = startColor;
        }
    }
}