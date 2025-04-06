using UnityEngine;
using UnityEngine.UI;

public class StatusBarDiamond : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Slider DiamondSlider;
    [SerializeField] private Image diamonImage;
    public int toalNumbers = 11;
    // private int collected = 0;
    private void Start()
    {
        diamonImage.fillAmount = 0f;
    }
    public void setNumber(int number)
    {
        float progress = (float)number / 11.0f;
        diamonImage.fillAmount = progress;
    }
}
