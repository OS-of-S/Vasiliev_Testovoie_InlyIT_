//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Player : MonoBehaviour
{
    public float moviement_speed;
    public TextMeshPro hotkey_sign; //HOT-KEY-подсказка, появляющаяся на экране, когда игрок может взаимодействовать
    public AbstractInteractive current_interactive; //доступный персонажу интерактивный объект

    private void Awake()
    {
        hotkey_sign.enabled = false;
    }

    void FixedUpdate()
    {
        Vector3 move_dir = Move_Input();
        Walk(move_dir);
    }

    private void Update()
    {
        if (current_interactive)
        {
            hotkey_sign.enabled = true;
            if (InteractiveAction_Input()) current_interactive.Action();
        }
        else hotkey_sign.enabled = false;
    }

    protected abstract Vector3 Move_Input(); //Управление персонажем. Возвращает вектор направления движения.

    private void Walk(Vector3 move_dir) //Функция, определяющая характер движения игрока.
    {                                   //(В целом, её тоже можно было бы сделать виртуальной, и тогда Keyboard_Player и Mouse_Player были бы подмодулями модулей, реализующими различный характер передвижения персонажа различными реализациями Walk(). Но, т.к. поставленная задача не требует подобного разнообразия в явном виде и для лучшей наглядности использования паттерна "Фасад", предпочитаю оставить реализацию как есть.)
        move_dir *= moviement_speed *Time.fixedDeltaTime;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(move_dir.x, rb.velocity.y, move_dir.z);
    }

    protected abstract bool InteractiveAction_Input(); //Взаимодействие с интерактивным объектом (возвращает true если кнопка нажата).
}
