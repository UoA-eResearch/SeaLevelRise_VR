
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    void ViveControl(int controllerId)
    {
        /*
        var controller = SteamVR_Controller.Input(controllerId);
        if (controller.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            var v = controller.velocity;
            v.Scale(transform.localScale);
            transform.localPosition += v * .1f;
            transform.Rotate(controller.angularVelocity, Space.World);
        }
        if (controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var s = controller.GetAxis().y;
            float scale = 1.02f;
            if (s < 0)
            {
                scale = .98f;
            }
            transform.localScale *= scale;
        }*/
    }

}
