using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingGround : MonoBehaviour
{
    Renderer groundRenderer;

    [SerializeField]
    private float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        groundRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        groundRenderer.material.mainTextureOffset = new Vector2(Time.time * scrollSpeed, 0);
    }
}
