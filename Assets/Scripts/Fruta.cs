using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    public GameObject prefabFrutaCortada; // objeto que contiene el prefab de fruta cortada que le pasemos
    public void CrearFrutaCortada()
    {
        GameObject inst=(GameObject)Instantiate(prefabFrutaCortada, transform.position,transform.rotation); //creamos el objeto fruta cortada, en la posicion donde estaba la fruta sin cortar y con rotacion
        
        Rigidbody[] rbDeCortados= inst.transform.GetComponentsInChildren<Rigidbody>(); //creo array de rigisbody de las dos partes de la fruta cortada, y los obtengo con este metodo
        //recorro el array para que cuando se cree la fruta cortada, le asignemos una rotacion y una fuerza de explosion
        foreach(Rigidbody r in rbDeCortados)
        {
            r.transform.rotation = Random.rotation; //rotacion aleatoria
            r.AddExplosionForce(Random.Range(500,1000),transform.position,5f);//fuerza de explosion aleatoria, posicion de la fruta, radio de 5f
        }

        FindObjectOfType<GameManager>().AumentarPuntaje();
        Destroy(inst.gameObject,5); //destruye naranjas cortadas
        Destroy(gameObject); //destruimos la fruta sin cortar que tenga este script
    }


    //cuanod la espada colisione con la fruta se corte
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Espada e= collision.GetComponent<Espada>();
        //si la espada nocolisiona

        if (!e) //si colisiona
        {
            return;
        }
        CrearFrutaCortada();
    }
}
