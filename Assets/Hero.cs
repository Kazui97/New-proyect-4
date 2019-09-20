using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.ally;
using Npc.enemy;
using Npc;



public class Hero : MonoBehaviour
{
    CosasZombie datosZombi;
    CosasCiudadanos datosciudadanos;
    
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
            //datosZombi = collision.gameObject.GetComponent<ZombieOP>().datosZombi;
            //Debug.Log("  waaarrr " + " quiero comer " + datosZombi.sabroso);
        }


        if (collision.transform.name == "Gente")
        {
            datosciudadanos = collision.gameObject.GetComponent<CiudadanoOp>().datoCiudadanos;
            Debug.Log("Hola soy " + datosciudadanos.genteNombres + " y tengo " + datosciudadanos.edadgente);
        }
    }
}
