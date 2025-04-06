using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private StatusBarDiamond statusBarDiamond;
    [SerializeField] private GameObject magicPortal;    
    public int NumberOfDiamonds { get; private set; }
    public void DiamondCollected()
    {
        NumberOfDiamonds++;
        statusBarDiamond.setNumber(NumberOfDiamonds);
        if (NumberOfDiamonds >= 1)
        {
            magicPortal.SetActive(true);
            Debug.Log("Ai colectat 8 diamante! Obiectivul s-a activat!");
        }
    }

}
