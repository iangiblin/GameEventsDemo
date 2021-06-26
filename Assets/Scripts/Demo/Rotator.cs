using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [ContextMenu("RotateObject")]
    public void RotateObject()
    {
        transform.Rotate(Vector3.up, 5f);
    }
}
