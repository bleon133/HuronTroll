using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsContactor : MonoBehaviour
{
    [SerializeField] private int cantidadPuntos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.tag == "Items")
            {
                ControladorPuntos.Instance.SumarItems(cantidadPuntos);
            }
            else if(gameObject.tag == "Llaves")
            {
                ControladorPuntos.Instance.SumarLlaves(cantidadPuntos);
            }
            Destroy(gameObject);
        }
    }
}
