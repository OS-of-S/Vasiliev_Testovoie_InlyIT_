using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Перемещение игрока по зажатию левой кнопки мыши. Реализовано исключительно для демонстрации принципа масштабируемости.
public class Mouse_Player : Player
{
    private string ActionButton = "e";

    void Awake()
    {
        hotkey_sign.text = ActionButton.ToUpper();
    }

    protected override Vector3 Move_Input() //Управление игроком с клавиатуры. Возвращает вектор направления движения.
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) return new Vector3(hit.point.x - transform.position.x, 0, hit.point.z - transform.position.z).normalized;
        }
        return Vector3.zero;
    }

    protected override bool InteractiveAction_Input() //Взаимодействие с интерактивным объектом (возвращает true если кнопка нажата).
    {
        return Input.GetKeyDown(ActionButton);
    }
}
