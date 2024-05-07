using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [HideInInspector] // ẩn ngoài cửa số inspector
    public bool isEnemyBullet;
    // Start is called before the first frame update
    void Start()
    {
        if (isEnemyBullet)
        {
            speed *= -1f;
        }
        //  Destroy(gameObject, 3f);
        Invoke("DestroyObject", 3.5f);

        //InvokeRepeating("Log", 2f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }


    IEnumerator DelayDestroy() 
    {
       // StartCoroutine
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    void Log()
    {
        Debug.Log("Hello CGO");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Enemy(Clone)")
        {
            col.gameObject.GetComponent<Animator>().Play("destroyEnemyAnim");
        }

        if (col.tag == "Bullet" || col.tag == "Enemy" || col.tag == "Player")
        {
            Destroy(col.gameObject , 3f);
            DestroyObject();
        }

       
    }
}
