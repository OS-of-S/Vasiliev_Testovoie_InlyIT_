using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Перемещение игрока по WASD
public class Keyboard_Player : Player
{
    private string ActionButton = "e";

    void Awake()
    {
        hotkey_sign.text = ActionButton.ToUpper();
    }

    protected override Vector3 Move_Input() //Управление игроком с клавиатуры. Возвращает вектор направления движения.
    {
        int x = 0;
        int z = 0;

        if (Input.GetKey("w")) z++;
        if (Input.GetKey("s")) z--;
        if (Input.GetKey("d")) x++;
        if (Input.GetKey("a")) x--;

        return new Vector3(x, 0, z).normalized;
    }

    protected override bool InteractiveAction_Input() //Взаимодействие с интерактивным объектом (возвращает true если кнопка нажата).
    {
        return Input.GetKeyDown(ActionButton);
    }
}
