using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChooseToUi113 : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        SceneManager.LoadScene("ui01-1-3");//level1Ϊ����Ҫ�л����ĳ���
    }

    // Update is called once per frame
    void Update()
    {

    }
}