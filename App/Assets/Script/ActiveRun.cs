using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRun : MonoBehaviour
{

    public void Click()
    {
        //��������¼��������ǰ��ʾ����������ʾ
        if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
        else	//�����ǰ����ʾ����������ʾ
        {
            this.gameObject.SetActive(true);
        }
    }
}