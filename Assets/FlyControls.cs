using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyControls : MonoBehaviour
{
    public float speed = .1f;
    public OVRHand ovrHand;
    void Update()
    {
        var forward = Camera.main.transform.forward;
        var rot = Camera.main.transform.rotation;

        if (OVRInput.Get(OVRInput.RawButton.LThumbstickLeft)) transform.Translate(rot * Vector3.left * speed);
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickRight)) transform.Translate(rot * Vector3.right * speed);
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickUp)) transform.Translate(Vector3.up * speed);
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickDown)) transform.Translate(Vector3.down * speed);

        if (OVRInput.Get(OVRInput.RawButton.RThumbstickLeft)) transform.Translate(rot * Vector3.left * speed);
        if (OVRInput.Get(OVRInput.RawButton.RThumbstickRight)) transform.Translate(rot * Vector3.right * speed);
        if (OVRInput.Get(OVRInput.RawButton.RThumbstickUp)) transform.Translate(forward * speed);
        if (OVRInput.Get(OVRInput.RawButton.RThumbstickDown)) transform.Translate(-forward * speed);

        if (ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index)) transform.Translate(forward * speed);
        if (ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Middle)) transform.Translate(-forward * speed);
        if (ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Ring)) transform.Translate(Vector3.up * speed);
        if (ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky)) transform.Translate(Vector3.down * speed);
    }
}