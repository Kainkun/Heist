using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static Dictionary<string, string> DialogDictionary = new Dictionary<string, string>();

    TextAsset csvFile;

    private void Start()
    {
        ReadData();
    }


    private char lineSeperater = '\n';
    private char fieldSeperator = ',';

    private void ReadData()
    {
        csvFile = Resources.Load<TextAsset>("Dialogue");

        string[] records = csvFile.text.Split(lineSeperater);
        records[0] = "";
        foreach (string record in records)
        {
            if(record.Length == 0)
                continue;
            
            string[] fields = record.Split(fieldSeperator);
            
            DialogDictionary.Add(fields[0],fields[1]);
        }
    }

    public static void DoDialogue(string key)
    {
        print(DialogDictionary[key]);
    }
}