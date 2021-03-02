using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{ //testgithub
    const KeyCode GoTrigger = KeyCode.JoystickButton15;
    [SerializeField] XRNode nodeType = XRNode.RightHand;

    // Update is called once per frame
    void Update()
    {
        //transform rotation en position van de controller
        transform.localPosition = InputTracking.GetLocalPosition(nodeType);
        transform.localRotation = InputTracking.GetLocalRotation(nodeType);
    }
}
