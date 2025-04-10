using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    // [SerializeField] private GameObject dialogueBox;
    // [SerializeField] private GameObject dialogueBoxEnemy; 
    [SerializeField] private Animation wizardAnim; // dacă e animație legacy
    [SerializeField] private WizardMove wizardMove;

    [SerializeField] private GameObject fadePanel;
    [SerializeField] private GameObject nextPanel;

    [SerializeField] private TMPro.TextMeshProUGUI dialogueText;
    [SerializeField] private TMPro.TextMeshProUGUI dialogueTextEnemy;


    // [SerializeField] private float delayedStart = 0.0f;

    [TextArea(3, 10)]
    public string[] lines; // replicile monstrului

    public float textSpeed = 0.05f;

    private int index = 0;
    private bool isTyping = false;

    private bool myTurn = true;
    void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    void FadeToBlack()
    {
        fadePanel.SetActive(true);
    }

    void ShowNextPanel()
    {
        nextPanel.SetActive(true);
        Time.timeScale = 0f; // opțional, dacă vrei să oprești jocul
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopAllCoroutines();

                // Afiseaza direct toata replica curenta in textul corect
                if (myTurn)
                    dialogueText.text = lines[index];
                else
                    dialogueTextEnemy.text = lines[index];

                isTyping = false;
            }
            else
            {
                index++;
                if (index < lines.Length)
                {
                    myTurn = !myTurn; // trece la celalalt vorbitor
                    StartCoroutine(TypeLine());
                }
                else
                {
                    // final de dialog
                    dialogueText.text = "";
                    dialogueTextEnemy.text = "";

                    // pornește animația
                    wizardAnim.Play("move_forward_fast");
                    wizardMove.StartMoving();

                    Invoke("FadeToBlack", 1f);
                    Invoke("ShowNextPanel", 4f);
                }
            }
        }
    }


    // IEnumerator DelayedStart()
    // {
    //     yield return new WaitForSeconds(delayedStart);  // ia valoarea din Inspector
    //     StartCoroutine(TypeLine());
    // }
    IEnumerator TypeLine()
    {
        isTyping = true;

        // Decide în care text scriem
        TextMeshProUGUI currentText = myTurn ? dialogueText : dialogueTextEnemy;

        // Golește ambele texte înainte
        dialogueText.text = "";
        dialogueTextEnemy.text = "";

        foreach (char c in lines[index].ToCharArray())
        {
            currentText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }
}
