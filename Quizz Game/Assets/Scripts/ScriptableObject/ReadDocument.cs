using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReadDocument", menuName ="Document/Read")]
public class ReadDocument : ScriptableObject
{
    public string documentTitle;

    [TextArea(5, 10)]
    public string content;
}
