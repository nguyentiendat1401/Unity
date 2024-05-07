using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float minY, maxY;

    // Bullet
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private float attackTimer;
    private float currentAttacktimer;
    private bool canAttack;
    private AudioSource attackSource;


    // Start is called before the first frame update
    void Start()
    {
        attackSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }

    void MovePlayer()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if (temp.y > maxY)
            {
                temp.y = maxY;
            }

            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < minY)
            {
                temp.y = minY;
            }

            transform.position = temp;
        }
    }
    void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > currentAttacktimer)
        {
            canAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canAttack)
            {
                Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
                canAttack = false;
                attackTimer = 0f;

                // Play sound
                attackSource.Play();
            }
        }
    }
}
