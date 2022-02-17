using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    public GameObject nextAction;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {   
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        Debug.Log("Starting conversation with "+dialogue.name);
        nameText.text=dialogue.name;

        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            //end queue
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; //wait a single frame
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        Debug.Log("End of conversation.");

        nextAction.SetActive(true);
    }
}
