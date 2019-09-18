 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.enemy;




namespace Npc
{
    namespace ally
    {
        public class CiudadanoOp : NpcEstado
        {
            public CosasCiudadanos datoCiudadanos;
            public GameObject ZombieMesh;
            CosasZombie zombicosas;
            

            void Awake()
            {
                int darnombre = Random.Range(0, 20);
                datoCiudadanos.genteNombres = (CosasCiudadanos.Nombres)darnombre;
                datoCiudadanos.edadgente = Random.Range(15, 100);
                
            }

            void Start()
            {
               
                StartCoroutine("Cambioestado");
            }
            Vector3 direc;
            void OnDrawGizmos()
            {
                Gizmos.DrawLine(transform.position, transform.position - direc);
            }


            public void OnCollisionEnter(Collision collision)
            {
                if (collision.transform.name == "Zombi")
                {
                    transform.name = "Zombi";
                    this.gameObject.AddComponent<ZombieOP>();
                   
                    Destroy(this.gameObject.GetComponent<CiudadanoOp>());
                   
                    
                    //Destroy(FindObjectOfType<CiudadanoOp>().gameObject);
                    //ZombieMesh = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //ZombieMesh.name = "Nuevo zombi";
                    //ZombieMesh.AddComponent<ZombieOP>();
                    //ZombieMesh.AddComponent<Rigidbody>();
                    //zombicosas = ZombieMesh.GetComponent<ZombieOP>().datosZombi;     ///----------- falta color y todos lo de mas :,v -------------\\\
                    ////zombicosas = collision.gameObject.GetComponent<ZombieOP>().datosZombi;
                    ////Debug.Log("  waaarrr " + " quiero comer " + zombicosas.sabroso);

                }
            }


            
            void Update()
            {
                float distmin = 5;                          ///-------------corre de los zombie------------\\\
                GameObject zombimascerca = null;

                foreach (var item in FindObjectsOfType<ZombieOP>())
                {
                    float tempdist = Vector3.Distance(this.transform.position, item.transform.position);
                    if (tempdist <= distmin)
                    {
                        distmin = tempdist;
                        zombimascerca = item.gameObject;
                    }
                }

                if (zombimascerca != null) ///-----si hay zombie cerca----\\\
                {
                    direc = Vector3.Normalize(zombimascerca.transform.position + transform.position);
                    transform.position += direc * 0.1f;
                }
                else
                {
                    Statemovi();                   
                }

            }
            

        }




        public struct CosasCiudadanos
        {
            public enum Nombres
            {
                stubbs,
                rob,
                toreto,
                pequeñotim,
                doncarlos,
                carlosII,
                carlosI,
                sergio,
                stevan,
                tutiaentanga,
                panzerottedelsena,
                cj,
                haytevoysampedro,
                sanpeludo,
                alexisdelpeludoII,
                putoalexis,
                jason,
                andrey,
                atreus,
                artion,
                kratos,
                zeus,
                loki,
                sam,
                wilson,
                elbrayan,
                venites,
                sampedro,
            }
            public Nombres genteNombres;

           
            public int edadgente;

            public static explicit operator CosasZombie(CosasCiudadanos dgente)
            {
                CosasZombie Szombie = new CosasZombie();
                Szombie.edadzombi = dgente.edadgente;
                return Szombie;
            }
        }
    }
}

   

    

