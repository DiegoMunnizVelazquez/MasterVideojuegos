using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    /// <summary>
    /// Estados posibles de la puerta
    /// </summary>
    public enum State { CLOSED, OPEN }
    /// <summary>
    /// animaci�n de abrir la puerta
    /// </summary>
    public string m_open;
    /// <summary>
    /// animaci�n de cerar la puerta
    /// </summary>
    public string m_close;
    /// <summary>
    /// GameObject que contiene el componente Animation con las animaciones de la puerta
    /// </summary>
    public Animation m_animation;
    /// <summary>
    /// GameObject donde est� el audio source con el sonido de la puerta
    /// </summary>
    public AudioSource m_audio;
    /// <summary>
    /// Duraci�n de la animaci�n
    /// </summary>
    public float animationDuration;

    /// <summary>
    /// Tiempo de animaci�n restante
    /// </summary>
    private float m_remainingTime;

    /// <summary>
    /// Indica si el jugador est� o no dentro del trigger
    /// </summary>
    private bool m_playerInside;

    /// <summary>
    /// Estado actual de la puerta
    /// </summary>
    private State m_state = State.CLOSED;

    // TO-DO 1: Definimos las funciones OnTriggerEnter y OnTriggerExit y modificamos la variable m_playerInside si hemos detectado al player

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_playerInside = false;
        }
    }

    public State DoorState
    {
        get { return m_state; }
    }

    public bool IsClosing()
	{
        return m_state == State.CLOSED && m_remainingTime > 0.0f;
	}

    private void Update()
    {
        // TO-DO 3: No hacemos nada si la puerta est� abri�ndose o cerr�ndose

        m_remainingTime = Mathf.Max(m_remainingTime - Time.deltaTime, 0.0f);
        if (m_remainingTime > 0.0f)
        {
            return;
        }


        // TO-DO 2: Detectamos cambios de estado seg�n el estado de la puerta y seg�n loq ue nos dice la variable m_playerInside

        if (DoorState == State.CLOSED)
        {
            if (m_playerInside)
            {
                m_remainingTime = animationDuration;
                m_state = State.OPEN;
                m_animation.Play(m_open);
                m_audio.Play();
            }
        }
        else if (DoorState == State.OPEN)
        {
            if (!m_playerInside)
            {
                m_remainingTime = animationDuration;
                m_state = State.CLOSED;
                m_animation.Play(m_close);
                m_audio.Play();
            }
        }
    }
}