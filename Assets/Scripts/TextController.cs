using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    TextMeshProUGUI dialogueText;
    // Array of dialogue lines.
    string[] dialogue = new string[] { "Hey Sam, fun course so far." };
    bool isDisplayingDialogue = false;

    private void Awake()
    {
        dialogueText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        // Subscribe to start and cancel interact events.
        Actions.StartInteractEvent += DisplayDialogue;
        Actions.CancelInteractEvent += HideDialogue;
    }

    private void OnDisable()
    {
        // Unsubscribe to start and cancel interact events.
        Actions.StartInteractEvent -= DisplayDialogue;
        Actions.CancelInteractEvent -= HideDialogue;
    }

    void DisplayDialogue()
    {
        Debug.Log("Space key pressed. Started writing dialogue to screen.");
        if (!isDisplayingDialogue)
        {
            // Start the coroutine to write the dialogue to screen.
            isDisplayingDialogue = true;
            StartCoroutine(WriteDialogue());
        }
    }

    IEnumerator WriteDialogue()
    {
        dialogueText.enabled = true;
        // Clear the dialogue before writing.
        dialogueText.text = "";

        // Iterate through lines of dialogue and characters in each line.
        foreach (string line in dialogue)
        {
            foreach (char letter in line)
            {
                // Add a letter to the text based on the delay.
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.05f); // Delay between characters.
            }
        }
    }

    void HideDialogue()
    {
        Debug.Log("Space key released. Stopped writing dialogue to screen.");
        // Stop the coroutine from writing.
        StopAllCoroutines();
        // Clear the displayed text and reset the flag.
        dialogueText.text = "";
        dialogueText.enabled = false;
        isDisplayingDialogue = false;
    }

}
