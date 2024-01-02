using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialog/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentence> sentences = new List<Sentence>();
}

[Serializable]
public class Sentence
{
    public string actorName;
    public Sprite profile;
    public Language sentence;
}

[Serializable]
public class Language
{
    public string portuguese;
    public string english;
    public string spanish;
}

#if UNITY_EDITOR

[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings dialogueSettings = (DialogueSettings)target;

        Language language = new Language();
        language.portuguese = dialogueSettings.sentence;

        Sentence sentence = new Sentence();
        sentence.profile = dialogueSettings.speakerSprite;
        sentence.sentence = language;

        if(GUILayout.Button("Create Dialogue"))
        {
            if(dialogueSettings.sentence != "")
            {
                dialogueSettings.sentences.Add(sentence);

                dialogueSettings.speakerSprite = null;
                dialogueSettings.sentence = null;
            }
        }
    }
}

#endif