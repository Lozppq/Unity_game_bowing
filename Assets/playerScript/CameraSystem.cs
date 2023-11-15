using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera�࣬���ڴ�����Camera�ƶ���ص��߼�
/// </summary>
public class CameraSystem : MonoBehaviour
{
    [Header("λ�����")]
    public Transform playerTarget;
    public Transform mapCamera;
    [Header("�ƶ�ʱ�����")]
    public float moveTime;

    /// <summary>
    /// ��ÿһ֡���º���ã����ڴ���Camera���ƶ�
    /// </summary>
    private void LateUpdate()
    {
        moveTime = 1.5f;
        if(playerTarget != null)
        {
            if(playerTarget.position != mapCamera.position)
            {
                Vector3 tempPosition = new Vector3(mapCamera.position.x, playerTarget.position.y + 2f, mapCamera.position.z);
                mapCamera.position = Vector3.Lerp(mapCamera.position, tempPosition, moveTime * Time.deltaTime);
            }
        }        
    }
}
