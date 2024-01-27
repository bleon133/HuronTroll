using System;
using UnityEngine;

public class Muerte : MonoBehaviour
{
    public event EventHandler kill;

    public void Morir()
    {
        // L�gica para manejar la muerte
        OnKill(EventArgs.Empty);
    }

    protected virtual void OnKill(EventArgs e)
    {
        kill?.Invoke(this, e);
    }
}
