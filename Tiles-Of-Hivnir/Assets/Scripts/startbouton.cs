using System.Collections;
using System.Collections.Generic;
using TalesofHivnir;
using UnityEngine;
using UnityEngine.UI;
public class startbouton : MonoBehaviour
{
    private programbosscombat interpreter;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnStartButtonClick);

        interpreter = FindObjectOfType<programbosscombat>();
    }

    private void OnStartButtonClick()
    {
        if (interpreter != null)
        {
            interpreter.InterpretBlock();
        }
        else
        {
            Debug.LogWarning("No ProgrammingBlockInterpreter instance found in the scene.");
        }
    }
}
