using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

/// <summary>
/// press a key to zoom in or out camera
/// can only use in a 3d project
/// 2d project please use this size variable in cam to accomplish zoom in or out
/// </summary>
public class CameraZoomHelper : MonoBehaviour
{
    public Camera cam;
    public CinemachineVirtualCamera cineCam;

    public KeyCode key;
    public float[] fovArr;
    public float camSpeed = 0.1f;

    private int index = 0;
    private bool isUsingNormalCam;

    public void Start()
    {
        if (cam == null && cineCam == null)
        {
            throw new Exception("CameraZoomHelper: cannot detect any camera");
        }

        isUsingNormalCam = (cam != null);
    }

    public void Update()
    {
        if (Input.GetKeyDown(key))
        {
            index = index < fovArr.Length - 1 ? index+1 : 0;
        }

        if (isUsingNormalCam)
        {

            this.cam.fieldOfView = Mathf.Lerp(this.cam.fieldOfView, fovArr[index], camSpeed);
            Debug.Log("fov:" + cam.fieldOfView + " index" + index + " :" + fovArr[index]);

            if (Mathf.Abs(this.cam.fieldOfView - fovArr[index]) < 0.2)
            {
                this.cam.fieldOfView = fovArr[index];
            }
        }
        else
        {
            this.cineCam.m_Lens.FieldOfView = Mathf.Lerp(this.cam.fieldOfView, fovArr[index], camSpeed);
            if (Mathf.Abs(this.cineCam.m_Lens.FieldOfView - fovArr[index]) < 0.2)
            {
                this.cineCam.m_Lens.FieldOfView = fovArr[index];
            }
        }
    }
}
