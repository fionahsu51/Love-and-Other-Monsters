using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class DialogueVariables
{
    private Dictionary<string, Ink.Runtime.Object> variables;


    //public DialogueVariables(string globalsFilePath)
    //{
    //    // Compile the story
    //    string inkFileContents = globalsFilePath.ReadAllText(globalsFilePath);
    //    Ink.Compiler compiler = new Ink.Compiler(inkFileContents);
    //    Story globalVariablesStory = compiler.Compiler();
    //}

    public void StartListening(Story story)
    {
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    // Name = variable name (Example: Character name)
    // value = value of Name (Example: Aveline)
    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        PlayerPrefs.SetString("womanSelection", value.ToString());
        Debug.Log("Variable changed: " + name + " = " + value);
    }
}
