using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject objetoAInstanciar;
    public float speed;
    private Animator animator;
    int aux = 0;
    bool band = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.zero;
        if (aux == 1 && band == true) {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }else{
            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);
            
        }

        Debug.Log("Aux: " + aux);
        Debug.Log("Band:" + band);
        GetComponent<Rigidbody2D>().velocity = speed * dir;
    }
    public void CrearObjetoEnPosicionDelJugador()
    {
        // Obten la posición actual del jugador.
        Vector3 posicionDelJugador = transform.position;

        // Crea el objeto en la posición del jugador.
        Instantiate(objetoAInstanciar, posicionDelJugador, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "ObjetoDetecte") {
            band = true;
        }else {
            band = false;
        }
        if (other.gameObject.name == "Inicio") {
            aux = 1; 
        }
        if (other.gameObject.name == "Pillar Preg 1") {
            aux = 2;
            
        }
    }
    
}
