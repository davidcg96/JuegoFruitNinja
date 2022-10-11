using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Espada e= collision.GetComponent<Espada>();
        if (!e)
        {
            return;
        }

        FindObjectOfType<GameManager>().AlTocarBomba();
    }
}
