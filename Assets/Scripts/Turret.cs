using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    private Transform target;

    [Header("General")]
    [SerializeField] private float range = 0;

    [Header("Use Bullets (Only required if the bool useLaser is false, default option)")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 0;
    private float fireCountdown = 0;

    [Header("Use Laser (Only required if the bool useLaser is true)")]
    [SerializeField] private bool useLaser;
    [SerializeField] private float laserDamage;

    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private ParticleSystem laserEffect;
    [SerializeField] private ParticleSystem impactEffect;
    [SerializeField] private Light impactLight;

    [Header("Unity Setup Fields")]
    [SerializeField] private Transform rotator;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private string enemyTag = "";

    [Header("Bullet Setup")]
    [SerializeField] private Transform firePoint;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update() {
        if (target == null) {
            if (useLaser) {
                if (lineRenderer.enabled) {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    laserEffect.Stop();
                    impactLight.enabled = false;
                }
            }

            return;
        }

        LockOnTarget();

        if (useLaser) {
            Laser();
        }
        else {
            if (fireCountdown <= 0f) {
                Shoot();
                fireCountdown = 1f/fireRate;
            }
            fireCountdown = fireCountdown - Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
        }
        else {
            target = null;
        }
    }

    void Shoot() {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null) {
            bullet.Seek(target);
        }
    }

    void LockOnTarget() {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotator.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        rotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser() {
        if (!lineRenderer.enabled) {
            lineRenderer.enabled = true;
            impactEffect.Play();
            laserEffect.Play();
            impactLight.enabled = true;
        }

        Damage(target);

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 direction = firePoint.position - target.position;

        //Effect when laser is active
        laserEffect.transform.position = firePoint.position;
        
        //Impact on enemy effect
        impactEffect.transform.position = target.position + direction.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(direction);
    }

    void Damage(Transform enemy) {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null) {
            e.TakeDamage(laserDamage);
        }
    }
}