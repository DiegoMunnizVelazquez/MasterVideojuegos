using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDamage : MonoBehaviour
{
    public Door m_door;
    public float m_damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && m_door.IsClosing())
        {
            other.SendMessage("Damage", m_damage);
        }
    }
}

