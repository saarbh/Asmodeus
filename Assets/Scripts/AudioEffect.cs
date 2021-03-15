using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioEffect : XRGrabInteractable
{
    public string DialogVoice;
    private Vector3 interactorPosition = Vector3.zero;

    private Quaternion interactorRotation = Quaternion.identity;
    

    protected override void OnSelectEntering (XRBaseInteractor interactor){
        Debug.Log("Entered");
        FindObjectOfType<AudioManager>().Play(DialogVoice);
        // base.OnSelectEntering(interactor);
        // StoreInteractor(interactor);
        // MatchAttachmentPoints(interactor);
    }
    
    protected override void OnSelectExiting(XRBaseInteractor interactor){
        Debug.Log("Exit");
        // base.OnSelectExiting(interactor);
        // ResetAttacmentPoint(interactor);
        // ClearInteractor(interactor);
    }
}
