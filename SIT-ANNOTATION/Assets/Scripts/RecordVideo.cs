using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Recorder;
using UnityEditor.Recorder.Input;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class RecordVideo : MonoBehaviour
{
    [SerializeField] private XRSimpleInteractable _xrSimple;
    public float rayDistance = 100f;
    public Color activateColor;

    public Material material;
    public Color originalColor;

    Toggle m_Toggle;
    public Text m_Text;


    public void Start()
    {
        material = GetComponent<Renderer>().material;
        originalColor = material.color;



    }

    public void Awake()
    {
        _xrSimple = GetComponent<XRSimpleInteractable>();

        
        _xrSimple.activated.AddListener(FirstclickToActivate);

    }
    public void FirstclickToActivate(ActivateEventArgs interactable)
    {
        material.color = activateColor;
        //start recording
        //toggle value changed or state chaged (maybe tag on the mesh)

    }

    public void SecondClickToDeactivate(ActivateEventArgs interactable)
    {
        material.color = originalColor;
        //stop recording
        // //toggle value changed or state chaged (maybe tag on the mesh)

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
        var controllerSettings = ScriptableObject.CreateInstance<RecorderControllerSettings>();
        var TestRecorderController = new RecorderController(controllerSettings);

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
        controllerSettings.SetRecordModeToFrameInterval(0, 59); // 2s @ 30 FPS  // ask andi about 2s videos??
        controllerSettings.FrameRate = 30;

        RecorderOptions.VerboseMode = false;
        TestRecorderController.PrepareRecording();
        TestRecorderController.PrepareRecording();
        TestRecorderController.StartRecording();
    }

    public void StopRecording()
    //  public void StopRecording(RecorderController.?)
    {
       // TestRecorderController.stopRecording();
    }


}

    
