using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// RawBlood�����ڴ���Ѫ������ʾ
/// </summary>
public class RawBlood : MonoBehaviour
{
    public RawImage rawImage; // ����Raw Image���������  
    public int maxHealth = 600; // ���Ѫ������  
    public float head;
    public TextMeshProUGUI headText;

    /// <summary>
    /// ��ʼ��Ѫ��
    /// </summary>
    void Start()
    {
        head = 826f;
    }

    /// <summary>
    /// ÿһ֡����Ѫ������
    /// </summary>
    private void Update()
    {
        Myblood();
    }

    /// <summary>
    /// ����Ѫ������ʾ
    /// </summary>
    void Myblood()
    {
        float health = rawImage.rectTransform.sizeDelta.x;
        rawImage.rectTransform.anchoredPosition = new Vector2(health / 2 - head, rawImage.rectTransform.anchoredPosition.y);
        Debug.Log(head);
        float t = health / 60;
        headText.text = t.ToString();
        
    }
}
