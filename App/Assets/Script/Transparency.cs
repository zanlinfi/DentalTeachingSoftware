using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transparency : MonoBehaviour
{
    public GameObject obj; //��Ҫ�ı�Shader������
    public Slider slider; //��������͸���ȵ�slider

    void Start()
    {
        slider.value = 1.0f; // ����͸���ȳ�ʼֵΪ1��

    }

    void Update()
    {
        obj.GetComponent<MeshRenderer>().material.color = RandomColor();
        if (slider.value == 1.0f)
        {
            SetMaterialRenderingMode(obj.GetComponent<MeshRenderer>().material, RenderingMode.Opaque);
        }
        else
        {
            SetMaterialRenderingMode(obj.GetComponent<MeshRenderer>().material, RenderingMode.Transparent);
        }


    }

    private Color RandomColor()
    {

        float r = obj.GetComponent<MeshRenderer>().material.color.r;// ��ȡ��ǰ�����RGBֵ(1.0f)
        float g = obj.GetComponent<MeshRenderer>().material.color.g;
        float b = obj.GetComponent<MeshRenderer>().material.color.b;
        float a = slider.value; //��sliderֵ����͸����
        Color color = new Color(r, g, b, a);
        return color;
    }


    /// <summary>
    /// ö��Shader4��״̬����
    /// </summary>
    public enum RenderingMode
    {
        Opaque,
        Cutout,
        Fade,
        Transparent,
    }

    public void SetMaterialRenderingMode(Material material, RenderingMode renderingMode)
    {
        switch (renderingMode)
        {
            case RenderingMode.Opaque:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
                break;
            case RenderingMode.Cutout:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.EnableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 2450;
                break;
            case RenderingMode.Fade:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
            case RenderingMode.Transparent:
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = 3000;
                break;
        }
    }
}