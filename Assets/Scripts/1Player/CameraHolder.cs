using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public void Rotate(float degree)
    {

        gameObject.transform.rotation = Quaternion.Euler(degree, 0, 0);
    }
}
