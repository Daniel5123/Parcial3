using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Lesson", menuName = "ScriptableObject/NeeLesson", order = 1)]

//La clase Leccion pasa como un scriptable object en Unity.
public class Leccion : ScriptableObject
{
    
    [Header("GameObject Configuration")]
    //Dice en que leccion estas.
    public int Lesson = 0;


    [Header("Lesson Quest Configuration")]
    public List<Subject> leccionList;
}