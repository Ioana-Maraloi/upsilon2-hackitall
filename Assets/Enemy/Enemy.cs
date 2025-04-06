using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Kill()
    {
        animator.SetTrigger("die");
        Destroy(gameObject, 2f);
    }
}
