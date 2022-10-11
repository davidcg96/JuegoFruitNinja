using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrojarFruta : MonoBehaviour
{

    public GameObject[] objetoParaArrojar; // le paso el objeto de fruta que quiero crear
    public GameObject bomba;
    public float esperaMinima=0.3f; //tiempo espera minimo para lanzar fruta
    public float esperaMaxima = 1f; //tiempo espera maximo para crear fruta
    public float fuerzaMinima = 1f; //tiempo espera minimo para lanzar fruta
    public float fuerzaMaxima = 12f; //tiempo espera maximo para crear fruta
    public Transform[] lugaresLanzamiento; //contiene todos los lugares donde se lanzan objetos

    // Start is called before the first frame update
    void Start()
    {
        //funcion que cree fruta sin parar cada x segundos
        StartCoroutine(Arrojador());//pide IEnumerator
    }

    private IEnumerator Arrojador()
    {
        //mientras se ejecute la rutina tira fruta
        while (true)
        {
            //espera una cantidad de segundos para volver a entrar
            yield return new WaitForSeconds(Random.Range(esperaMinima,esperaMaxima));

            Transform t = lugaresLanzamiento[Random.Range(0,lugaresLanzamiento.Length)]; //tomo la posicion de un lugar de lanzamiento

            GameObject go = null;

            float p = Random.Range(0,100);

            if(p<10) //10% de que slaga bomba
            {
                go = bomba; //saco bomba
            }
            else
            {
                go= objetoParaArrojar[Random.Range(0,objetoParaArrojar.Length)]; //saco cualquier fruta
            }
            GameObject fruta = Instantiate(go, t.position, t.rotation); //creo una fruta en el lugar de lanzamiento

            fruta.GetComponent<Rigidbody2D>().AddForce(t.transform.up*Random.Range(fuerzaMinima,fuerzaMaxima), ForceMode2D.Impulse); //añade al lanzador una fuerza hacia arriba para que lancen las frutas

            Destroy(fruta,5); //destruye la truta en 5 segundos
        }
    }
}
