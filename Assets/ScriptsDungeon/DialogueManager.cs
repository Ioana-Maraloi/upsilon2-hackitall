using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI dialogueTextEnemy;

    [SerializeField] private int sceneIndexToLoad = 2; // ✏️ indexul scenei din Build Settings

    [TextArea(3, 10)]
    public string[] lines;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopAllCoroutines();

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
                    myTurn = !myTurn;
                    StartCoroutine(TypeLine());
                }
                else
                {
                    // final de dialog
                    dialogueText.text = "";
                    dialogueTextEnemy.text = "";

                    // schimbare scenă după delay
                    Invoke("LoadNextScene", 1f);
                }
            }
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        TextMeshProUGUI currentText = myTurn ? dialogueText : dialogueTextEnemy;

        dialogueText.text = "";
        dialogueTextEnemy.text = "";

        foreach (char c in lines[index].ToCharArray())
        {
            currentText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
