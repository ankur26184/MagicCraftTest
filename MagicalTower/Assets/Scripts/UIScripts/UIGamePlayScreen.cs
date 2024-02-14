
using UnityEngine;
using AVFramework;
using UnityEngine.UI;
public class UIGamePlayScreen : UIScreen
{
    [SerializeField] private Image m_HealthBar;

    public void SetHealthFillAmount(float fillAmount)
    {
        m_HealthBar.fillAmount = fillAmount;
    }
}
