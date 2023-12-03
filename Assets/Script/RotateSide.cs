using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSide : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.forward);
    }
}
