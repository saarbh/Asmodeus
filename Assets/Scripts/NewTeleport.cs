using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NewTeleport : TeleportationAnchor
{
    private Vector3 interactorPosition = Vector3.zero;

    private Quaternion interactorRotation = Quaternion.identity;
   
    void Start() {
        
    }

        protected override bool GenerateTeleportRequest(XRBaseInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
    {
        var show = base.GenerateTeleportRequest(interactor, raycastHit, ref teleportRequest);
        if(raycastHit.collider.name == "Dealer"){
            PuzzleSolver._DealerIn = true;
            Debug.Log("Solved Dealer");
        }
           if(raycastHit.collider.name == "Tourist"){
            PuzzleSolver._TouristIn = true;
            Debug.Log("Solved Tourist");
        }
           if(raycastHit.collider.name == "Kiddo"){
            PuzzleSolver._KiddoIn = true;
            Debug.Log("Solved Kiddo");
        }
            Debug.Log("NEW Teleport"+raycastHit.collider.name);
            // Debug.Log("Component Particle name: "+raycastHit.collider.gameObject.GetComponent<ParticleSystem>().name);
            Debug.Log("Component GameObject name: "+raycastHit.collider.gameObject);
            Debug.Log("Component GameObject name: "+raycastHit.collider.gameObject.GetComponentsInChildren<ParticleSystem>());
            ParticleSystem[] particles = raycastHit.collider.gameObject.GetComponentsInChildren<ParticleSystem>();
            particles[0].Stop();
          
        return show;
        
    }
    
}
