using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] 

public class SubjectContainer
{
    [Header("GameObject Configuration")]

    
    //se serializan las variables
    [SerializeField]

    //Indica el numero de lección
    public int Lesson = 0;

    [Header("Lesson Quest Configuration")]
    [SerializeField]

    //Lista que guarda las lecciones
    public List<Subject> leccionList;
}