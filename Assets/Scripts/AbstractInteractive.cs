using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteractive : MonoBehaviour
{
    //Нижеприведённый код основан на выбранных предположениях:
    //  1) персонаж взаимодействует ТОЛЬКО с объектами, до которых "может дотянуться" (это реализовано через триггер-коллайдер)
    //  2) в случае пересечения тригер-коллайдеров персонаж может взаимодействовать с ЕДИНСТВЕННЫМ из досягаемых объектов (для однозначности выбирается тот из них, который в данный момент ближе)
    //  3) код должен сохранять корректную работоспособность даже в случае нахождения нескольких экземпляров персонажа на сцене.

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

    public abstract void Action(); //Выполняется при взаимодействии игрока с объектом.
}
