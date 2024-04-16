using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LessonContainer : MonoBehaviour
{
    [Header("GameObject Configuration")]
    public int Lection = 0;
    public int CurrentLession = 0;
    public int TotalLessons = 0;
    public bool AreAllLessonsComplete = false;

    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;
    

    [Header("Lesson Data")]
    public ScriptableObject LessonData;
    public string lessonName;

    public void Start()
    {
        //Actualiza la interfaz con la información sobre la lección actual
        if (lessonContainer != null)
        {
            OnUpdateUI();
        }
        //Si es nulo se manda un mensaje a la consola
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables del tipo GameObject LessonContainer");
        }
    }

    //actualiza la interfaz de usuario
    public void OnUpdateUI()
    {
        //Verifica si StageTitle o LessonStage y TMP_Text son nulos.
        if (StageTitle != null || LessonStage != null)
        {
            //Se actualiza el texto de StageTitle y LessonStage 
            StageTitle.text = "Leccion " + Lection;
            LessonStage.text = "Leccion " + CurrentLession + " de " + TotalLessons;
        }
        //Si los objetos son nulos se manda un mesnaje a la consola.
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo TMP_Text");
        }
    }

    // Este metodo activa y desactiva el LessonContainer
    public void EnableWindow()
    {
        
        OnUpdateUI();

        if (lessonContainer.activeSelf)
        {
            //Desactiva el objecto si está activo.
            lessonContainer.SetActive(false);
        }
        else
        {
            //Activa el objeto si está desactivado.
            lessonContainer.SetActive(true);
            //Se instancia SetSelectedLesson para poder usar el JSON
            MainSccript.Instance.SetSelectedLesson(lessonName);
        }
    }
}
