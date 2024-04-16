using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    

    [Header("Level Data")]
    public SubjectContainer subject;

    [Header("Succes")]
    public GameObject Retry;

    [Header("User interface")]
    public TMP_Text textQuestion;
    public TMP_Text textGood;
    
    public List<Option> Question;
    public GameObject CheckButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer = 9;

    [Header("Current Lesson")]
    public Subject currentLesson;

  
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

    //Inicia el programa y caarga las preguntas
    void Start()
    {
        subject = SaveSystem.Instance.subject;

        //Se establece cuantas preguntas son
        questionAmount = subject.leccionList.Count;
        // Cargar la primera pregunta y las actualiza
        LoadQuestion();

        //Se verifica si tiene la opcion seleccionada
        CheckPlayerState();
    }


    //Carga las preguntas y respuestas
    private void LoadQuestion()
    {
        if (currentQuestion < questionAmount)
        {
            //Carga la leccion actual
            currentLesson = subject.leccionList[currentQuestion];

            //Carga la pregunta
            question = currentLesson.lessons;

            //Se verifica la respuesta
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];

            //Carga la pregunta en UI
            textQuestion.text = question;

            //Se actualiza al responder la pregunta
            for (int i = 0; i < currentLesson.options.Count; i++)
            {
                Question[i].GetComponent<Option>().OptionName = currentLesson.options[i];
                Question[i].GetComponent<Option>().OptionID = i;
                Question[i].GetComponent<Option>().UpdateText();
            }
        }
        else
        {

            Debug.Log("Se acabo");
            //Al llegar al final se ejecuta el mensaje
          
            Retry.SetActive(true);
        }
    }


    //Carga la siguiente pregunta
    public void NextQuestion()
    {
        //Se verifica si se esta interactuando los botones
        if (CheckPlayerState())
        {
            if (currentQuestion < questionAmount)
            {
                //Se revisa si es correcta la respeusta
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                //Se revisa la respuesta en la UI
                AnswerContainer.SetActive(true);

                //Se revisa si la respuesta es correcta
                if (isCorrect)
                {
                    //Cambia de color a verde si es verdadera
                    AnswerContainer.GetComponent<Image>().color = Green;
                    //Se envia un mensaje diciendo que es correcto
                    textGood.text = "Respuesta correcta. " + question + ": " + correctAnswer;
                }
                else
                {
                    //Cambai de color a rojo si es falso
                    AnswerContainer.GetComponent<Image>().color = Red;
                    textGood.text = "Respuesta incorrecta. " + question + ": " + correctAnswer;
                    //Se envia mensaje de Respuesta Incorrecta
                    
                }

                currentQuestion++;
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));
                answerFromPlayer = 9;
                
            }
            else
            {
                //Cambia la escena
            }
        }
    }

    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        //Ajusta el tiempo para la respuesta
        yield return new WaitForSeconds(2.5f);

        AnswerContainer.SetActive(false);

        //Cargar la nueva pregunta
        LoadQuestion();

        //Verifica si se esta interactuado con los botones
        CheckPlayerState();
    }

    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

    //Verifica si se esta interactuado con los botones
    public bool CheckPlayerState()
    {
        //Si se seleccionan los botones cambian de color.
        if (answerFromPlayer != 9)
        {
            // Si se interactua se pone de color gris
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.grey;
            return true;
        }
        else
        {
            // Si no se interactua se pone de color blanco
            CheckButton.GetComponent<Button>().interactable = false;
            CheckButton.GetComponent<Image>().color = Color.white;
            return false;
        }
    }
}
