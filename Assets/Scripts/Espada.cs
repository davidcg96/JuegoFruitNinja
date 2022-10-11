using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    public float VelocidadMin = 0.1f; //velocidad minima del dedo
    private Vector3 UltimaPosDedo; //pos del dedo ultima
    private Vector3 VelocidadDedo; //velocidad del dedo
    private Collider2D col; //collider de la espada pa ON/OFF

    private Rigidbody2D rb; //rigidbody de la espada
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //le asignamos el rigidbody
        col=GetComponent<Collider2D>(); //le asignamos el collider
    }

    // Update is called once per frame
    void Update()
    {
        col.enabled = SeMueveElDedo();
        AsociarEspadaAlMouse();
    }

    //asociar la espada con el raton
    private void AsociarEspadaAlMouse()
    {
        var mousePosicion=Input.mousePosition;
        mousePosicion.z = 5; //posicion de la camara, bloqueamos el eje Z ya que la espada trabaja en 2D
        rb.position = Camera.main.ScreenToWorldPoint(mousePosicion); //asocia el mouse con la espada
    }
     private bool SeMueveElDedo()
    {
        Vector3 posDedoActual=transform.position; //asignamos la pos de la espada
        float desplazamiento = (UltimaPosDedo-posDedoActual).magnitude;
        UltimaPosDedo=posDedoActual;
        if (desplazamiento>VelocidadMin)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
