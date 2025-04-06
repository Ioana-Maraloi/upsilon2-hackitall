using UnityEngine;

public class Pickup : StateMachineBehaviour
{
    public GameObject item; // Obiectul care va fi ridicat (de exemplu, o sabie)

    // Este apelat când animația începe (la intrarea în stare)
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Asigură-te că ai un obiect asignat
        if (item != null)
        {
            // Poți să faci obiectul invizibil sau să-l adaugi în mâna jucătorului aici
            // De exemplu, dacă vrei să-l pui în mâna jucătorului:
            item.transform.SetParent(animator.transform); // Atasează obiectul la mâna personajului
            item.transform.localPosition = Vector3.zero;  // Ajustează poziția obiectului în mâna personajului
            item.transform.localRotation = Quaternion.identity; // Resetează rotația pentru a-l alinia corect
        }
    }

    // Este apelat la fiecare frame în care starea este activă
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Poți adăuga logica suplimentară aici dacă vrei să actualizezi ceva pe parcursul animației
    }

    // Este apelat când animația se termină (la ieșirea din stare)
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Dacă vrei să faci obiectul invizibil sau să-l setezi în alt loc
        if (item != null)
        {
            // De exemplu, poți să-l îndepărtezi din mâna jucătorului:
            item.transform.SetParent(null); // Dezatașează obiectul
            item.SetActive(false); // Deactivează obiectul dacă nu mai vrei să fie vizibil
        }
    }
}

