using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Компонента для вывода сообщений на экран пользователя.
public class UI_MessegeLog : MonoBehaviour
{
    public float DelayTime;
    public TextMeshProUGUI UI_Text;
    private IEnumerator coroutine;

    public void Print(string text, Color color)
    {
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = WaitForDelay(text, color);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitForDelay(string text, Color color)
    {
        UI_Text.text = text;
        UI_Text.color = color;
        yield return new WaitForSeconds(DelayTime);
        UI_Text.text = "";
    }
}
