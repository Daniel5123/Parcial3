using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    public int OptionID;
    public string OptionName;

    void Start()
    {
        //optioName es llamado desde el inicio para que no tenga error
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Metodo que actualiza el texto
    public void UpdateText()
    {
        //Se actualiza el texto
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }


    //Al presionar un boton llama a la UI para verificar la respuesta correcta
    public void SelectOption()
    {
        //Se verifica si la respeusta es correcta
        LevelManager.Instance.SetPlayerAnswer(OptionID);

        //Se verifica si el boton fue seleccionado o no
        LevelManager.Instance.CheckPlayerState();
    }
}
