using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Npcstate
{
    public class NpcEstado : MonoBehaviour
    {
        //public Snpc.NpcStatado states;
        int cambimov;
        //public float speeeed;
        //public float rot;
        public void Statemovi()
        {
            switch(condicion)
            {
                case Estados.Idle:
                    transform.position += new Vector3(0, 0f, 0);
                    break;
                case Estados.Moving:
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

                case Estados.Rotating:
                    transform.eulerAngles += new Vector3(0, 0.5f, 0);

                    break;

                default:
                    break;
            }
        }
        IEnumerator Cambioestado()
        {
            while (true)
            {
                condicion = (Estados)Random.Range(0, 3);
                yield return new WaitForSeconds(3);

                if (condicion == (Estados)0)
                {
                    condicion = (Estados)1;
                    cambimov = Random.Range(0, 3);
                }
                else if (condicion == (Estados)1)
                {
                    condicion = (Estados)2;
                }

            }


        }
        public enum Estados
        {
            Idle,
            Moving,
            Rotating
        };
        public Estados condicion;
        //public struct Snpc
        //{
        //    public int age;
        //    public float speed;

        //    public enum NpcStatado
        //    {
        //        idle,
        //        moving,
        //        rotating
        //    }
        //    public NpcStatado estado;
        //}

    }
}

