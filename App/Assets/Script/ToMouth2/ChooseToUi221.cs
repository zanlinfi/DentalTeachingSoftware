using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChooseToUi221 : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        SceneManager.LoadScene("ui02-2-1");//""Ϊ����Ҫ�л����ĳ���
    }

    // Update is called once per frame
    void Update()
    {

    }
}
