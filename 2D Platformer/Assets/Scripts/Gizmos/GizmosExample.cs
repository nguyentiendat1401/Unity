using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosExample : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Gizmos.DrawWireCube(transform.position, new Vector3(2f,2f,2f));
        Gizmos.DrawLine(pointA.position, pointB.position);
    }
}
