using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����������� ������ �� ������� ����� ������ ����. ����������� ������������� ��� ������������ �������� ����������������.
public class Mouse_Player : Player
{
    private string ActionButton = "e";

    void Awake()
    {
        hotkey_sign.text = ActionButton.ToUpper();
    }

    protected override Vector3 Move_Input() //���������� ������� � ����������. ���������� ������ ����������� ��������.
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) return new Vector3(hit.point.x - transform.position.x, 0, hit.point.z - transform.position.z).normalized;
        }
        return Vector3.zero;
    }

    protected override bool InteractiveAction_Input() //�������������� � ������������� �������� (���������� true ���� ������ ������).
    {
        return Input.GetKeyDown(ActionButton);
    }
}
