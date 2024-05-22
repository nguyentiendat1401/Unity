using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private float attackRange;
    [SerializeField]
    private Transform attackPoint;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");

            //Kiểm tra collider nằm trong khu vực chém
            Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
            foreach(Collider2D col in colliders)
            {
                if (col.gameObject.name == "Enemy")
                {
                    Debug.Log("Hit enemy!" + col.name);
                }
             
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
