using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetEnum
{
    one,
    two,
}
public class MovingPlatform : MonoBehaviour
{
    public float speed = 10;
    public Transform oneTransform;
    public Transform twoTransform;

    private TargetEnum nextTarget = TargetEnum.one; 
    private Transform currentTarget;

    private Rigidbody2D rb;

    
    void Start()
    {
        currentTarget = oneTransform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = currentTarget.position;
        Vector2 moveDirection = targetPosition - transform.position;

        float distance = moveDirection.magnitude; 

        if (distance > 0.1f)
        { 
            transform.position = Vector2.MoveTowards(transform.position,
                currentTarget.position, speed * Time.deltaTime);   
        }
        else
        {
            SetNextTarget(nextTarget);
        } 
    }

    void SetNextTarget(TargetEnum target)
    {
        switch (target)
        {
            case TargetEnum.one:
                currentTarget = oneTransform;
                nextTarget = TargetEnum.two;
                break;
            case TargetEnum.two:
                currentTarget = twoTransform;
                nextTarget = TargetEnum.one;
                break;

        }
    }
}
