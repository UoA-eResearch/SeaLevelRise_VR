using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRUIInput : MonoBehaviour {

    private SteamVR_TrackedController _controller;

    private void OnEnable()
    {
        _controller = GetComponent<SteamVR_TrackedController>();
        _controller.TriggerClicked += HandleTriggerClicked;
    }

    private void OnDisable()
    {
        _controller.TriggerClicked -= HandleTriggerClicked;
    }

    
    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        
    }
}
