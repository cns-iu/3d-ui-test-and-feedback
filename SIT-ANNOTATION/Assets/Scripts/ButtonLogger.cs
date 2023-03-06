using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using System;

public class ButtonLogger : MonoBehaviour
{
    [SerializeField] private InputActionReference _refBButton;

    // The button to track
    public static event Action<string> ButtonEvent;

    // The name of the CSV file to write to
    public string csvFileName;

    // The StreamWriter object used to write to the CSV file
    private StreamWriter csvWriter;

    private void OnEnable()
    {
        _refBButton.action.performed += CaptureButton;
    }

    private void CaptureButton(InputAction.CallbackContext ctx) {
        ButtonEvent?.Invoke(ctx.action.name);
        //log message for ctx.action.name
    }

    // Start is called before the first frame update
    void Start()
    {
        // Open the CSV file for writing
        csvWriter = new StreamWriter(csvFileName);

        // Write the header row to the CSV file
        csvWriter.WriteLine("Time,Button");

        // Start tracking button presses
        

        //csvFileName = "button_presses.csv";
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnDestroy()
    {
        // Close the CSV file when the script is destroyed
        csvWriter.Close();
    }
}