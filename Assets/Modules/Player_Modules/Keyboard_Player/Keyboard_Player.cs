using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����������� ������ �� WASD
public class Keyboard_Player : Player
{
    private string ActionButton = "e";

    void Awake()
    {
        hotkey_sign.text = ActionButton.ToUpper();
    }

    protected override Vector3 Move_Input() //���������� ������� � ����������. ���������� ������ ����������� ��������.
    {
        int x = 0;
        int z = 0;

        if (Input.GetKey("w")) z++;
        if (Input.GetKey("s")) z--;
        if (Input.GetKey("d")) x++;
        if (Input.GetKey("a")) x--;

        return new Vector3(x, 0, z).normalized;
    }

    protected override bool InteractiveAction_Input() //�������������� � ������������� �������� (���������� true ���� ������ ������).
    {
        return Input.GetKeyDown(ActionButton);
    }
}
