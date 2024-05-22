using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapExamle : MonoBehaviour
{
    public float radius;

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach(Collider2D col in colliders)
        {
            Debug.Log("Collider found: " + col.gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
