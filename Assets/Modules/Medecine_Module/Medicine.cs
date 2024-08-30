using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : AbstractInteractive
{
    public UI_MessegeLog MessegeLog;

    public override void Action()
    {
        MessegeLog.Print("Взята аптечка", Color.red);
        Destroy(this.gameObject);
    }
}
