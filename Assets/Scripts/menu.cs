using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private Muerte muerte;

    private void Start()
    {
        muerte = GameObject.FindGameObjectWithTag("Player").GetComponent<Muerte>();
        muerte.kill += AbrirMenu;
    }

    private void AbrirMenu(object sender, EventArgs e)
    {
        menu.SetActive(true);
    }

    public void reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
