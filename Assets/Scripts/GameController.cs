using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// Панель паузы
    /// </summary>
    public GameObject PausePanel;

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
            PausePanel.SetActive(value);
            Time.timeScale = value ? 0 : 1;
            pause = value;
        }
    }



    /// <summary>
    /// Событие зажатой кнопки
    /// </summary>
    private void OnKey()
    {
        if (!Pause)
        {
            // Управление игроком
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            player.Move(x, y);
        }
    }



    /// <summary>
    /// Событие нажатия кнопки
    /// </summary>
    private void OnKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause = !Pause;
        }
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
        if (!Pause)
        {
            // Вращение камеры игрока
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            player.Rotate(x, y);
        }
        
        // Вызов событий
        if (Input.anyKey) { OnKey(); }
        if (Input.anyKeyDown) { OnKeyDown(); }
    }
}
