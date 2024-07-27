using UnityEngine;

public class Bullet : MonoBehaviour {
    private Transform target;

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float explosionRadius;

    [SerializeField] public bool isPiercingBullet;

    [Header("If Bullet have pierce (Only required if the bool isPiercingBullet is true)")]
    [SerializeField] private float bulletPierce;
    [SerializeField] private float lifeTime;
    private float tActual = 0;

    [Header("Impact effect")]
    [SerializeField] private GameObject impactEffect;

    //For know if the Arrow than Balista shoot colliders twice with same Enemy (This is for fix that bug)
    private int enemyColliderID;

    // Update is called once per frame
    void Update() {
        if (target == null && !isPiercingBullet) {
            Destroy(gameObject);
            return;
        }

        tActual += Time.deltaTime;
        if (isPiercingBullet) {
            if (tActual >= lifeTime) {
                tActual = 0;
                Destroy(gameObject);
            }
            Travel();
        }

        if(!isPiercingBullet) {
            Vector3 direction = target.position - transform.position;
            float distance = speed * Time.deltaTime;

            if (direction.magnitude <= distance) {
                HitTarget();
                return;
            }

            transform.Translate(direction.normalized * distance, Space.World);
            transform.LookAt(target);
        }
    }

    public void Seek(Transform targetSeek){
        target = targetSeek;
    }

    void Travel() {
        float angle = transform.rotation.y * Mathf.Deg2Rad;

        Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad));
        transform.Translate(speed * Time.deltaTime * direction);
    }

    void HitTarget() {
        GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 5f);

        if (explosionRadius > 0) {
            Explode();
        }
        else {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Damage(Transform enemy) {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null) {
            e.TakeDamage(damage);
        }
    }

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders) {
            if (collider.tag == "Enemy") {
                Damage(collider.transform);
            }
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Enemy")) {
            Damage(collider.transform);

            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effect, 2f);

            //Checking if the Arrow isn't in the same enemy, for avoid the losing of more pierce
            if (enemyColliderID != collider.GetInstanceID()) {
                bulletPierce--;
            }
            
            if (bulletPierce <= 0) {
                Destroy(gameObject);
            }

            enemyColliderID = collider.GetInstanceID();
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}