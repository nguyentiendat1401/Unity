using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerTrasform;
    [SerializeField]
    private float offset;

    private void LateUpdate()
    {
        if (playerTrasform != null)
        {
            Vector3 temp = transform.position;
            temp.x = playerTrasform.position.x;

            temp.x += offset;
            transform.position = temp;
        }
    }
}
