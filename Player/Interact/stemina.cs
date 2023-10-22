using UnityEngine;
using UnityEngine.UI;

public class stemina : MonoBehaviour
{
    Slider m_stemina;
    void Start()
    {
        m_stemina = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        m_stemina.value += Time.deltaTime / 120f;
    }

}
