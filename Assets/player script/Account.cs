using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Account : MonoBehaviour
{
    public InputField AccountInput;//�˺�����
    public InputField PasswordInput;//��������
    public Text Mistake;//�˺ż��������������ʾ
    public Text Register;//��¼�ɹ���ʾ

    public void OnButton()//Button����¼�
    {
        string AccountNumber = AccountInput.text;//��ȡ�����˺�
        string PassWordNumber = PasswordInput.text;//��ȡ��������
        if (AccountNumber == "13133335840" && PassWordNumber == "zzs20001114")//�ж��Ƿ�������ȷ
        {
            Register.gameObject.SetActive(true);//��¼Ч����ʾ
            StartCoroutine(Disappear());//����Э��
            //SceneManager.LoadScene(1);//��ת��ĳ���
        }
        else
        {
            Mistake.gameObject.SetActive(true);//�˺��������������ʾ
            StartCoroutine(Disappear());//����Э��
        }
    }
    IEnumerator Disappear()//Э��
    {
        yield return new WaitForSeconds(2);//����Ч������
        Mistake.gameObject.SetActive(false);//��ʾ����Ч����ʧ
        Register.gameObject.SetActive(false);//��ʾ��¼�ɹ�Ч����ʧ
    }

}
