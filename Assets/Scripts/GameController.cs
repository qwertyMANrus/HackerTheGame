using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// Игрок
    /// </summary>
    public GameObject Player;

    /// <summary>
    /// Скрипт игрока
    /// </summary>
    private Player player;

    /// <summary>
    /// Пауза
    /// </summary>
    private bool pause;

    /// <summary>
    /// Пауза
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
    /// Событие нажатой кнопки
    /// </summary>
    private void OnKey()
    {
        // Управление игроком
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        player.Move(x, y);
    }



    /// <summary>
    /// Событие нажатия кнопки
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
        // Вращение камеры игрока
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        player.Rotate(x, y);
        
        // Вызов событий
        if (Input.anyKey) { OnKey(); }
        if (Input.anyKeyDown) { OnKeyDown(); }
    }
}
