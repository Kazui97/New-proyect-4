 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CiudadanoOp : MonoBehaviour
    {
        public CosasCiudadanos datoCiudadanos;
        public GameObject ZombieMesh;
        CosasZombie zombicosas;

        void Awake()
        {
            int darnombre = Random.Range(0, 20);
            datoCiudadanos.genteNombres = (CosasCiudadanos.Nombres)darnombre;
            int daredad = Random.Range(15, 100);
            datoCiudadanos.edadgente = (CosasCiudadanos.Edad)daredad;
        }
           
            void Start()
            {
                //GameObject[] allgameobtects = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
                //foreach (GameObject aGameObject in allgameobtects)
                //{
                //    Component aComponent = aGameObject.GetComponent(typeof(ZombieOP));
                //    if (aComponent != null)
                //    {
                //        NPCGENTE = aGameObject;
                //    }
                //}
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
                Destroy(FindObjectOfType<CiudadanoOp>().gameObject);
                ZombieMesh = GameObject.CreatePrimitive(PrimitiveType.Cube);
                ZombieMesh.AddComponent<ZombieOP>();
                ZombieMesh.AddComponent<Rigidbody>();
                zombicosas = ZombieMesh.GetComponent<ZombieOP>().datosZombi;
                zombicosas = collision.gameObject.GetComponent<ZombieOP>().datosZombi;
                
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

    

