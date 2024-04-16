using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public Subject data;
    public SubjectContainer subject;  
    public static SaveSystem Instance;

    private void Awake()
    {
       //Se verifica si la instancia existe
        if (Instance != null)
        {
            return;
        }
        //Si no existe se crea una nueva
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //Se llama a la funcion SaveToJSON
        SaveToJSON("LeccionYeah.json", data);

        //LoadFromJSON guarda los objetos en SubjectContainer
        subject = LoadFromJSON<SubjectContainer>(PlayerPrefs.GetString("SelectedLesson"));
    }


    public void SaveToJSON(string _fileName, object _data)
    {
        if (_data != null)
        {
            string JSON_data = JsonUtility.ToJson(_data, true);

            //Se revisa si el JSOn tiene contenido
            if (JSON_data.Length != 0)
            {
                //Se manda un mesnaje a la consola si el JSON string tiene la información de JSON_data
                Debug.Log("JSON STRING : " + JSON_data);

                //Se crea el nombre del archivo 
                string filename = _fileName + ".Json";

                //Se construye la ruta donde se guaran los JSON
                string filePath = Path.Combine(Application.dataPath + "/StreamingAssets/JSONS/", filename);

                File.WriteAllText(filePath, JSON_data);

                //Se envia un mensaje diciendo que se guardaron los JSON
                Debug.Log("JSON almacenando en la dirección : " + filePath);
            }
            //Sí no tiene nada que guardar manda mensaje a la consola
            else
            {
                Debug.Log("Error - fileSystem: JSON_data is empty, check for local variable [string JSON_data]");
            }
        }
        //Sí no tiene nada que guardar manda mensaje a la consola
        else
        {
            Debug.LogWarning("Error: _Data is null, checa el parametro [object _data]");
        }
    }

    //carga los datos guardados
    public T LoadFromJSON<T>(string _fileName) where T : new()
    {
        //Se crea una instancia
        T Dato = new T();

        //Se construye la ruta 
        string path = Application.dataPath + "/StreamingAssets/JSONS/" + _fileName + ".json";
        
        //Se almacenan los datos leidos
        string JSON_data = "";

        //Se verifica si exite la ruta de los JSon
        if (File.Exists(path))
        {
            //Se verifica si el archivo JSON especificado existe 
            JSON_data = File.ReadAllText(path);

            //Se manda un mensaje si JSON string tiene el contenido
            Debug.Log("JSON STRING: " + JSON_data);
        }
        
        if (JSON_data.Length != 0)
        {
            JsonUtility.FromJsonOverwrite(JSON_data, Dato);
        }

        // Si está vacia se manda un mensaje a la consola
        else
        {
            Debug.LogWarning("ERROR _ FyleSystem: JSON_data is empty, check for local variable [string JSON_data]");
        }
        return Dato;
    }

}
