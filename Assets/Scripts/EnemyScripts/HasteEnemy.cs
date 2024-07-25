using UnityEngine;

public class HasteEnemy : MonoBehaviour {
    [SerializeField] private float speedBoost;
    private Enemy enemy;
    private float dmgTaken;

    // Start is called before the first frame update
    void Start() {
        if (GameManager.hardMode) {
            speedBoost *= 2f;
        }

        enemy = GetComponent<Enemy>();
    }

    public void SpeedUp(float _dmgTaken) {
        dmgTaken += _dmgTaken;

        if (dmgTaken >= 30) {
            enemy.startSpeed += speedBoost;
            dmgTaken = 0;
        }
    }
}