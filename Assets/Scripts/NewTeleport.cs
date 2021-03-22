using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NewTeleport : XRGrabInteractable
{
    public GameObject particales;
    private Vector3 interactorPosition = Vector3.zero;

    private Quaternion interactorRotation = Quaternion.identity;
   
    GameObject[] puzzleObjects;
   
    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        Debug.Log("Teleoport"+interactor.attachTransform.gameObject.name);
        FindObjectOfType<GameObject>().SetActive(particales);
    }
    
    protected override void OnSelectExiting(XRBaseInteractor interactor){
        Debug.Log("Exit NewTeleport");
    }
}
