//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Player : MonoBehaviour
{
    public float moviement_speed;
    public TextMeshPro hotkey_sign; //HOT-KEY-���������, ������������ �� ������, ����� ����� ����� �����������������
    public AbstractInteractive current_interactive; //��������� ��������� ������������� ������

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

    protected abstract Vector3 Move_Input(); //���������� ����������. ���������� ������ ����������� ��������.

    private void Walk(Vector3 move_dir) //�������, ������������ �������� �������� ������.
    {                                   //(� �����, � ���� ����� ���� �� ������� �����������, � ����� Keyboard_Player � Mouse_Player ���� �� ����������� �������, ������������ ��������� �������� ������������ ��������� ���������� ������������ Walk(). ��, �.�. ������������ ������ �� ������� ��������� ������������ � ����� ���� � ��� ������ ����������� ������������� �������� "�����", ����������� �������� ���������� ��� ����.)
        move_dir *= moviement_speed *Time.fixedDeltaTime;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(move_dir.x, rb.velocity.y, move_dir.z);
    }

    protected abstract bool InteractiveAction_Input(); //�������������� � ������������� �������� (���������� true ���� ������ ������).
}
