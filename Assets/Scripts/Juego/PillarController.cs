using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    public int aux;
    public TMP_Text idPillar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        if (aux == 1)
    //        {
    //            //Collider2D colliderObjetoPregunta = collision.collider;
    //           // if (colliderObjetoPregunta != null)
    //           // {
    //                if (idPillar.text == "1")
    //                {
    //                    collision.collider.isTrigger = true;
    //                }
    //          //  }
    //        }
    //        if (aux == 2)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    collision.collider.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 3)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 4)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 5)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 6)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 7)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 8)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 9)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 10)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 11)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 12)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 13)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 14)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 15)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 16)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 17)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 18)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 19)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //        if (aux == 20)
    //        {
    //            Collider2D colliderObjetoPregunta = collision.collider;
    //            if (colliderObjetoPregunta != null)
    //            {
    //                if (idPillar.text == "1")
    //                {
    //                    colliderObjetoPregunta.isTrigger = true;
    //                }
    //            }
    //        }
    //    }
    //    idPillar.text = "0";
    //}
}
