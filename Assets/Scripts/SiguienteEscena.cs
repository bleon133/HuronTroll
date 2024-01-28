using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteEscena : MonoBehaviour
{
    public void CambiarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        // Salir de la aplicaci�n
        Application.Quit();

        // Si est�s en el editor de Unity, esto detendr� la reproducci�n
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
