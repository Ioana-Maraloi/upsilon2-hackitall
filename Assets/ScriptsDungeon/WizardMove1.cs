using UnityEngine;

public class WizardMove1 : MonoBehaviour
{
    public Transform target;      // ținta spre care merge
    public float speed = 2f;      // viteza de deplasare

    private bool shouldMove = false;

    public void StartMoving()
    {
        shouldMove = true;
    }

    void Update()
    {
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.LookAt(target); // opțional: se uită spre cameră
        }
    }
}

