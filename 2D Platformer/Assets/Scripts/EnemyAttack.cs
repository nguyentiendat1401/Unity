using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private Transform attackPoint;

    private Animator anim;

    private float countdownTimer;
    private float attackCooldown = 5f;

    private EnemyController enemyController;

    private void Start()
    {
        anim = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
    }
    private void Update()
    {
        countdownTimer += Time.deltaTime;

        if (CheckPlayerInSight())
        {
            if (countdownTimer >= attackCooldown)
            {
                countdownTimer = 0f;
                anim.SetTrigger("Attack");
            }
        }

        if (enemyController != null)
        {
            enemyController.enabled = !CheckPlayerInSight();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, 1f);
    }

    private bool CheckPlayerInSight()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, 1f);
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject.name == "Player")
            {
                return true;
            }

        }
        return false;
    }
}
