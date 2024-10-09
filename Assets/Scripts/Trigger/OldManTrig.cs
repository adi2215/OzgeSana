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

    public GameObject contextClue;

    public DialogueRunner runner;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && !DialogManager.isActive)
        {
            runner.StartDialogue("OldManStart");
            contextClue.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !DialogManager.isActive)
        {
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
