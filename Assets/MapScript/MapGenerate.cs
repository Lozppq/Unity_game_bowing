using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class MapGenerate : MonoBehaviour
{
    [Header("��Ϸ���")]
    public Transform playerTransform;
    public GameObject LeftMap;
    public GameObject RightMap;
    public GameObject mid;
    public GameObject[] Obstacles;
    public GameObject[] Bloods;
    public AudioSource BackMusic;
    [Header("���Ʋ���")]
    public float Y_Position = 20.5f;
    public float controlObstacle = 0;
    public float controlBlood = 0;
    public float controlWall = 0;
    public float controlStart = 0;

    /// <summary>
    /// ����Ϸ��ʼǰ���ã����ڳ�ʼ����ͼ�Ͳ��ű�������
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        map_Init();
        BackMusic= GetComponent<AudioSource>();
        BackMusic.Play();   
    }

    /// <summary>
    /// ��ÿһ֡�е��ã��������ɵ�ͼ
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        generateMap();
    }

  
    /// <summary>
    /// ���ɵ�ͼ
    /// </summary>
    void generateMap()
    {
        if(playerTransform.position.y + 18 > Y_Position)
        {
            generateObject(Y_Position);
            for(float i = 0f; i < 18; i++)
            {
                Vector3 p_Left = new Vector3(-8.5f, Y_Position, 0);
                Vector3 p_Right = new Vector3(8.5f, Y_Position, 0);
                Vector3 p_Rightmid = new Vector3(7.5f, Y_Position, 0);
                Vector3 p_Leftmid = new Vector3(-7.5f, Y_Position, 0);

                Instantiate(mid, p_Leftmid, Quaternion.Euler(0, 0, 0));
                Instantiate(mid, p_Rightmid, Quaternion.Euler(0, 0, 0));
                Instantiate(LeftMap, p_Left, Quaternion.Euler(0, 0, 90));
                Instantiate(RightMap, p_Right, Quaternion.Euler(0, 0, -90));
                Y_Position++;
            }
            
        }
    }

    /// <summary>
    /// ����������Ϸ���
    /// </summary>
    /// <param name="Y">�����������ʼ�߶�</param>
    void generateObject(float Y)
    {
        for (float i = Y + 2, k = 0; i < Y + 18; i += 3)
        {
            float[] arr = {-5.4f, -1.5f, 2f, 5.4f };
            bool[] index = new bool[4];
            int mem = 2;
            while(mem > 0)
            {
                int j = Random.Range(0, 4);
                if(adjust(index, j))
                {
                    index[j] = true;
                    mem--;
                }
            }
            for(int j = 0; j < 4; j++)
            {
                if (index[j] && k % 2 == 0)
                {
                    generateObstacle(arr[j], i);
                }
                else if(index[j] && k % 2 == 1)
                {
                    generateWall(arr[j], i);
                }
            }
            k++;
            if(i == Y+8)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!index[j])
                    {
                        generateBlood(arr[j], i);
                        break;
                    }
                }
            }
            
        }
       
    }

    /// <summary>
    /// ���ݸ����Ĳ���������������жϸ�������Ӧ�Ĳ���ֵ�Ƿ�Ϊ�棨�ø��Ƿ�ռ�ã�
    /// </summary>
    /// <param name="a">��������</param>
    /// <param name="b">����</param>
    /// <returns>�����������Ӧ�Ĳ���ֵΪ�棬�򷵻� false�����򷵻� true</returns>
    bool adjust(bool[] a, int b)
    {
        if (a[b]) return false;
        return true;
    }

    /// <summary>
    /// ��ʼ����ͼ
    /// </summary>
    void map_Init()
    {
        for (int i = 0; i < 7; i++) Obstacles[i].active = false;
        for (int i = 0; i < 3; i++) Bloods[i].active = false;

        for (float i = -9.5f; i < 20.5f; i+=1)
        {
            Vector3 p_Left = new Vector3(-8.5f, i, 0);
            Vector3 p_Right = new Vector3(8.5f, i, 0);
            Vector3 p_Rightmid = new Vector3(7.5f, i, 0);
            Vector3 p_Leftmid = new Vector3(-7.5f, i, 0);

            Instantiate(mid, p_Leftmid, Quaternion.Euler(0, 0, 90));
            Instantiate(mid, p_Rightmid, Quaternion.Euler(0, 0, -90));
            Instantiate(LeftMap, p_Left, Quaternion.Euler(0,0,90));
            Instantiate(RightMap, p_Right, Quaternion.Euler(0, 0, -90));
        }
        generateObject(0);

    }

    /// <summary>
    /// ��ȡָ������λ�õ��ϰ���
    /// �����λ��û���ϰ���������ϰ��Ｄ�����ԭʼ����
    /// </summary>
    /// <param name="x">ָ��������λ��</param>
    /// <returns>ָ������λ�õ��ϰ���</returns>
    int GetIndex(int x)
    {
        for(int i = 0; i < 6; i++)
        {
            x %= 6;
            if (Obstacles[x].active)
            {
                return x;
            }
        }

        for (int i = 0; i < 6; i++)
        {
            Obstacles[i].active = true;
        }

        return x;
    }

    /// <summary>
    /// ������ͨ�ϰ���
    /// </summary>
    /// <param name="x">����λ�õ�x����</param>
    /// <param name="y">����λ�õ�y����</param>
    void generateObstacle(float x, float y)
    {
        
        Vector3 a = new Vector3(x, y, 0);
        int indexa = GetIndex(Random.Range(0, 6));
        Obstacles[indexa].active = true;
        Instantiate(Obstacles[indexa], a, Quaternion.identity);
        
    }


    /// <summary>
    /// ����Ѫ��
    /// </summary>
    /// <param name="x">����λ�õ�x����</param>
    /// <param name="y">����λ�õ�y����</param>
    void generateBlood(float x, float y)
    {
        Vector3 a = new Vector3(x, y, 0);
        int indexa = Random.Range(0, 3);
        Bloods[indexa].active = true;
        Instantiate(Bloods[indexa], a, Quaternion.identity);
    }
    
    /// <summary>
    /// ���ɵ�ͼ�߽�
    /// </summary>
    /// <param name="x">����λ�õ�x����</param>
    /// <param name="y">����λ�õ�y����</param>
    void generateWall(float x, float y)
    {
        int t = Random.Range(5, 9);
        int[,] arr = new int[3, 3]; 
        for(float i = 0; i < t; )
        {
            int xi = Random.Range(0, 3);
            int yi = Random.Range(0, 3);
            if (arr[xi,yi] == 0)
            {
                arr[xi,yi] = 1;
                i++;
            }
        }

        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if (arr[i,j] == 0)
                {
                    Vector3 a = new Vector3(x-1+i, y-1+j, 0);
                    Obstacles[6].active = true;
                    Instantiate(Obstacles[6], a, Quaternion.identity);
                }
            }
        }
        
         
    }
}
