using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AbstractInteractive
{
    public UI_MessegeLog MessegeLog;

    public override void Action()
    {
        MessegeLog.Print("������� ����!\n-10 ��������", Color.green);
    }
}
