using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    [Header("Input TextField")]
    [SerializeField] private Text timeInput;
    [SerializeField] private Text speedInput;
    [SerializeField] private Text distanceInput;

    public delegate void InputFieldInfoForCube(float speedInput, float distanceInput);
    public static event InputFieldInfoForCube InputFieldInfoCubeEvent;

    public delegate void InputFieldInfoTimeSpawn(float timeInput);
    public static event InputFieldInfoTimeSpawn InputFieldInfoTimeEvent;

    public static bool timeInputIsActiv;

    private void Start()
    {
        Cube.InstanceCubeEvent.AddListener(OnResetValueInField);
    }

    private void Update()
    {
        if(timeInput.text != "" & speedInput.text != "" & distanceInput.text != "" & !timeInputIsActiv)
        {
            timeInputIsActiv = true;
            InputFieldInfoTimeEvent?.Invoke(float.Parse(timeInput.text));
        }
    }

    private void OnResetValueInField()
    {
        if(speedInput.text != "" && distanceInput.text != "")
            InputFieldInfoCubeEvent?.Invoke(float.Parse(speedInput.text), float.Parse(distanceInput.text));
    }

}
