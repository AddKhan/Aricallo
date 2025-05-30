using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteCache", menuName = "ScriptableObjects/SpriteCache")]
public class SpriteCache : ScriptableObject
{
    public Dictionary<string, Sprite> sprites = new();

    void OnEnable() 
    {
        LoadSprite("Sprites/", Enum.GetNames(typeof(SpriteEnum)));
        LoadSprite("Sprites/Backgrounds/", Enum.GetNames(typeof(BackgroundEnum)));
    }

    void LoadSprite(string path, string[] spriteNames) 
    {
        foreach (string spriteName in spriteNames) 
        {
            sprites[spriteName] = Resources.Load<Sprite>(path + spriteName);
            Debug.Log($"debug {spriteName}");
        }
    }
}