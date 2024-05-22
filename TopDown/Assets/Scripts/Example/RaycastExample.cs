using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //// Tạo ra 1 ray từ vị trí của camera và hướng của camera
        //Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        //// Thực hiện raycast để kiểm tra
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    Debug.Log(hit.transform);
        //    Debug.Log(hit.collider.gameObject.name);
        //    Debug.Log(hit.point);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform);
                Debug.Log(hit.collider.gameObject.name);
                Debug.Log(hit.point);

                Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddForce(Vector3.up * 100f);
                }
                else
                {
                    Debug.Log("Obj ko co Rb");
                }
            }
        }
    }
}
