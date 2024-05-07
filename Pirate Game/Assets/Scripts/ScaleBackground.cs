using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour
{
    private SpriteRenderer bgSpr;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        bgSpr = GetComponent<SpriteRenderer>();
        cam = Camera.main;

        // Lấy kích thước của camera
        float cameraHeight = 2f * cam.orthographicSize;
        float cameraWitdh = cameraHeight * cam.aspect;

        // Lấy kích thước của BG hiện tại
        float bgHeight = bgSpr.sprite.bounds.size.y;
        float bgWitdh = bgSpr.sprite.bounds.size.x;

        // Tỉ lệ scale
        float scaleX = cameraWitdh / bgWitdh;
        float scaleY = cameraHeight / bgHeight;

        // Áp dụng tỉ lệ vào BG
        transform.localScale = new Vector3(scaleX, scaleY, 1f);
    }
}
