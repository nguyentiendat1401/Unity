using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector3 nextPos;
    // Update is called once per frame
    void Update()
    {
        nextPos = transform.position;
        nextPos.z -= Time.deltaTime * moveSpeed;
        transform.position = nextPos;
    }
}
