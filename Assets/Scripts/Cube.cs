using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    private float speed;
    private float distance;

    private float startTime;

    private float travelLenght;
    private Vector3 travelPoint;

    public static UnityEvent InstanceCubeEvent = new UnityEvent();
    private bool setValueActiv;


    private void OnEnable()
    {
        InstanceCubeEvent?.Invoke();
        InputField.InputFieldInfoCubeEvent += SetValue;
    }

    private void SetValue(float speed, float distance)
    {
        this.speed = speed;
        this.distance = distance;

        startTime = Time.time;
        travelLenght = Vector3.Distance(transform.position, Vector3.forward * distance);
        travelPoint = Vector3.forward * distance;

        setValueActiv = true;
    }


    private void Update()
    {

        if(setValueActiv)
        {

            transform.position += (travelPoint - transform.position).normalized * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, travelPoint) < 0.1f || speed == 0)
            {
                transform.position = new Vector3(0, 0, 0);
                gameObject.SetActive(false);
            }
        }

    }
}
