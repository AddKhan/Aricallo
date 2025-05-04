using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    public List<string> dialogueList;
    public int dialogueIndex;

    // typewriter
    private bool typeWriterInEffect;

    void Start()
    {
        StartCoroutine(TypeWriterEffect(dialogueList[0]));
    }

    // update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueIndex < (dialogueList.Count - 1) && !typeWriterInEffect)
        {
            Debug.Log("space pressed");
            dialogueIndex++;
            StartCoroutine(TypeWriterEffect(dialogueList[dialogueIndex]));
        }
    }

    private IEnumerator TypeWriterEffect(string dialogue)
    {
        typeWriterInEffect = true;
        
        for (int i = 0; i <= dialogue.Length; i++) 
        {
            tmp.text = dialogue[..i];
            
            yield return new WaitForSeconds(0.05f); // make diff speeds
        }

        typeWriterInEffect = false;
    }

}
