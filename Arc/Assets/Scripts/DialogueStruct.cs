using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueStruct
{
    public CharacterEnum name;
    public SpriteEnum sprite;
    public BackgroundEnum backgroundSprite;
    public string dialogue;
    public bool isChoice;
    public List<ChoiceStruct> choices;
}
