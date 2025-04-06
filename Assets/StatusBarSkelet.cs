using UnityEngine;
using UnityEngine.UI;

public class StatusBarSkelet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] private Image diamanteImage;
   public int total = 11;
//    private int colectat = 0;
   private void Start()
   {
    diamanteImage.fillAmount = 0f;
   }
   public void setNumber(int number){
    float progres = (float) number / 11.0f;
    diamanteImage.fillAmount = progres;
   }
}
