using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//************************************************相机围绕物体旋转、相机缩放*********************************************************//



public class RotateAndZoomControl : MonoBehaviour
{
    [Header("获得旋转目标")]
    [SerializeField]
    private Transform Mouth1;//获取旋转目标

    [Header("绑定相机")]
    [SerializeField]
    private Camera Camera1;//绑定相机

    public float maxField = 60;//控制相机FieldOfView的最大角度
    public float minField = 0;//控制相机FieldOfView的最小角度



    private void Start()
    {
        //初始化相机面向物体
        Camera1.transform.forward = (Mouth1.position - Camera1.transform.position).normalized;
    }

    private void Update()
    {

        /* if (CameraSwitch._instance.isMainOrRight)
         {
             CameraRotate();
             CameraZoom();
         }
         */
        CameraRotate();
        CameraZoom();

    }

    /// <summary> 相机围绕目标旋转 </summary>
    private void CameraRotate()
    {
        var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
        var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.RotateAround(Mouth1.transform.position, Vector3.up, mouse_x * 5);
            transform.RotateAround(Mouth1.transform.position, transform.right, mouse_y * 5);
        }
    }

    /// <summary>
    /// 相机滚轮缩放（通过修改相机Field Of View的来进行缩放）
    /// </summary>
    private void CameraZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera1.fieldOfView > minField)
        {
            GetComponent<Camera>().fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 20f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera1.fieldOfView < maxField)
        {
            GetComponent<Camera>().fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 20f;
        }
    }

}


