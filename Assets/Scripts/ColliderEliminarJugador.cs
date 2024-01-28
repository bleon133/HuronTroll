using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderEliminarJugador : MonoBehaviour
{
    [SerializeField] private GameObject jugador;
    [SerializeField] private string nombreEscena;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == jugador)
        {
            Destroy(jugador);
        }
    }

    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void ReiniciarEscenaActual()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
