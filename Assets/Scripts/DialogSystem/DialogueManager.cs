using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;
     public NPCDialogueTrigger NPCDT;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    private void Update()
    {

    }

    //memunculkan dialog box dan memulai kalimat pertama
    public void StartDialogue (Dialogue dialogue)
    {
        NPCDT.dialogueOpenedCheck = true;
        animator.SetBool("isOpen", true);   //animasi munculnya dialogbox
        nameText.text = dialogue.name;      //assign nama NPC dari class Dialogue
        Debug.Log("starting conversation with " + dialogue.name);
        sentences.Clear();  //mengosongkan tampilan kalimat di dialogbox
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count==0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        NPCDT.dialogueOpenedCheck = false;
        StartCoroutine(dialogueCloseAnim());
        Debug.Log("end of Conversation");

    }
    IEnumerator dialogueCloseAnim()
    {
        animator.SetBool("isOpen", false);
        yield return new WaitForSeconds(1);
        NPCDT.dialogueBox.SetActive(false);
    }
}
