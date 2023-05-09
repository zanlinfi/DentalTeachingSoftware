using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//************************************************���Χ��������ת���������*********************************************************//



public class RotateAndZoomControl : MonoBehaviour
{
    [Header("�����תĿ��")]
    [SerializeField]
    private Transform Mouth1;//��ȡ��תĿ��

    [Header("�����")]
    [SerializeField]
    private Camera Camera1;//�����

    public float maxField = 60;//�������FieldOfView�����Ƕ�
    public float minField = 0;//�������FieldOfView����С�Ƕ�



    private void Start()
    {
        //��ʼ�������������
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

    /// <summary> ���Χ��Ŀ����ת </summary>
    private void CameraRotate()
    {
        var mouse_x = Input.GetAxis("Mouse X");//��ȡ���X���ƶ�
        var mouse_y = -Input.GetAxis("Mouse Y");//��ȡ���Y���ƶ�
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.RotateAround(Mouth1.transform.position, Vector3.up, mouse_x * 5);
            transform.RotateAround(Mouth1.transform.position, transform.right, mouse_y * 5);
        }
    }

    /// <summary>
    /// ����������ţ�ͨ���޸����Field Of View�����������ţ�
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


