using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class Teleport : MonoBehaviour
{
    int items = 0;
    int llaves = 0;

    public void AccionEspecifica()
    {
        if (ControladorPuntos.Instance != null)
        {
            items = ControladorPuntos.Instance.GetCantidadItems();

            llaves = ControladorPuntos.Instance.GetCantidadLlaves();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AccionEspecifica();

            if (llaves > 0 && items > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Debug.Log("Debes recolectar la llave y las recetas de comidas para pasar.");
            }
        }
    }
}
