using UnityEngine;

public class ArmouredEnemy : MonoBehaviour {
    [SerializeField] private float dmgReduction;
    private Enemy enemy;

    // Start is called before the first frame update
    void Start() {
        if (GameManager.hardMode) {
            if (dmgReduction < 0.5f) {
                dmgReduction *= 2;
            }
            else {
                dmgReduction += 0.15f;
            }
        }

        enemy = GetComponent<Enemy>();
    }

    public void TakeDamage(float dmgTaken) {
        enemy.health -= dmgTaken * (1f - dmgReduction);
    }
}