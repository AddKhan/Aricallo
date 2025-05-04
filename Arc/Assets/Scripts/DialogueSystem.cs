using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public SpriteCache spriteCache;
    public TextMeshProUGUI tmpDialogue;
    public TextMeshProUGUI tmpName;
    public Image sprite;
    public List<DialogueStruct> dialogueList;
    public int dialogueIndex;

    // typewriter
    private bool typeWriterInEffect;

    void Start()
    {
        tmpName.text = dialogueList[0].name.ToString();
        StartCoroutine(TypeWriterEffect(dialogueList[0].dialogue));
        print("first is " + dialogueList[0].sprite.ToString());
        sprite.sprite = spriteCache.sprites[dialogueList[0].sprite.ToString()];
    }

    // update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueIndex < (dialogueList.Count - 1) && !typeWriterInEffect)
        {
            Debug.Log("space pressed");
            dialogueIndex++;
            tmpName.text = dialogueList[dialogueIndex].name.ToString();
            StartCoroutine(TypeWriterEffect(dialogueList[dialogueIndex].dialogue));
            sprite.sprite = spriteCache.sprites[dialogueList[dialogueIndex].sprite.ToString()];
        }
    }

    private IEnumerator TypeWriterEffect(string dialogue)
    {
        typeWriterInEffect = true;
        
        for (int i = 0; i <= dialogue.Length; i++) 
        {
            tmpDialogue.text = dialogue[..i];
            
            yield return new WaitForSeconds(0.05f); // make diff speeds
        }

        typeWriterInEffect = false;
    }

}
