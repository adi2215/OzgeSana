using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public DialogueRunner Runner;

    public SaveDialog countDialog;

    public void StartDialog()
    {
        Runner.StartDialogue("OldManStart");
    }
}

[System.Serializable]
public class Message {
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor {
    public string name;
    public Sprite sprite;
}
