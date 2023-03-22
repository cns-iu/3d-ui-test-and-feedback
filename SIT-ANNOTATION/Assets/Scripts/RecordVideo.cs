using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Recorder;
using UnityEditor.Recorder.Input;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using System;
using System.Linq;

public class RecordVideo : MonoBehaviour
{
    [SerializeField] private XRSimpleInteractable _xrSimple;
    public float rayDistance = 100f;
    public Color activateColor;

    public Material material;
    public Color originalColor;

    Toggle m_Toggle;
    public Text m_Text;

    [SerializeField] private bool _isRecording = false;

    [SerializeField] private List<RecordVideo> _allRecorders;

    RecorderControllerSettings controllerSettings;
    RecorderController TestRecorderController;

    public void Start()
    {
        material = GetComponent<Renderer>().material;
        originalColor = material.color;
    }

    public void Awake()
    {

                _allRecorders = FindObjectsOfType<RecordVideo>().ToList<RecordVideo>();


        controllerSettings = ScriptableObject.CreateInstance<RecorderControllerSettings>();
        TestRecorderController = new RecorderController(controllerSettings);

        _xrSimple = GetComponent<XRSimpleInteractable>();        
        _xrSimple.activated.AddListener(ClickToActivate);



    }

    public void ClickToActivate(ActivateEventArgs interactable)
    {
        if (interactable.interactableObject.transform.gameObject != this) return;

        foreach (var section in _allRecorders)
        {
            if (section != this.GetComponent<RecordVideo>())
            {

                section.gameObject.GetComponent<XRSimpleInteractable>().enabled = false;
                section.gameObject.GetComponent<RecordVideo>().enabled = false;
            }
        }

        if (!_isRecording)
        {
            _isRecording = true;
            Debug.Log("recording");
            material.color = activateColor;
            StartRecording();
            //toggle value changed or state chaged (maybe tag on the mesh)
        }
        else {
            _isRecording = false;
            Debug.Log("stopped recording");
            material.color = originalColor;
            StopRecording();


            //changes made since last meeting

            foreach (var section in _allRecorders)
            {
                section.gameObject.GetComponent<XRSimpleInteractable>().enabled = true;
                section.gameObject.GetComponent<RecordVideo>().enabled = true;
            }


            // //toggle value changed or state chaged (maybe tag on the mesh)
        }
       

    }

    //void OnEnable()
    //{
    //    var controllerSettings = ScriptableObject.CreateInstance<RecorderControllerSettings>();
    //    var TestRecorderController = new RecorderController(controllerSettings);

    //    var videoRecorder = ScriptableObject.CreateInstance<MovieRecorderSettings>();
    //    videoRecorder.name = "My Video Recorder";
    //    videoRecorder.Enabled = true;
    //    videoRecorder.VideoBitRateMode = UnityEditor.VideoBitrateMode.High;

    //    videoRecorder.ImageInputSettings = new GameViewInputSettings
    //    {
    //        OutputWidth = 3840,
    //        OutputHeight = 2160,
    //    };

    //    videoRecorder.AudioInputSettings.PreserveAudio = true;

    //    // define the path of the save file
    //    videoRecorder.OutputFile = "G:\\My Drive\\Capstone\\Videos\\testrecording1";

    //    controllerSettings.AddRecorderSettings(videoRecorder);
    //    controllerSettings.SetRecordModeToFrameInterval(0, 59); // 2s @ 30 FPS  // ask andi about 2s videos??
    //    controllerSettings.FrameRate = 30;

    //    RecorderOptions.VerboseMode = false;
    //    TestRecorderController.PrepareRecording();
    //    TestRecorderController.PrepareRecording();
    //    TestRecorderController.StartRecording();
    //}

    public void StartRecording()
    {
      


        var videoRecorder = ScriptableObject.CreateInstance<MovieRecorderSettings>();
        videoRecorder.name = "My Video Recorder";
        videoRecorder.Enabled = true;
        videoRecorder.VideoBitRateMode = UnityEditor.VideoBitrateMode.High;

        videoRecorder.ImageInputSettings = new GameViewInputSettings
        {
            OutputWidth = 3840,
            OutputHeight = 2160,
        };

        videoRecorder.AudioInputSettings.PreserveAudio = true;

        // define the path of the save file
        videoRecorder.OutputFile = "G:\\My Drive\\Capstone\\Videos\\testrecording1";

        controllerSettings.AddRecorderSettings(videoRecorder);
        controllerSettings.SetRecordModeToFrameInterval(0, 9999); // 2s @ 30 FPS  // ask andi about 2s videos??
        controllerSettings.FrameRate = 30;

        RecorderOptions.VerboseMode = false;
        TestRecorderController.PrepareRecording();
        TestRecorderController.PrepareRecording();
        TestRecorderController.StartRecording();
    }

    public void StopRecording()
    //  public void StopRecording(RecorderController.?)
    {
       TestRecorderController.StopRecording();
    }


}

    
