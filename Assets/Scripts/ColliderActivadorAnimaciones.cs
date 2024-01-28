using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ColliderActivadorAnimaciones : MonoBehaviour
{
    [SerializeField] private GameObject jugador;
    [SerializeField] private GameObject animacion;
    [SerializeField] private string nombreAnimacion;

    private Animator animator;

    private void Start()
    {
        // Obtener el componente Animator del GameObject animacion
        animator = animacion.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == jugador)
        {
            // Activar la animación
            animator.Play(nombreAnimacion);
        }
    }
}
