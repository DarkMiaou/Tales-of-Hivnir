using System.Collections;
using System.Collections.Generic;
using TalesofHivnir;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour
{
    private ProgrammingBlockInterpreter interpreter;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnStartButtonClick);

        interpreter = FindObjectOfType<ProgrammingBlockInterpreter>();
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