using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ColliderEliminarJugador : MonoBehaviour
{
    [SerializeField] private GameObject jugador;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == jugador)
        {
            Destroy(jugador);
        }
    }

}
