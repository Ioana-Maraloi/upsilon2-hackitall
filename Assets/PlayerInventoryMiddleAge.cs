using UnityEngine;

public class PlayerInventoryMiddleAge : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private StatusBarSkelet statusBarSkelet;
    [SerializeField] private GameObject magicPortal;
    public int NumberofEnemies{ get; private set;}
    public void EnemiesKilled()
    {
        
        NumberofEnemies++;
        statusBarSkelet.setNumber(NumberofEnemies);
        if (NumberofEnemies == 4)
        {
            magicPortal.SetActive(true);
        }
    }
}
