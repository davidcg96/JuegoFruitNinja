using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [Header("elementos del puntaje")]
    public int puntaje; //variable que lleva la puntuacion
    public int mejorPuntaje;
    public Text textoPuntaje; //texto de puntuaxion
    public Text textoMejorPuntaje;

    [Header("elementos del game over")]
    public GameObject panelGameOver; //objeto para gameover
    public Text textoPuntajeFinal; //texto de puntuaxion final
    public Text textoMejorPuntajePanel; //texto de puntuaxion final panel
    public void AumentarPuntaje()
    {
        puntaje += 2; //aumentamos por 2
        textoPuntaje.text= puntaje.ToString(); //ponemos la puntuacion en el texto

        //guarda la sesiones anteriores para la mejor puntuacion
        if (puntaje > mejorPuntaje)
        {
            PlayerPrefs.SetInt("MejorPuntaje",puntaje);
            textoMejorPuntaje.text = "Mejor: "+puntaje.ToString();
            mejorPuntaje = puntaje;
        }

    }

    private void MejorPuntaje()
    {
        textoPuntajeFinal.text = "Puntaje: " + puntaje.ToString();
        textoMejorPuntajePanel.text = "Mejor Puntaje: " + mejorPuntaje.ToString();
    }
    public void AlTocarBomba()
    {
        Time.timeScale = 0; //detiene el juego
        panelGameOver.SetActive(true);//sale cuando tocas una bomba
        MejorPuntaje();
    }

    public void Awake()
    {
        panelGameOver.SetActive(false); //desactiva el panel de gameover cuando empieza el juego
        mejorPuntaje = PlayerPrefs.GetInt("MejorPuntaje");
        textoMejorPuntaje.text = "Mejor: " + mejorPuntaje;
    }
    public void Reiniciar()
    {
        //reseteamos la puntuacion, los textos, ponemos el tiempo a 0, quitamos el panel de game over
        puntaje = 0;
        textoPuntaje.text = puntaje.ToString();
        Time.timeScale = 1;
        panelGameOver.SetActive(false);
        //pongo a los prefab de las frutas y bomba una etiqueta interactivo y recorro las etiquetas para eliminar todas las que habbia cunado perdi
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactivo"))
        {
            Destroy(g);
        }
    }
}
