using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackCooldown = 2.0f;
    //dmg
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //daca e cooldown, numara X s
    }

    void OnTriggerEnter(Collider other)
    {
        //detectat plyaer

        //daca esti pe cooldown
        //return

        //altfel
//attack animation + damage pe player

//setezi cooldown


    }

    void OnTriggerExit(Collider other)
    {
        //detectat plyaer

        
    }
}
