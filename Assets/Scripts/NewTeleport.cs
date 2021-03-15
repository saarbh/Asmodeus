using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NewTeleport : XRGrabInteractable
{
    public string DialogVoice;
    private Vector3 interactorPosition = Vector3.zero;

    private Quaternion interactorRotation = Quaternion.identity;
   
    GameObject[] puzzleObjects;
    List<XRBaseInteractable> interactables = new List<XRBaseInteractable>();

    protected override void OnSelectEntering (XRBaseInteractor interactor){
        Debug.Log(interactor);
    }
    
    protected override void OnSelectExiting(XRBaseInteractor interactor){
        Debug.Log("Exit");
    }
}
