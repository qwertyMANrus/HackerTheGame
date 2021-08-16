using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Голова игрока
    /// </summary>
    public GameObject Head;

    /// <summary>
    /// Компонент физики
    /// </summary>
    private Rigidbody rigidbodyPlayer;

    /// <summary>
    /// Скорость игрока
    /// </summary>
    public float Speed = 1000f;

    /// <summary>
    /// Скорость вращения камеры
    /// </summary>
    public float SpeedRotateCamera = 5f;



    /// <summary>
    /// Поворачивает игрока
    /// </summary>
    /// <param name="x">Угол по горизонтали</param>
    /// <param name="y">Угол по вертикали (от -90 до 90)</param>
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
    /// Добавляет ускорение
    /// </summary>
    /// <param name="vector">Направление</param>
    public void Move(Vector3 vector)
    {
        Vector3 newVector = vector.normalized * Speed;
        rigidbodyPlayer.AddRelativeForce(newVector * Time.deltaTime, ForceMode.Acceleration);
    }



    /// <summary>
    /// Добавляет ускорение
    /// </summary>
    /// <param name="x">Направление по x</param>
    /// <param name="y">Направление по y</param>
    /// <param name="z">Направление по z</param>
    public void Move(float x, float z, float y = 0f)
    {
        Move(new Vector3(x, y, z));
    }



    private void Awake()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }
}
