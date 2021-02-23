using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    private const float RotSpeed = 30f;
    
    void Update()
    {
        transform.Rotate(Vector3.up, RotSpeed * Time.deltaTime);
    }
}
