using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class Generador : MonoBehaviour
{
    public GameObject ZombieMesh;
    public GameObject Gente;
    public GameObject Hero;
    CosasZombie datoZombi;
    CosasCiudadanos datoCiudadanos;
    readonly int minimo;
    const int maximo = 25;
    int cantbody;
    public Text enemy;
    public Text ally;



    System.Random rn = new System.Random();

    public Generador()
    {
        minimo = rn.Next(5, 15);    //rango de creación
        
    }

    void Start()
    {                                 // generador de NPC
        cantbody = rn.Next(minimo, maximo);
        for (int i = 0; i < cantbody; i++)
        {
            if (rn.Next(0,2)==0)
            {                               // generador de zombis
                ZombieMesh = GameObject.CreatePrimitive(PrimitiveType.Cube);
                ZombieMesh.AddComponent<ZombieOP>();

                datoZombi = ZombieMesh.GetComponent<ZombieOP>().datosZombi;
                switch (datoZombi.colorEs)
                {
                    case CosasZombie.ColorZombie.magenta:
                        ZombieMesh.GetComponent<Renderer>().material.color = Color.magenta;

                        break;
                    case CosasZombie.ColorZombie.green:
                        ZombieMesh.GetComponent<Renderer>().material.color = Color.green;

                        break;
                    case CosasZombie.ColorZombie.cyan:
                        ZombieMesh.GetComponent<Renderer>().material.color = Color.cyan;
                        break;
                }


                Vector3 pos = new Vector3(rn.Next(-10, 10), 0, rn.Next(-10, 10));
                ZombieMesh.transform.position = pos;
                ZombieMesh.AddComponent<Rigidbody>();
                ZombieMesh.name = "Zombi";
            }
            else // generador de ciudadanos \\
            {
                Gente = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Gente.AddComponent<CiudadanoOp>();
                Vector3 po = new Vector3(rn.Next(-20, 10), 0, rn.Next(10, 10));
                Gente.transform.position = po;
                Gente.AddComponent<Rigidbody>();
                Gente.name = "Gente";
            }
        }
       
        // generador hero \\
        Hero = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Hero.AddComponent<MovimientoTeclado>();
        Hero.AddComponent<Hero>();
        Hero.AddComponent<Camera>();
        Hero.AddComponent<Rigidbody>();
        Hero.name = "Hero";

            
       int numzombie = 0;
       int numaldeanos = 0;

       
        foreach (ZombieOP enemy in Transform.FindObjectsOfType<ZombieOP>())
        {
           numzombie++;
        }

        foreach (CiudadanoOp ally in Transform.FindObjectsOfType<CiudadanoOp>())
        {
            numaldeanos++;
        }
        Debug.Log("contador"+numzombie);
        ally.text="aldeanos: "+numaldeanos;
        enemy.text="zombies: "+numzombie;
      
    }

}
