using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// ������ ������
    /// </summary>
    public GameObject Head;

    /// <summary>
    /// ��������� ������
    /// </summary>
    private Rigidbody rigidbodyPlayer;

    /// <summary>
    /// �������� ������
    /// </summary>
    public float Speed = 1000f;

    /// <summary>
    /// �������� �������� ������
    /// </summary>
    public float SpeedRotateCamera = 5f;



    /// <summary>
    /// ������������ ������
    /// </summary>
    /// <param name="x">���� �� �����������</param>
    /// <param name="y">���� �� ��������� (�� -90 �� 90)</param>
    public void Rotate(float x, float y = 0)
    {
        float oldX = transform.localRotation.eulerAngles.y ;
        float oldY = Head.transform.localEulerAngles.x;

        float newX = oldX + x * SpeedRotateCamera;
        float newY = oldY - y * SpeedRotateCamera;

        transform.localEulerAngles = new Vector3(0f, newX, 0f);
        Head.transform.localEulerAngles = new Vector3(newY, 0f, 0f);
    }



    /// <summary>
    /// ��������� ���������
    /// </summary>
    /// <param name="vector">�����������</param>
    public void Move(Vector3 vector)
    {
        Vector3 newVector = vector.normalized * Speed;
        rigidbodyPlayer.AddRelativeForce(newVector * Time.deltaTime, ForceMode.Acceleration);
    }



    /// <summary>
    /// ��������� ���������
    /// </summary>
    /// <param name="x">����������� �� x</param>
    /// <param name="y">����������� �� y</param>
    /// <param name="z">����������� �� z</param>
    public void Move(float x, float z, float y = 0f)
    {
        Move(new Vector3(x, y, z));
    }



    private void Awake()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }
}
