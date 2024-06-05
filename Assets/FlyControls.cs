using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyControls : MonoBehaviour
{
    void Update()
    {
        var forward = Camera.main.transform.forward;
        var rot = Camera.main.transform.rotation;
        
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickLeft)) transform.Translate(rot * Vector3.left);
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickRight)) transform.Translate(rot * Vector3.right);
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickUp)) transform.Translate(Vector3.up);
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickDown)) transform.Translate(Vector3.down);

        if (OVRInput.Get(OVRInput.RawButton.RThumbstickLeft)) transform.Translate(rot * Vector3.left);
        if (OVRInput.Get(OVRInput.RawButton.RThumbstickRight)) transform.Translate(rot * Vector3.right);
        if (OVRInput.Get(OVRInput.RawButton.RThumbstickUp)) transform.Translate(forward);
        if (OVRInput.Get(OVRInput.RawButton.RThumbstickDown)) transform.Translate(-forward);
    }
}