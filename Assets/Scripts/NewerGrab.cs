using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NewerGrab : XRGrabInteractable
{
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;
    
    protected override void OnSelectEntering (SelectEnterEventArgs args){
        base.OnSelectEntering(args);
        StoreInteractor(args);
        MatchAttachmentPoints(args);
    }
    
    private void StoreInteractor(XRBaseInteractor interactor){
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.localRotation;
    }
    private void MatchAttachmentPoints(XRBaseInteractor interactor){
        bool hasAttach = attachTransform != null;
        interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }
    protected override void OnSelectExiting(SelectEnterEventArgs args){
        base.OnSelectExiting(args);
        ResetAttacmentPoint(args);
        ClearInteractor(args);
    }

    private void ResetAttacmentPoint(XRBaseInteractor interactor){
        interactor.attachTransform.localPosition = interactorPosition;
        interactor.attachTransform.localRotation = interactorRotation;
    }
    private void ClearInteractor(XRBaseInteractor interactor){
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }
   
}
