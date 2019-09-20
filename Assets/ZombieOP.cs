using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Npc.ally;




namespace Npc
{
    namespace enemy
    {
        public class ZombieOP : NpcEstado
        {           
            public CosasZombie datosZombi;                                // ----------- struc de gustos y color ------------- \\
            public GameObject textoz;
            void Awake()
            {
                datosZombi.colorEs = (CosasZombie.ColorZombie)Random.Range(0, 3);
                int dargusto = Random.Range(0, 5);
                datosZombi.sabroso = (CosasZombie.Gustos)dargusto;
                datosZombi.edadzombi = Random.Range(15, 101);
                textoz = GameObject.Find("Main Camera");
            }
            public void cam ()
            {
                //datosZombi.colorEs = (CosasZombie.ColorZombie)Random.Range(0, 3);
               // int Z_Ggusto = Random.Range(0, 5);
                //datosZombi.sabroso = (CosasZombie.Gustos)Z_Ggusto;
                int cambiocolor = Random.Range(1,3);
                 switch (cambiocolor)
                {
                    case 1:
                        gameObject.GetComponent<Renderer>().material.color = Color.magenta;

                        break;
                    case 2:
                        gameObject.GetComponent<Renderer>().material.color = Color.green;

                        break;
                    case 3:
                        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                        break;
                }
            }
            Vector3 direction;
            void OnDrawGizmos()
            {
                Gizmos.DrawLine(transform.position, transform.position + direction);
            }


            public GameObject JugadorObjeto;
            public GameObject NpcGente;
            void Start()
            {
                
               StartCoroutine("Cambioestado");

                JugadorObjeto = FindObjectOfType<Hero>().gameObject;


            }         
            
            

            void Update()
            {

                float distanciaMin = 5;
                GameObject ciudadanoMasCercano = null;

                foreach (var ciudadano in FindObjectsOfType<CiudadanoOp>())
                {
                    float tempDist = Vector3.Distance(this.transform.position, ciudadano.transform.position);

                    if (tempDist < distanciaMin)
                    {
                        distanciaMin = tempDist;
                        ciudadanoMasCercano = ciudadano.gameObject;
                    }
                }

                Vector3 mivector = JugadorObjeto.transform.position - transform.position;
                float distanciajugador = mivector.magnitude;

                if (ciudadanoMasCercano != null) //sigbnifica que hay un ciudadano cerca 
                {
                    direction = Vector3.Normalize(ciudadanoMasCercano.transform.position - transform.position);
                    transform.position += direction * 2.5f / datosZombi.edadzombi;
                }
                else if (distanciajugador <= 5.0f)
                {
                    direction = Vector3.Normalize(JugadorObjeto.transform.position - transform.position);
                    transform.position += direction * 0.1f;
                    Debug.Log("waaarrrr "+ "quiero comer "+ datosZombi.sabroso + "" + datosZombi.edadzombi);
                    textoz.GetComponent<Generador>().Ztext.text = "waaarrrr "+ "quiero comer "+ datosZombi.sabroso;


                }
                 /*else if (distanciajugador >= 3.0f)
                    {
                         Debug.Log("");
                    }*/
                else // no hay un ciudadano cerca
                {
                    Statemovi();
                    
                }

            }

        }
        
    }
   
    public struct CosasZombie
    {
        
        public enum Gustos
        {
            Brazos,
            Piernas,
            Huesitos,
            Ojito,
            corazoncito
        };
        public Gustos sabroso;       

        public enum ColorZombie
        {
            magenta,
            green,
            cyan
        };
        
        public ColorZombie colorEs;

        public int edadzombi;
    }
}


   






