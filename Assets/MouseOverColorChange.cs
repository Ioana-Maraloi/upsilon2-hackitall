using UnityEngine;
using UnityEngine.UI;
public class MouseOverColorChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetRed()
    {
        GetComponent<Image>().color = Color.red;
    }
    public void SetGreen()
    {
        GetComponent<Image>().color = Color.green;
    }
}
