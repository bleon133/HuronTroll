using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderFuegoPoop : MonoBehaviour
{
    [SerializeField] private GameObject poop;
    [SerializeField] private GameObject jugador;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private float delayBeforeRespawn = 2f;
    private float delayCanva = 3.5f;
    private bool fuegoEsSeguro = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject && jugador != null && other.gameObject == jugador)
        {
            if (!fuegoEsSeguro)
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
                animator.Play("Muerte");

                Destroy(other.gameObject, delayBeforeRespawn);

                StartCoroutine(HandleDeathAndRespawn());
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