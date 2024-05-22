using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    float h, v;
    Rigidbody rb;
    Animator anim;
    Vector3 movement;
    int floorMask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("FloorMask");
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating();
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0, v);

        movement = movement.normalized * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, floorMask))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0;

            var rotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(rotation);
        }
    }

    void Animating()
    {
        //if (h != 0 || v != 0)
        //{
        //    anim.SetBool("IsWalking", true);
        //}
        //else
        //{
        //    anim.SetBool("IsWalking", false);
        //}

        bool isWalking = h != 0 || v != 0;
        anim.SetBool("IsWalking", isWalking);
    }
}
