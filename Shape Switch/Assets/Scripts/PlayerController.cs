using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Mesh[] playerMeshs;

    private int tempMeshIndex = 0;
    private Animation playerAnim;

    private void Start()
    {
        playerAnim = GetComponent<Animation>();
    }

    public void ChangePlayer()
    {
        if (tempMeshIndex + 1 < playerMeshs.Length)
        {
            tempMeshIndex++;
        }
        else
        {
            tempMeshIndex = 0;
        }

        Invoke("ApplyMesh", 0.7f);
        ChangePlayerAnim();
    }

    void ApplyMesh()
    {
        GetComponent<MeshFilter>().mesh = playerMeshs[tempMeshIndex];
    }

    private void ChangePlayerAnim()
    {
        switch (tempMeshIndex)
        {
            case 0:
                // Chuyen tu  sphere sang Cube
                playerAnim.Play("sphereToCube");
                break;
            case 1:
                // Chuyen tu  cube sang prims
                playerAnim.Play("cubeToPrims");
                break;
            case 2:
                playerAnim.Play("primsToSphere");
                break;
        }
    }
}
