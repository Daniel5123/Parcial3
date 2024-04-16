using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarLesson : MonoBehaviour
{
    public bool pasarNivel;
    public int IndiceNivel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           //Cambiara a la escena 
            CambiarNivel(IndiceNivel);
        }
        //Se cambiara de escena 
        if (pasarNivel)
        {
            CambiarNivel(IndiceNivel);
        }
    }

    // Función que cambia al numero en la escena
    public void CambiarNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }
}
