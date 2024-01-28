using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance;

    [SerializeField] private int cantidadItems;
    [SerializeField] private int cantidadLlaves;
    [SerializeField] private TextMeshProUGUI TextContadorItems;
    [SerializeField] private TextMeshProUGUI TextContadorLlaves;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        ActualizarReferenciasUI();
    }

    void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        ActualizarReferenciasUI();
    }

    private void ActualizarReferenciasUI()
    {
        TextContadorItems = GameObject.Find("TextContadorItems").GetComponent<TextMeshProUGUI>();
        TextContadorLlaves = GameObject.Find("TextContadorLlaves").GetComponent<TextMeshProUGUI>();

        TextContadorItems.text = cantidadItems.ToString();
        TextContadorLlaves.text = cantidadLlaves.ToString();
    }

    public void SumarItems(int puntos)
    {
        cantidadItems += puntos;
        TextContadorItems.text = cantidadItems.ToString();
    }

    public void SumarLlaves(int puntos)
    {
        cantidadLlaves += puntos;
        TextContadorLlaves.text = cantidadLlaves.ToString();
    }

    public int GetCantidadItems()
    {
        return cantidadItems;
    }

    public int GetCantidadLlaves()
    {
        return cantidadLlaves;
    }
    
    public void ResetearPuntos()
    {
        cantidadItems = 0;
        cantidadLlaves = 0;
        ActualizarUI();
    }

    private void ActualizarUI()
    {
        TextContadorItems.text = cantidadItems.ToString();
        TextContadorLlaves.text = cantidadLlaves.ToString();
    }
}
