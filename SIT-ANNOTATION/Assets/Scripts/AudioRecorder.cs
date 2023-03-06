using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;


public class AudioRecorder : MonoBehaviour
{
    public Button record;
    private void Startrecording()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("Oculus Virtual Audio Device", true, 10, 44100);
        audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get list of Microphone devices and print the names to the log
      
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }


        // Button to sart stop
        Button btn =  record.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Debug.Log("You have clicked the record button!");
        Startrecording();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
