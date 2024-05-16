using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

public class DataLogging : MonoBehaviour
{
    //[Header("Test")]
    //[Space(40, order = 0)]

    private InputDevice rightController;
    private InputDevice leftController;
    private InputDevice headMountedDisplay;
    private OculusLogging oculusLogging;
    private bool isList1ToWrite = true;
    private GameObject rightEye;
    private GameObject leftEye;
    private GameObject cube;

    [SerializeField]
    private string path;

    [SerializeField]
    private string fileName;

    CSVWriter csvWriter;
    private float timePassed;

    [SerializeField]
    private float timeBeforeLog;

    /*** Left Controller ***/
    [SerializeField]
    private bool leftPrimary2DAxis;
    [SerializeField]
    private bool leftGrip;
    [SerializeField]
    private bool leftGripButton;
    [SerializeField]
    private bool leftMenuButton;
    [SerializeField]
    private bool leftPrimaryButton;
    [SerializeField]
    private bool leftPrimaryTouch;
    [SerializeField]
    private bool leftSecondaryButton;
    [SerializeField]
    private bool leftSecondaryTouch;
    [SerializeField]
    private bool leftTrigger;
    [SerializeField]
    private bool leftTriggerButton;
    [SerializeField]
    private bool leftPrimary2DAxisClick;
    [SerializeField]
    private bool leftPrimary2DAxisTouch;
    [SerializeField]
    private bool leftIsTracked;
    [SerializeField]
    private bool leftTrackingState;
    [SerializeField]
    private bool leftDevicePosition;
    [SerializeField]
    private bool leftDeviceRotation;
    [SerializeField]
    private bool leftDeviceVelocity;
    [SerializeField]
    private bool leftDeviceAngularVelocity;


    /*** Right controller ***/
    [SerializeField]
    private bool rightPrimary2DAxis;
    [SerializeField]
    private bool rightGrip;
    [SerializeField]
    private bool rightGripButton;
    [SerializeField]
    private bool rightMenuButton;
    [SerializeField]
    private bool rightPrimaryButton;
    [SerializeField]
    private bool rightPrimaryTouch;
    [SerializeField]
    private bool rightSecondaryButton;
    [SerializeField]
    private bool rightSecondaryTouch;
    [SerializeField]
    private bool rightTrigger;
    [SerializeField]
    private bool rightTriggerButton;
    [SerializeField]
    private bool rightPrimary2DAxisClick;
    [SerializeField]
    private bool rightPrimary2DAxisTouch;
    [SerializeField]
    private bool rightIsTracked;
    [SerializeField]
    private bool rightTrackingState;
    [SerializeField]
    private bool rightDevicePosition;
    [SerializeField]
    private bool rightDeviceRotation;
    [SerializeField]
    private bool rightDeviceVelocity;
    [SerializeField]
    private bool rightDeviceAngularVelocity;

    /*** Headset ***/
    [SerializeField]
    private bool isUserPresence;
    [SerializeField]
    private bool isHeadSetTracked;
    [SerializeField]
    private bool isHeadSetTrackingState;
    [SerializeField]
    private bool isHeadSetDevicePosition;
    [SerializeField]
    private bool isHeadSetDeviceRotation;
    [SerializeField]
    private bool isHeadSetDeviceVelocity;
    [SerializeField]
    private bool isHeadSetDeviceAngularVelocity;
    [SerializeField]
    private bool isHeadSetDeviceAcceleration;
    [SerializeField]
    private bool isHeadSetDeviceAngularAcceleration;
    [SerializeField]
    private bool isHeadSetLeftEyePosition;
    [SerializeField]
    private bool isHeadSetLeftEyeRotation;
    [SerializeField]
    private bool isHeadSetLeftEyeVelocity;
    [SerializeField]
    private bool isHeadSetLeftEyeAngularVelocity;
    [SerializeField]
    private bool isHeadSetLeftEyeAcceleration;
    [SerializeField]
    private bool isHeadSetLeftEyeAngularAcceleration;
    [SerializeField]
    private bool isHeadSetRightEyePosition;
    [SerializeField]
    private bool isHeadSetRightEyeRotation;
    [SerializeField]
    private bool isHeadSetRightEyeVelocity;
    [SerializeField]
    private bool isHeadSetRightEyeAngularVelocity;
    [SerializeField]
    private bool isHeadSetRightEyeAcceleration;
    [SerializeField]
    private bool isHeadSetRightEyeAngularAcceleration;
    [SerializeField]
    private bool isHeadSetCenterEyePosition;
    [SerializeField]
    private bool isHeadSetCenterEyeRotation;
    [SerializeField]
    private bool isHeadSetCenterEyeVelocity;
    [SerializeField]
    private bool isHeadSetCenterEyeAngularVelocity;
    [SerializeField]
    private bool isHeadSetCenterEyeAcceleration;
    [SerializeField]
    private bool isHeadSetCenterEyeAngularAcceleration;
    [SerializeField]
    private bool isHeadSetBatterieLevel;
    [SerializeField]
    private bool isHeadSetColorCameraAcceleration;
    [SerializeField]
    private bool isHeadSetColorCameraAngularAcceleration;
    [SerializeField]
    private bool isHeadSetColorCameraAngularVelocity;
    [SerializeField]
    private bool isHeadSetColorCameraPosition;
    [SerializeField]
    private bool isHeadSetColorCameraRotation;
    [SerializeField]
    private bool isHeadSetColorCameraVelocity;
    [SerializeField]
    private bool isHeadSetFixationPoint;
    [SerializeField]
    private bool isHeadSetLeftEyeOpenAmount;
    [SerializeField]
    private bool isHeadSetRightEyeOpenAmount;



    private void Start()
    {
        //this.rightEye = GameObject.Find("RightEye");
        //this.leftEye = GameObject.Find("LeftEye");
        this.cube = GameObject.Find("Cube");
        if (this.timeBeforeLog < 0f)
        {
            Debug.LogError(" Time between each logs in .csv file need to be bigger than 0 ");
        }
        this.timePassed = 0.0f;
        csvWriter = new CSVWriter();
        csvWriter.SetPath(path + "/" + fileName + System.DateTime.Now.ToString("yyyyMMddHHmm") + ".csv");
        csvWriter.WriteHeaderCSV();

        oculusLogging = new OculusLogging();
        oculusLogging.SetLeftControllerBoolValues(
            leftPrimary2DAxis,
            leftGrip,
            leftGripButton,
            leftMenuButton,
            leftPrimaryButton,
            leftPrimaryTouch,
            leftSecondaryButton,
            leftSecondaryTouch,
            leftTrigger,
            leftTriggerButton,
            leftPrimary2DAxisClick,
            leftPrimary2DAxisTouch,
            leftIsTracked,
            leftTrackingState,
            leftDevicePosition,
            leftDeviceRotation,
            leftDeviceVelocity,
            leftDeviceAngularVelocity);


        oculusLogging.SetRightControllerBoolValues(
             rightPrimary2DAxis,
             rightGrip,
             rightGripButton,
             rightMenuButton,
             rightPrimaryButton,
             rightPrimaryTouch,
             rightSecondaryButton,
             rightSecondaryTouch,
             rightTrigger,
             rightTriggerButton,
             rightPrimary2DAxisClick,
             rightPrimary2DAxisTouch,
             rightIsTracked,
             rightTrackingState,
             rightDevicePosition,
             rightDeviceRotation,
             rightDeviceVelocity,
             rightDeviceAngularVelocity);

        oculusLogging.SetHeadsetBoolValues(
            isUserPresence,
            isHeadSetTracked,
            isHeadSetTrackingState,
            isHeadSetDevicePosition,
            isHeadSetDeviceRotation,
            isHeadSetDeviceVelocity,
            isHeadSetDeviceAngularVelocity,
            isHeadSetDeviceAcceleration,
            isHeadSetDeviceAngularAcceleration,
            isHeadSetLeftEyePosition,
            isHeadSetLeftEyeRotation,
            isHeadSetLeftEyeVelocity,
            isHeadSetLeftEyeAngularVelocity,
            isHeadSetLeftEyeAcceleration,
            isHeadSetLeftEyeAngularAcceleration,
            isHeadSetRightEyePosition,
            isHeadSetRightEyeRotation,
            isHeadSetRightEyeVelocity,
            isHeadSetRightEyeAngularVelocity,
            isHeadSetRightEyeAcceleration,
            isHeadSetRightEyeAngularAcceleration,
            isHeadSetCenterEyePosition,
            isHeadSetCenterEyeRotation,
            isHeadSetCenterEyeVelocity,
            isHeadSetCenterEyeAngularVelocity,
            isHeadSetCenterEyeAcceleration,
            isHeadSetCenterEyeAngularAcceleration,
            isHeadSetBatterieLevel,
            isHeadSetColorCameraAcceleration,
            isHeadSetColorCameraAngularAcceleration,
            isHeadSetColorCameraAngularVelocity,
            isHeadSetColorCameraPosition,
            isHeadSetColorCameraRotation,
            isHeadSetColorCameraVelocity,
            isHeadSetFixationPoint,
            isHeadSetLeftEyeOpenAmount,
            isHeadSetRightEyeOpenAmount);
    }

    private void Update()
    {
        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;



        if (!rightController.isValid)
        {
            InitializeOculusInputs(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref rightController);
        }
        if (!leftController.isValid)
        {
            InitializeOculusInputs(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref leftController);
        }
        if (!headMountedDisplay.isValid)
        {
            InitializeOculusInputs(InputDeviceCharacteristics.HeadMounted, ref headMountedDisplay);
        }

        timePassed += Time.deltaTime;
        if(timePassed > timeBeforeLog)
        {
            timePassed = 0f;
            Debug.Log("Log les valeurs dans le csv");

            if (isList1ToWrite)
            {
                isList1ToWrite = false;
                csvWriter.WriteDataCSV(oculusLogging.datasList1);
                oculusLogging.ClearDatasList1();
            }
            else
            {
                isList1ToWrite = true;
                csvWriter.WriteDataCSV(oculusLogging.datasList2);
                oculusLogging.ClearDatasList2();
            }
        }
        else
        {
            if(isList1ToWrite)
            {
                oculusLogging.GetData(leftController, rightController, headMountedDisplay,1);
            }
            else
            {
                oculusLogging.GetData(leftController, rightController, headMountedDisplay, 2);
            }
        }

        //Debug.Log(headMountedDisplay.TryGetFeatureValue(CommonUsages.eyesData, out Eyes test));
        //if (headMountedDisplay.TryGetFeatureValue(CommonUsages.eyesData, out Eyes eyesData))
        //{
        //    if (isHeadSetLeftEyePosition)
        //    {
        //        if (eyesData.TryGetLeftEyePosition(out Vector3 leftEyePosition))
        //        {
        //            Transform leftEyeTransform = leftEye.GetComponent<Transform>();
        //            leftEyeTransform.transform.position = leftEyePosition;
        //        }
        //    }
        //    if (isHeadSetRightEyePosition)
        //    {
        //        if (eyesData.TryGetRightEyePosition(out Vector3 rightEyePosition))
        //        {
        //            Transform rightEyeTransform = rightEye.GetComponent<Transform>();
        //            rightEyeTransform.transform.position = rightEyePosition;
        //        }
        //    }
        //}

        //if (isHeadSetLeftEyePosition)
        //{
        //    if (headMountedDisplay.TryGetFeatureValue(CommonUsages.leftEyePosition, out Vector3 headsetLeftEyePosition))
        //    {
        //        Transform leftEyeTransform = leftEye.GetComponent<Transform>();
        //        leftEyeTransform.transform.position = headsetLeftEyePosition;
        //    }
        //}

        //if (isHeadSetRightEyePosition)
        //{
        //    if (headMountedDisplay.TryGetFeatureValue(CommonUsages.rightEyePosition, out Vector3 headsetRightEyePosition))
        //    {
        //        Transform rightEyeTransform = rightEye.GetComponent<Transform>();
        //        rightEyeTransform.transform.position = headsetRightEyePosition;
        //    }
        //}
        if (isHeadSetFixationPoint)
        {
            //Debug.Log("Bein coché");
            if (headMountedDisplay.TryGetFeatureValue(CommonUsages.eyesData, out UnityEngine.XR.Eyes yeux))
            {
                Debug.Log("on a de la data des yeux");
                if(yeux.TryGetFixationPoint(out Vector3 point))
                {
                    Debug.Log("On a le point !!");
                }
            }
        }

    }

    private void InitializeOculusInputs(InputDeviceCharacteristics inputCharacteristics, ref InputDevice inputDevice)
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(inputCharacteristics, devices);

        if (devices.Count > 0)
        {
            inputDevice = devices[0];
        }
    }
}
