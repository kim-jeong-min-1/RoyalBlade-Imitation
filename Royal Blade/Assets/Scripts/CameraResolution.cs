using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    private void Awake()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;

        //(���� / ����) ī�޶� ���� ���ϴ� ���� 
        //���� ������ �ػ󵵶�� �ش� ������ �������� �� ���� ���� ������ ��

        //���� ��ũ������� 16:9�� �����̶�� cameraHeight���� 1���� ���� ��
        float cameraHeight = ((float)Screen.width / Screen.height) / ((float)9 / 16);
        float cameraWidth = 1f / cameraHeight;

        //���� 1���� �۴ٸ� ���ΰ� ©�� ���̰�
        //1���� ũ�ٸ� ���ΰ� ©�� ���̴�.
        if (cameraHeight < 1)
        {
            rect.height = cameraHeight;
            rect.y = (1f - cameraHeight) / 2f;
        }
        else
        {
            rect.width = cameraWidth;
            rect.x = (1f - cameraWidth) / 2f;
        }
        camera.rect = rect;
    }
}
