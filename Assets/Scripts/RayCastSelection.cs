using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayCastSelection : XRGrabInteractable
{
    [SerializeField] private string selectableTag = "Selectable";
    XRBaseInteractor interactor ;
    [SerializeField] private Material hightlightmat;
    [SerializeField] private Material defaultmat;
    private Material interactorMat;
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;
    private Transform _selection;
    public Camera maincam;
 
  protected override void OnSelectEntering (XRBaseInteractor interactor){
        base.OnSelectEntering(interactor);
        StoreInteractor(interactor);
        ChangeInteractorMat(interactor);
    }

        private void StoreInteractor(XRBaseInteractor interactor){
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.localRotation;
        interactorMat = interactor.attachTransform.GetComponent<Material>();
    }
    private void ChangeInteractorMat(XRBaseInteractor interactor){

           if(_selection){
            var selectionRender = _selection.GetComponent<Renderer>();
            selectionRender.material = defaultmat;
            _selection = null;
    }
        RaycastHit hit;
        Ray ray = maincam.ScreenPointToRay(interactorPosition);
        if(Physics.Raycast(ray, out hit)){
            Debug.Log("Object Ray detected");
            var selection = hit.transform;
            if(selection.CompareTag(selectableTag)){
                var selectionRender = selection.GetComponent<Renderer>();
                if(selectionRender)
                {
                selectionRender.material = hightlightmat;
                }
                _selection = selection;
            }
        }
    }
    
}
