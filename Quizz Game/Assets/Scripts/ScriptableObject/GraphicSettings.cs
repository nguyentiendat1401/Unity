using UnityEngine;

[CreateAssetMenu(fileName = "GraphicSettings", menuName = "Game Settings/Graphic Settings")]
public class GraphicSettings : ScriptableObject
{
    public int resolutionWitdh = 1280;
    public int resolutionHeight = 720;
    public bool fullScreen;
}
