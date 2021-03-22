using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioEffect : XRGrabInteractable
{
    public string DialogVoice;
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;
    GameObject dora;
    GameObject[] puzzleObjects;
    List<XRBaseInteractable> interactables = new List<XRBaseInteractable>();

    void Start() {
        Debug.Log("Audio Played");
    }
    protected override void OnSelectEntering (XRBaseInteractor interactor){

     
        FindObjectOfType<AudioManager>().Play(DialogVoice);

    }
    
    protected override void OnSelectExiting(XRBaseInteractor interactor){
        Debug.Log("Audio play ended");

    }
}
