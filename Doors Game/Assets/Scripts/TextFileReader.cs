using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using System;

//Enums to represent what the index in percentages list corresponds to.
//enum Doors
//{
//    Hot_Noisy_Safe = 0,
//    Hot_Noisy_NotSafe = 1,
//    Hot_NotNoisy_Safe = 2,
//    Hot_NotNoisy_NotSafe = 3,
//    NotHot_Noisy_Safe = 4,
//    NotHot_Noisy_NotSafe = 5,
//    NotHot_NotNoisy_Safe = 6,
//    NotHot_NotNoisy_NotSafe = 7,
//    Door_Selected = 8,
//};

public class TextFileReader : MonoBehaviour
{
    public Text textUI; // Link to textUI element

    public List<float> percentages = new List<float>(); // List of probabilities stored as floats

    //bool safeDoor; // Bool to track the safety of a door

    ////Sprite Images of the various doors
    //public Sprite safe;
    //public Sprite dead;

    //public Sprite hot;
    //public Sprite noisy;
    //public Sprite hotnoisy;
    //public Sprite nothot_notnoisy;



    ////Function to open prompt a file dialog and output the text to a UI element
    void Awake()
    {
        string path = EditorUtility.OpenFilePanel("Select Probability Text Location!", "", "txt");

        if (path.Length != 0)
        {
            StreamReader reader = new StreamReader(path);

            textUI.text = reader.ReadToEnd();

            reader = new StreamReader(path);

            storeProbabilities(reader.ReadToEnd());
            reader.Close();

            //calculateProbabilities();
        }
    }

    //Function to open a file dialog from button press and output the text to a UI element
    public void LoadInfo()
    {
        string path = EditorUtility.OpenFilePanel("Select Probability Text Location!", "", "txt");

        if (path.Length != 0)
        {
            StreamReader reader = new StreamReader(path);

            textUI.text = reader.ReadToEnd();

            reader = new StreamReader(path);

            storeProbabilities(reader.ReadToEnd());
            reader.Close();

            //calculateProbabilities();
        }
    }

    //Function that parses the string obtained from the file and creates a list of the probabilities as floats.
    public void storeProbabilities(string probs)
    {
        string probabilities = probs;

        Debug.Log(probabilities);

        string[] subStrings = probabilities.Split(new char[] { ' ', '\n' },  StringSplitOptions.RemoveEmptyEntries);
        //string[] subStrings = probabilities.Split(' ');

        for (int i = 0; i < subStrings.Length; i++)
        {
            float temp;
            //Debug.Log(subStrings[i]);

            bool result = float.TryParse(subStrings[i], out temp);

            if (result)
            {
                //Debug.Log(temp);
                percentages.Add(temp);
            }

        }

        //for (int i = 0; i < percentages.Count; i++)
        //{
        //    Debug.Log(percentages[i]);
        //}
        //Debug.Log("Percentages at 4 " + percentages[4]);
    }
}
