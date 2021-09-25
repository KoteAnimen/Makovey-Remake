using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float intensity;
    public float smooth;    

    private Quaternion originRotation;    

    private void Start()
    {
        originRotation = transform.localRotation;
    }

    private void Update()
    {        
        UpdateSway();
    }    

    private void UpdateSway()
    {
        //controls
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");
        
        //calculate target rotation
        Quaternion xAngle = Quaternion.AngleAxis(-intensity * xMouse, Vector3.up);
        Quaternion yAngle = Quaternion.AngleAxis(intensity * yMouse, Vector3.right);
        Quaternion targetRotation = originRotation * xAngle * yAngle;
        //rotate towards target rotation
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * smooth);
    }    
}

