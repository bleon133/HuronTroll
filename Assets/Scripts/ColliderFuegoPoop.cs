using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderFuegoPoop : MonoBehaviour
{
    [SerializeField] private GameObject fuego;
    [SerializeField] private GameObject poop;
    [SerializeField] private GameObject jugador;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private float delayBeforeRespawn = 2f;
    private float delayCanva = 3.5f;
    private bool poopCanKill = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona es el fuego y el jugador
        if (other.gameObject == fuego && jugador != null)
        {
            // Verifica si el "poop" puede matar al jugador
            if (poopCanKill)
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

                Animator animator = other.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.Play("Muerte");
                }

                Destroy(other.gameObject, delayBeforeRespawn);

                StartCoroutine(HandleDeathAndRespawn());
            }
        }
        else if (other.gameObject == poop) // Verifica si el objeto que colisiona es el "poop"
        {
            // Desactiva el collider del "poop"
            Collider2D poopCollider = poop.GetComponent<Collider2D>();
            if (poopCollider != null)
            {
                poopCollider.enabled = false;
            }
        }
    }

    private IEnumerator HandleDeathAndRespawn()
    {
        yield return new WaitForSeconds(delayCanva);

        gameOverCanvas.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
