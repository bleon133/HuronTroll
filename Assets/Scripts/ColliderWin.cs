using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderWin : MonoBehaviour
{
    [SerializeField] private GameObject jugador;
    [SerializeField] private GameObject winnerCanvas;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == jugador)
        {
            Rigidbody2D rb = jugador.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
            }

            PersonajeMovimiento movementScript = jugador.GetComponent<PersonajeMovimiento>();
            if (movementScript != null)
            {
                movementScript.enabled = false;
            }

            winnerCanvas.SetActive(true);

        }
    }
    public void Menu()
    {
        SceneManager.LoadScene("Escena 2");
    }
}
