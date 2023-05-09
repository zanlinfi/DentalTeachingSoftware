using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRun : MonoBehaviour
{

    public void Click()
    {
        //创建点击事件，如果当前显示就让它不显示
        if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
        else	//如果当前不显示，就让它显示
        {
            this.gameObject.SetActive(true);
        }
    }
}