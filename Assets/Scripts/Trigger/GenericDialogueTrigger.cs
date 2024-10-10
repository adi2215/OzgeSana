using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class GenericDialogueTrigger : MonoBehaviour
{
    public string dialogueNodeName;
    public LetGo contextOn;
    public LetGo contextOff;

    bool playerInRange;
    ContextClue clue;
    DialogueRunner runner;

    void Start()
    {
        clue = GameObject.FindWithTag("Player").GetComponent<ContextClue>();
        runner = GameObject.Find("CustomDialogueSystem").GetComponent<DialogueRunner>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            clue.Disable();
            runner.StartDialogue(dialogueNodeName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            contextOn.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            contextOff.Raise();
            playerInRange = false;
        }

    }
}
