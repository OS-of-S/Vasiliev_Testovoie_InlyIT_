using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteractive : MonoBehaviour
{
    //�������������� ��� ������� �� ��������� ��������������:
    //  1) �������� ��������������� ������ � ���������, �� ������� "����� ����������" (��� ����������� ����� �������-���������)
    //  2) � ������ ����������� ������-����������� �������� ����� ����������������� � ������������ �� ���������� �������� (��� ������������� ���������� ��� �� ���, ������� � ������ ������ �����)
    //  3) ��� ������ ��������� ���������� ����������������� ���� � ������ ���������� ���������� ����������� ��������� �� �����.

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Player CurrentPlayer = other.GetComponent<Player>();
            if ((!CurrentPlayer.current_interactive) ||
                ((CurrentPlayer.current_interactive.transform.position - CurrentPlayer.transform.position).magnitude > (this.transform.position - CurrentPlayer.transform.position).magnitude))
                CurrentPlayer.current_interactive = this;

            other.GetComponent<Player>().current_interactive = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Player CurrentPlayer = other.GetComponent<Player>();
            if (CurrentPlayer.current_interactive == this) CurrentPlayer.current_interactive = null;
        }
    }

    public abstract void Action(); //����������� ��� �������������� ������ � ��������.
}
