using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour
{
    public TMP_Text dialogText;
    public TMP_Text dialogNpcName;
    public GameObject dialogBox;
    private Queue<string> sentences;


    void Start()
    {
        dialogBox.SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogNpcName.text = dialogue.name;
        dialogBox.SetActive(true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    void EndDialogue() {
        dialogBox.SetActive(false); 
    }
}
