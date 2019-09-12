using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieOP : MonoBehaviour
{
    public CosasZombie datosZombi;
    int cambimov;
    void Awake()
    {
        datosZombi.colorEs = (CosasZombie.ColorZombie)Random.Range(0, 3);
        int dargusto = Random.Range(0, 5);
        datosZombi.sabroso = (CosasZombie.Gustos)dargusto;
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
        datosZombi.condicion = (CosasZombie.Estados)0;
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
            transform.position += direction * 0.1f;
        }
        else if (distanciajugador <= 3.0f)
        {
            direction = Vector3.Normalize(JugadorObjeto.transform.position - transform.position);
            transform.position += direction * 0.1f;

        }
        else // no hay un ciudadano cerca
        {
            switch (datosZombi.condicion)
            {
                case CosasZombie.Estados.Idle:
                    transform.position += new Vector3(0, 0f, 0);
                    break;
                case CosasZombie.Estados.Moving:
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

                case CosasZombie.Estados.Rotating:
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
            datosZombi.condicion = (CosasZombie.Estados)Random.Range(0, 3);
            yield return new WaitForSeconds(3);

            if (datosZombi.condicion == (CosasZombie.Estados)0)
            {
                datosZombi.condicion = (CosasZombie.Estados)1;
                cambimov = Random.Range(0, 3);
            }
            else if (datosZombi.condicion == (CosasZombie.Estados)1)
            {
                datosZombi.condicion = (CosasZombie.Estados)2;
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

    public enum Estados
    {
        Idle,
        Moving,
        Rotating
    };
    public Estados condicion;

    public enum ColorZombie
    {
        magenta,
        green,
        cyan
    };
    public ColorZombie colorEs;
}


