using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectController : MonoBehaviour
{
    private Vector3 nextPos;
    private float moveSpeed;
    private float invokeTime;

    private bool upMove = false;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(0.5f, 5f);
        invokeTime = Random.Range(2f, 10f);

        if (Random.Range(0, 2) == 0)
        {
            upMove = true;
        }

        Invoke("ChangeDirection", invokeTime);
    }

    // Update is called once per frame
    void Update()
    {
        nextPos = transform.position;

        if (upMove)
        {
            nextPos.y += moveSpeed * Time.deltaTime;
        }
        else
        {
            nextPos.y -= moveSpeed * Time.deltaTime;
        }
        transform.position = nextPos;
    }

    void ChangeDirection()
    {
        moveSpeed = Random.Range(0.5f, 5f);
        invokeTime = Random.Range(2f, 10f);
        upMove = !upMove;

        Invoke("ChangeDirection", invokeTime);

    }
}
