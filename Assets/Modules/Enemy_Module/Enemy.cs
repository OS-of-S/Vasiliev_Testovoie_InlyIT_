using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AbstractInteractive
{
    public UI_MessegeLog MessegeLog;

    public override void Action()
    {
        MessegeLog.Print("Получен урон!\n-10 здоровья", Color.green);
    }
}
