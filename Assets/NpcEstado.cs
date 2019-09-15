using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Npcstate
{
    public class NpcEstado : MonoBehaviour
    {
        public Snpc.NpcStatado states;
        public float speeeed;
        public float rot;
        public void Statemovi()
        {
            switch(states)
            {
                case Snpc.NpcStatado.idle:
                    break;
                case Snpc.NpcStatado.moving:
                    transform.position += transform.forward * speeeed;
                    break;
                case Snpc.NpcStatado.rotating:
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + (rot), 0);
                    break;
            }
        }

        public struct Snpc
        {
            public int age;
            public float speed;

            public enum NpcStatado
            {
                idle,
                moving,
                rotating
            }
            public NpcStatado estado;
        }
        
    }
}

