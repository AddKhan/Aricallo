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
    public Image backgroundSprite;
    public List<DialogueStruct> dialogueList;
    public int dialogueIndex;
    public GameObject choiceboxPrefab;
    public bool choiceSelected;
    public bool spawnedChoices;

    // typewriter
    private bool typeWriterInEffect;

    void Start()
    {
        foreach (var kvp in spriteCache.sprites)
        {
            print("yadaaaaa " + kvp);
        }

        tmpName.text = dialogueList[0].name.ToString();
        StartCoroutine(TypeWriterEffect(dialogueList[0].dialogue));
        print("first is " + dialogueList[0].sprite.ToString());
        sprite.sprite = spriteCache.sprites[dialogueList[0].sprite.ToString()];
        backgroundSprite.sprite = spriteCache.sprites[dialogueList[0].backgroundSprite.ToString()];
        print($"i just set it to this {spriteCache.sprites[dialogueList[0].sprite.ToString()]}");
    }

    // update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && !spawnedChoices || choiceSelected) && dialogueIndex < (dialogueList.Count - 1) && !typeWriterInEffect)
        {
            choiceSelected = false;
            Debug.Log("space pressed");
            dialogueIndex++;
            tmpName.text = dialogueList[dialogueIndex].name.ToString();
            StartCoroutine(TypeWriterEffect(dialogueList[dialogueIndex].dialogue));
            sprite.sprite = spriteCache.sprites[dialogueList[dialogueIndex].sprite.ToString()];
            backgroundSprite.sprite = spriteCache.sprites[dialogueList[dialogueIndex].backgroundSprite.ToString()];

            if (dialogueList[dialogueIndex].isChoice)
            {
                spawnedChoices = true;

                GameObject choiceZero = Instantiate(choiceboxPrefab);
                choiceZero.transform.SetParent(transform.parent);
                choiceZero.transform.localPosition = new Vector2(0, 100);
                choiceZero.name = "0";

                GameObject choiceOne = Instantiate(choiceboxPrefab);
                choiceOne.transform.SetParent(transform.parent);
                choiceOne.transform.localPosition = new Vector2(0, -100);
                choiceOne.name = "1";
            }
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
