using System.Collections;
using System.Collections.Generic;
using UnityEngine;

        public class CiudadanoOp : MonoBehaviour
        {
            public CosasCiudadanos datoCiudadanos;

            void Awake()
            {
                int darnombre = Random.Range(0, 20);
                datoCiudadanos.genteNombres = (CosasCiudadanos.Nombres)darnombre;
                int daredad = Random.Range(15, 100);
                datoCiudadanos.edadgente = (CosasCiudadanos.Edad)daredad;
            }
           public GameObject NPCGENTE;
             void Start()
             {
                GameObject[] allgameobtects = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
                foreach (GameObject aGameObject in allgameobtects)
                {
                    Component aComponent = aGameObject.GetComponent(typeof(ZombieOP));
                    if (aComponent != null)
                    {
                        NPCGENTE = aGameObject;
                    }
                }
             }
            Vector3 direc;
            void OnDrawGizmos()
            {
                Gizmos.DrawLine(transform.position, transform.position + direc);
            }
            
            void Update()
            {
                Vector3 mivector = NPCGENTE.transform.position - transform.position;
                float distjugador = mivector.magnitude;

                if (distjugador >= 3.0f)
                {
                    direc = Vector3.Normalize(NPCGENTE.transform.position + transform.position);
                    transform.position += direc * 0.1f;
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

            public enum Edad
            {
                edad
            }
            public Edad edadgente;
        }

    

