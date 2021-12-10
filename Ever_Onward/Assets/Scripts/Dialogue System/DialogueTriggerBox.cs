using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerBox : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    public void OnTriggerEnter(Collider other)
    {
        print("SOMEONE IS IN MY BOX");
        if (other.tag == "Player")
        {
            if (DialogueSystem.inConversation == false)
            {
                if (dialogueTrigger != null) dialogueTrigger.TriggerDialogue();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {

    }
}
