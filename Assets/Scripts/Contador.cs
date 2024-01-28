using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
   
    [SerializeField] private PersonajeMovimiento jugador;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == jugador.gameObject)
        {
            jugador.CogerItem();
            Destroy(gameObject);
        }
    }
}