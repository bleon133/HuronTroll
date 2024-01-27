using System;
using UnityEngine;

public class muerte : MonoBehaviour
{
    [SerializeField] private float life;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }
    public event EventHandler muertej;

    public void TomarDaño(float daño)
    {
        life -= daño; 
        if (life < 0) 
        {
            animator.SetTrigger("muerte");
            Physics2D.IgnoreLayerCollision(7,8, true);
        }
    }
    public void MuerteJugadorEvento()
    {
        muertej?.Invoke(this, EventArgs.Empty);
    }
}

