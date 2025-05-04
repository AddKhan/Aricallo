using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class ChoiceboxBehavior : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public void Start()
    {
        dialogueSystem = GameObject.Find("Textbox").GetComponent<DialogueSystem>();
        GetComponentInChildren<TextMeshProUGUI>().text = dialogueSystem.dialogueList[dialogueSystem.dialogueIndex].choices[int.Parse(name)].choiceDialogue;
    }
    public void ChoiceSelect()
    {
       Debug.Log("clicked on a box and now i want to jump to: " + dialogueSystem.dialogueList[dialogueSystem.dialogueIndex].choices[int.Parse(name)].choiceMapping);
       dialogueSystem.dialogueIndex = dialogueSystem.dialogueList[dialogueSystem.dialogueIndex].choices[int.Parse(name)].choiceMapping;
       
       dialogueSystem.choiceSelected = true;
       dialogueSystem.spawnedChoices = false;

       foreach (GameObject choice in GameObject.FindGameObjectsWithTag("Choice"))
       {
            Destroy(choice);
       }
    }
}
