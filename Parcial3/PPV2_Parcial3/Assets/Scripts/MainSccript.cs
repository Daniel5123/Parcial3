using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSccript : MonoBehaviour
{
    public static MainSccript Instance;
    public string SelectedLesson = "Lesson";
    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    //Selecciona la leccion que escoge el jugador
    public void SetSelectedLesson(string lesson)
    {
       
        SelectedLesson = lesson;

        PlayerPrefs.SetString("SelectedLesson", SelectedLesson);
    }


    //Al seleccionarla la opcion inicia el juego
    public void BeginGame()
    {
        //Carga la escena
        SceneManager.LoadScene("1Lesson");
    }
}
