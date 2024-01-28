using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class storyboard : MonoBehaviour
{
    [SerializeField]
    private GameObject[] images; // Array para almacenar las referencias a los objetos de imagen

    private int currentIndex = 0; // Índice de la imagen actual

    public void MoveRight()
    {
        currentIndex++;
        if (currentIndex >= images.Length) currentIndex = 0; // Reinicia el índice si supera el número de imágenes
        UpdateImageVisibility();
    }

    public void MoveLeft()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = images.Length - 1; // Mueve al final si el índice es menor que 0
        UpdateImageVisibility();
    }

    private void UpdateImageVisibility()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(i == currentIndex); // Solo la imagen actual es visible
        }
    }

    public void Iniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
