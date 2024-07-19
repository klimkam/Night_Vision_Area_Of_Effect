using UnityEngine;
using UnityEngine.Rendering;

public class NightVision : MonoBehaviour
{
    [SerializeField] private Color m_defaultLightColour;
    [SerializeField] private Color m_boostedLightColour;

    private bool m_isNightVisionEnabled;
    private Volume m_volume;

    private void Start()
    {
        RenderSettings.ambientEquatorColor = m_defaultLightColour;

        m_volume = gameObject.GetComponent<Volume>();
        m_volume.weight = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ToggleNightVision();
        }
    }

    private void ToggleNightVision()
    {
        m_isNightVisionEnabled = !m_isNightVisionEnabled;

        if (m_isNightVisionEnabled)
        {
            RenderSettings.ambientLight = m_boostedLightColour;
            m_volume.weight = 1;
        }
        else
        {
            RenderSettings.ambientLight = m_defaultLightColour;
            m_volume.weight = 0;
        }
    }
}
