using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PersonajeMovimiento : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    public Vector2 input;

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;

    [Header("Animacion")]
    private Animator animator;

    [Header("Agacharse")]
    [SerializeField] private Transform controladorTecho;
    [SerializeField] private float radioTecho;
    [SerializeField] private float multiplicadorVelocidadAgachado;
    [SerializeField] private Collider2D colisionadorAgachado;
    private bool estabaAgachado = false;
    private bool agachar = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        movimientoHorizontal = input.x * velocidadDeMovimiento;

        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        animator.SetFloat("VelocidadY", rb2D.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }

        if(input.y < 0)
        {
            agachar = true;
        }
        else
        {
            agachar = false;
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        animator.SetBool("enSuelo", enSuelo);
        animator.SetBool("Agachar", estabaAgachado);

        //Mover
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto, agachar);

        salto = false;
    }

    private void Mover(float mover, bool saltar, bool agachar)
    {
        if (!agachar)
        {
            if (Physics2D.OverlapCircle(controladorTecho.position, radioTecho, queEsSuelo))
            {
                agachar = true;
            }
        }

        if (agachar)
        {
            if (!estabaAgachado)
            {
                estabaAgachado = true;
            }

            mover *= multiplicadorVelocidadAgachado;

            colisionadorAgachado.enabled = false;
        }
        else
        {
            colisionadorAgachado.enabled = true;

            if (estabaAgachado)
            {
                estabaAgachado = false;
            }
        }

        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);
        if(mover>0 && !mirandoDerecha) {
            Girar();
        }
        else if(mover<0 && mirandoDerecha)
        {
            Girar();
        }

        if(enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
        Gizmos.DrawWireSphere(controladorTecho.position, radioTecho);
    }
}
