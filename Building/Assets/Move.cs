using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float Xposition;//������� �� ����
    public float Xtransition = 0.1f;// �������� � ���� ����
    private float Xoffset;// ��������������� ���������� ��� ��������� ������� ��������
    
    private void Start()
    {
        Xoffset = Xtransition;
    }

    private void FixedUpdate()
    {
        if(Xposition >= 8)
        {
            Xoffset = -Xtransition;
        }
        else if(Xposition <= -8)
        {
            Xoffset = Xtransition;
        }
        Xposition += Xoffset;
        transform.position = new Vector3(Xposition, transform.position.y, transform.position.z);
    }
}
