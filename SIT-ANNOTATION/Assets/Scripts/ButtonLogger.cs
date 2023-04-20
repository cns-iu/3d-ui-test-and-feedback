using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using System;
using System.Text;

public class ButtonLogger : MonoBehaviour
{
    [SerializeField] private List<InputActionReference> _buttons = new List<InputActionReference>();


    // The button to track
    public static event Action<string> ButtonEvent;

    // The name of the CSV file to write to
    public string csvFileName;

    // The StreamWriter object used to write to the CSV file
    private StreamWriter csvWriter;

    //definbe a start time
    private float startTime;
    private float elapsedTime = 0;

    // User ID
    public string userID;


    [SerializeField] private XRRayInteractor _interactor;
    [SerializeField] private List<RadialSection> _sections = new List<RadialSection>();
    // Button ID


    // SHould I add tags to individual meshed?

    private string _currentButtonPressed;
    private string _currentRadialSection;
    private string currentSectionPressed;

    private void OnEnable()
    {

        foreach (var button in _buttons)
        {
            button.action.performed += CaptureButton;
        }
        //_refTrigger.action.performed += CaptureButton;
        startTime = Time.time;

        foreach (var section in _sections)
        {
            section.GetComponent<XRSimpleInteractable>().activated.AddListener(CaptureSection);
        }
    }

    private void CaptureSection(ActivateEventArgs args) {
        currentSectionPressed= args.interactableObject.transform.gameObject.GetComponent<RadialSection>().Type.ToString();
    }

    private void CaptureButton(InputAction.CallbackContext ctx) {
        _currentButtonPressed = ctx.action.name;

        //ButtonEvent?.Invoke(ctx.action.name);
        //log message for ctx.action.name
    }

    // Start is called before the first frame update
    void Start()
    {
        // Open the CSV file for writing
        csvWriter = new StreamWriter(csvFileName);

        // Write the header row to the CSV file
        csvWriter.WriteLine("Time,Button,");

        csvWriter.WriteLine(userID + ",");
        csvWriter.WriteLine($"{userID},");

        StringBuilder sb = new StringBuilder();
        sb.Append(userID);
        sb.Append(",");
        csvWriter.WriteLine(sb.ToString());

        string myString = "hh";
        string newstring = myString + "fjijfe";


        // Start tracking button presses
        //elapsedTime | userId | curentTask |         

        //csvFileName = "button_presses.csv";
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    void OnDestroy()
    {
       
        // Close the CSV file when the script is destroyed
        csvWriter.Close();
    }
}