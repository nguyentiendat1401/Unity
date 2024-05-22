using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;

    [SerializeField]
    private float speed;
    [SerializeField]
    private Animator anim;

    private bool isFacingRight;
    private float idleTimer = 2f;
    private float timer = Mathf.Infinity;


    // Update is called once per frame
    void Update()
    {

        Debug.Log("Enemy Movement");
        if (isFacingRight)
        {
            if (transform.position.x >= pointA.position.x)
            {
                // Di chuyen
                Move(-1);
            }
            else
            {
                // Doi huong
                ChangeDirection();
            }
        }
        else
        {
            if (transform.position.x <= pointB.position.x)
            {
                // Di chuyen
                Move(1);
            }
            else
            {
                // Doi huong
                ChangeDirection();
            }
        }
    }

    void Move(int direction)
    {
        timer = 0;
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * direction, transform.localScale.y, transform.localScale.z);
        anim.SetBool("IsMoving", true);
        transform.position = new Vector3(transform.position.x + Time.deltaTime * direction * speed, transform.position.y, transform.position.z);
    }
    void ChangeDirection()
    {
        anim.SetBool("IsMoving", false);
        timer += Time.deltaTime;

        if (timer > idleTimer){
            isFacingRight = !isFacingRight;
        }
    }

    private void OnDisable()
    {
        anim.SetBool("IsMoving", false);
    }
}
