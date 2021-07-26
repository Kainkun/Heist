using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    static Dictionary<string, DialogueStruct> DialogDictionary = new Dictionary<string, DialogueStruct>();

    TextAsset csvFile;

    private void Start()
    {
        ReadData();
    }

    struct DialogueStruct
    {
        public string subtitles;
        public AudioClip audioClip;

        public DialogueStruct(string subtitles, string audioClip)
        {
            this.subtitles = subtitles;
            
            audioClip = audioClip.Trim();
            this.audioClip = Resources.Load<AudioClip>("Dialogue/" + audioClip);
        }
    }

    private char lineSeperater = '\n';
    private char fieldSeperator = ',';

    private void ReadData()
    {
        csvFile = Resources.Load<TextAsset>("Dialogue/_Dialogue");

        string[] records = csvFile.text.Split(lineSeperater);
        records[0] = "";
        foreach (string record in records)
        {
            if(record.Length == 0)
                continue;
            
            string[] fields = record.Split(fieldSeperator);
            
            DialogDictionary.Add(fields[0], new DialogueStruct(fields[1], fields[2]));
        }
    }

    public static void DoDialogue(string key)
    {
        DialogueStruct s = DialogDictionary[key];
        print(s.subtitles);
        if(s.audioClip)
            GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(s.audioClip);
    }
}