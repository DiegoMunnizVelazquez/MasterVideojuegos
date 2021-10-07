using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour {


    public Health m_health;

    private Slider m_slider;

	// Use this for initialization
	void Start () {

        //TO-DO 1 Cargar HealthSlider y configurarlo con valores por defecto

        m_slider = GetComponent<Slider>();

        if (m_slider != null)
        {
            m_slider.minValue = 0f;
            m_slider.maxValue = m_health.m_health;
            m_slider.value = m_health.m_health;
        }


    }
	
	// Update is called once per frame
	void Update ()
    {
        //TO-DO 2 leer el valor del health actual

        m_slider.value = m_health.CurrentHealth;
    }
}
