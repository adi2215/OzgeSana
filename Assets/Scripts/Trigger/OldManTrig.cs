using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class OldManTrig : MonoBehaviour
{
    public LetGo contextOn;

    public LetGo contextOff;

    public bool playerInRange;

    public bool currentPlayer = true;

    public ContextClue clue;

    public DialogueRunner runner;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            clue.Disable();
            runner.StartDialogue("OldManStart");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            clue = other.gameObject.GetComponent<ContextClue>();
            contextOn.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            contextOff.Raise();
            playerInRange = false;
        }

    }
}
