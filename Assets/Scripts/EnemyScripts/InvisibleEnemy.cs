using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class InvisibleEnemy : MonoBehaviour {
    //Invisible Control Variables
    [SerializeField] private float timeToGoInvisible;
    [SerializeField] private float invisibleTime;
    private float actualTime;

    private bool isInvisible;

    //Variables for inform the Player knowns when the Enemy turn invisible
    private Renderer rend;
    private Color startColor;
    [SerializeField] private Color invisibleColor;

    //Particle System
    [SerializeField] private GameObject invisibleEffect;

    // Start is called before the first frame update
    void Start() {
        if (GameManager.hardMode) {
            timeToGoInvisible -= 2f;
            invisibleTime += 1f;
        }

        actualTime = 0f;
        isInvisible = false;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        invisibleEffect.SetActive(false);
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

    //For change the invisible state of the Enemy
    private void TurnInvisible() {
        if (isInvisible) {
            tag = "Invisible";
            rend.material.color = invisibleColor;
            invisibleEffect.SetActive(true);
        }
        else {
            tag = "Enemy";
            rend.material.color = startColor;
            invisibleEffect.SetActive(false);
        }
    }
}