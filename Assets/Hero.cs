using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.ally;
using Npc.enemy;



public class Hero : MonoBehaviour
{
    Dzombi datosZombi;
    
    //CosasCiudadanos datoCiudadanos;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)          // colision de zombi y aldeanos 
    {
        if (collision.transform.name == "Zombi")
        {
            datosZombi = collision.gameObject.GetComponent<ZombieOP>().dzombi;
            Debug.Log("  waaarrr " + " quiero comer " + datosZombi.sabroso);
        }


        //if (collision.transform.name == "Gente")
        //{
        //    datoCiudadanos = collision.gameObject.GetComponent<CiudadanoOp>().datoCiudadanos;
        //    Debug.Log("Hola soy " + datoCiudadanos.genteNombres + " y tengo " + datoCiudadanos.edadgente );
        //}
    }
}
