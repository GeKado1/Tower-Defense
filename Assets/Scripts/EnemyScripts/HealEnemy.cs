using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class HealEnemy : MonoBehaviour {
    [SerializeField] private float heal;
    [SerializeField] private float healCountdown;
    private float countdown;

    //Heal Particle System
    [SerializeField] private ParticleSystem healParticleSystem;
    private float particleControlTimer;
    private bool isParticleSystemOn;

    private Enemy enemy;

    // Start is called before the first frame update
    void Start() {
        if (GameManager.hardMode) {
            healCountdown /= 2f;
        }

        enemy = GetComponent<Enemy>();
        countdown = healCountdown;

        particleControlTimer = 0f;
        isParticleSystemOn = false;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update() {
        if (enemy.health < enemy.startHealth) {
            if (countdown <= 0f) {
                HealItself();
                countdown = healCountdown;

                isParticleSystemOn = true;
            }
        }

        if (isParticleSystemOn && particleControlTimer <= 1f) {
            particleControlTimer += Time.deltaTime;
        }
        else {
            isParticleSystemOn = false;
            particleControlTimer = 0f;
        }

        countdown -= Time.deltaTime;
    }

    private void HealItself() {
        float healAmount = enemy.startHealth - enemy.health;

        if (healAmount < heal) {
            enemy.health += healAmount;
        }
        else {
            enemy.health += heal;
        }

        healParticleSystem.Play();
    }
}