using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Transform target;

    [SerializeField] private float speed = 0;
    [SerializeField] private float damage = 0;
    [SerializeField] private float explosionRadius = 0;

    [Header("Impact effect")]
    [SerializeField] private GameObject impactEffect;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        if (direction.magnitude <= distance) {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distance, Space.World);
        transform.LookAt(target);
    }

    public void Seek(Transform targetSeek){
        target = targetSeek;
    }

    void HitTarget() {
        GameObject effect = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
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

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}