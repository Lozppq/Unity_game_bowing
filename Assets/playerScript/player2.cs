using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    /// <summary>
    /// �������2�Ķ����л�
    /// </summary>
    Animator player2Anim;

    // Start is called before the first frame update
    void Start()
    {
        player2Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //��һ���
    void boating()
    {
        player2Anim.SetBool("boat2", true);


        //�ָ�idle
        player2Anim.SetBool("boat2", false);
    }


    //��ҵ���
    void fall()
    {
        player2Anim.SetBool("fall2", true);


        //�ָ�idle
        player2Anim.SetBool("fall2", false);
    }

    //��Ҿ���
    void save()
    {
        player2Anim.SetBool("save2", true);


        //�ָ�idle
        player2Anim.SetBool("save2", false);
    }

    //�����ǹ�н�
    void change()
    {
        player2Anim.SetBool("change2", true);


        //�ָ�idle
        player2Anim.SetBool("change2", false);
    }
}
