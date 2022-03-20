using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancer : MonoBehaviour
{
    [SerializeField] private string tagCube = "Cube";

    private PoolerCube poolerCube;

    // Start is called before the first frame update
    private void Start()
    {
        InputField.InputFieldInfoTimeEvent += SetValue;
        poolerCube = PoolerCube.Instance;
        
    }

    private void SetValue(float time)
    {
        StartCoroutine(InstanceCubeCor(time));
    }
   
    private IEnumerator InstanceCubeCor(float time)
    {
        yield return new WaitForSeconds(time);
        poolerCube.SpawnFromPool(tagCube, transform.position, Quaternion.identity);
        InputField.timeInputIsActiv = false;
    }
}
