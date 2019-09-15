using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npc.ally;



namespace Npc
{
    namespace enemy
    {
        public class ZombieOP : Npcstate.NpcEstado
        {
            public CosasZombie szombie = new CosasZombie();
            public Dzombi dzombi = new Dzombi();                                // ----------- enum de gustos y color ------------- \\
            public Snpc datosZombi;
            int cambimov;
            public int dargusto;
            void Awake()
            {
                dzombi.colorEs = (Dzombi.ColorZombie)Random.Range(0, 3);                
                dargusto = Random.Range(0, 5);
                dzombi.sabroso = (Dzombi.Gustos)dargusto;
            }
            public void cam ()
            {
                
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
                datosZombi.estado = (Snpc.NpcStatado)0;
                StartCoroutine("Cambioestado");

                JugadorObjeto = FindObjectOfType<Hero>().gameObject;


            }
            public void OnCollisionEnter(Collision collision)
            {
                if (collision.gameObject.GetComponent<CiudadanoOp>())
                {
                    collision.gameObject.AddComponent<ZombieOP>().szombie = (ZombieOP.CosasZombie)collision.gameObject.GetComponent<CiudadanoOp>().sciudadano;
                    collision.gameObject.AddComponent<ZombieOP>().dargusto = dargusto;
                    Destroy(collision.gameObject.GetComponent<CiudadanoOp>());
                    collision.transform.name = "new zombi";


                }
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
                    transform.position += direction * 0.1f;
                }
                else if (distanciajugador <= 3.0f)
                {
                    direction = Vector3.Normalize(JugadorObjeto.transform.position - transform.position);
                    transform.position += direction * 0.1f;

                }
                else // no hay un ciudadano cerca
                {
                    switch (datosZombi.estado)
                    {
                        case Snpc.NpcStatado.idle:
                            transform.position += new Vector3(0, 0f, 0);
                            break;
                        case Snpc.NpcStatado.moving:
                            if (cambimov == 0)
                            {
                                transform.position += new Vector3(0, 0, 0.03f);
                            }
                            else if (cambimov == 1)
                            {
                                transform.position -= new Vector3(0, 0, 0.03f);
                            }
                            else if (cambimov == 2)
                            {
                                transform.position -= new Vector3(0.03f, 0, 0);
                            }
                            else if (cambimov == 3)
                            {
                                transform.position += new Vector3(0.03f, 0, 0);
                            }
                            break;

                        case Snpc.NpcStatado.rotating:
                            transform.eulerAngles += new Vector3(0, 0.5f, 0);

                            break;

                        default:
                            break;

                    }
                }



            }
            IEnumerator Cambioestado()
            {
                while (true)
                {
                    datosZombi.estado = (Snpc.NpcStatado)Random.Range(0, 3);
                    yield return new WaitForSeconds(3);

                    if (datosZombi.estado == (Snpc.NpcStatado)0)
                    {
                        datosZombi.estado = (Snpc.NpcStatado)1;
                        cambimov = Random.Range(0, 3);
                    }
                    else if (datosZombi.estado == (Snpc.NpcStatado)1)
                    {
                        datosZombi.estado = (Snpc.NpcStatado)2;
                    }

                }


            }
            public struct CosasZombie
            {
                public Snpc snpc;   
            }
           
        }
        public struct Dzombi
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
        }
    }


    //    public struct CosasZombie
    //    {
    //        public enum Gustos
    //        {
    //            Brazos,
    //            Piernas,
    //            Huesitos,
    //            Ojito,
    //            corazoncito
    //        };
    //        public Gustos sabroso;

    //        public enum Estados
    //        {
    //            Idle,
    //            Moving,
    //            Rotating
    //        };
    //        public Estados condicion;

    //        public enum ColorZombie
    //        {
    //            magenta,
    //            green,
    //            cyan
    //        };
    //        public ColorZombie colorEs;
    //    }
    //}
}




