using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Компонента, масштабирующая UI в зависимости от размера окна.
public class UI_SizeSaver : MonoBehaviour
{
    public float size;
    
    void Start()
    {
        transform.localScale *= Mathf.Min(Screen.height, Screen.width) *size;
    }
}
