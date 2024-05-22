using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableLayerMask;
    LineRenderer gunLine;
    AudioSource gunAudio;
    ParticleSystem gunParticle;
    Light gunLight;

    float timeBetweenBullets = 0.15f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        shootableLayerMask = LayerMask.GetMask("Shootable");
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunParticle = GetComponent<ParticleSystem>();
        gunLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timer >= timeBetweenBullets)
        {
            Shoot();
        }
        if (timer >= timeBetweenBullets * 0.2f)
        {
            DisableEffect();
        }
    }

    void Shoot()
    {
        timer = 0;

        gunAudio.Play();

        gunLight.enabled = true;
        gunParticle.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, 1000f, shootableLayerMask))
        {
            Debug.Log("ShootableMask");

            EnemyHealth enemyHealth = shootHit.collider.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage();
            }

            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * 100f);
        }
    }

    void DisableEffect()
    {
        gunLine.enabled = false;
        gunParticle.Stop();
        gunLight.enabled = false;
    }
}
