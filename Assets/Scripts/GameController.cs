using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// �����
    /// </summary>
    public GameObject Player;

    /// <summary>
    /// ������ ������
    /// </summary>
    private Player player;

    /// <summary>
    /// �����
    /// </summary>
    private bool pause;

    /// <summary>
    /// �����
    /// </summary>
    public bool Pause
    {
        get
        {
            return pause;
        }
        set
        {
            Time.timeScale = value ? 0 : 1;
            pause = value;
        }
    }



    /// <summary>
    /// ������� ������� ������
    /// </summary>
    private void OnKey()
    {
        // ���������� �������
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        player.Move(x, y);
    }



    /// <summary>
    /// ������� ������� ������
    /// </summary>
    private void OnKeyDown()
    {

    }



    private void Awake()
    {
        player = Player.GetComponent<Player>();
    }



    private void Start()
    {
        Pause = false;
    }



    private void Update()
    {
        // �������� ������ ������
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        player.Rotate(x, y);
        
        // ����� �������
        if (Input.anyKey) { OnKey(); }
        if (Input.anyKeyDown) { OnKeyDown(); }
    }
}
