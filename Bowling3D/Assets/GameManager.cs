using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public int points1;
    public int tiros = 1;
    public int PuntosTotal;

    public Text score;
    public Text contTiros;


    //Variable donde guardamos el caminio hacia el txt.
    string filePath;

    //Varialble Json
    string jsonString;

    void Awake()
    {
        // Leyendo el fichero. Busca el camino hacia /Score.Text
        filePath = Application.dataPath + "/Score.txt";
        //Lee la ficha.
        jsonString = File.ReadAllText(filePath);
        Puntos puntos = JsonUtility.FromJson<Puntos>(jsonString);

        //Se utiliza el file.Weritealltext para escribirlo.
        File.WriteAllText(filePath, jsonString);

    }

    private void Start()
    {
        PuntosTotal = points1;
        score.text = PuntosTotal.ToString("PUNTOS: " + points1);
        contTiros.text = tiros.ToString("TIROS: " + tiros);
    }

    //Para guardar/cargar datos en json hay que crear una clase si o si con [System.Serializable
[System.Serializable]
    public class Puntos
    {

        public int puntuacion;
        public int puntuacionMaxima;

        public override string ToString()
        {
            return string.Format("[Score]", puntuacion, puntuacionMaxima);
        }
       
    }
 
    public void AddPoint()
    {
        Puntos puntos = JsonUtility.FromJson<Puntos>(jsonString);
        points1++;
        score.text = points1.ToString("PUNTOS: " + points1);
        //puntos.puntuacion = 30;
        jsonString = JsonUtility.ToJson(puntos);
    }


    public void ContarTiros()
    {
        tiros = +1;
        contTiros.text = tiros.ToString("TIROS: " + tiros);
    }
   

}



