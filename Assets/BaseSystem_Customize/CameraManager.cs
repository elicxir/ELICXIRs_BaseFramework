using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [HideInInspector]public Camera Camera;

    private void OnValidate()
    {
        if (Camera == null)
        {
            Camera = GetComponent<Camera>();
        }
    }

    public Vector3 Position
    {
        get { return Camera.transform.position; }
        set { Camera.transform.position = value; }
    }


}
