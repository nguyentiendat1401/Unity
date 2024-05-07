using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private bool canRotate;
    [SerializeField]
    private bool canShoot;

    [SerializeField]
    private GameObject enemyBullet;
    [SerializeField]
    private Transform attackPoint;

    private void Start()
    {
        speed = Random.Range(2f, 5f);
        rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);

        if (canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }

    private void Update()
    {
        MoveEnemy();
        RotateEnemy();
    }

    void MoveEnemy()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;

        transform.position = temp;
    }
    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime));
        }
    }

    void StartShooting()
    {
        GameObject bullet =  Instantiate(enemyBullet, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletController>().isEnemyBullet = true;

        if (canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        } 
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("StartShooting");
            }
        }
    }
}
