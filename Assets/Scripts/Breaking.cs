using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Breaking : MonoBehaviour
{
    public GameObject destroyedVase;
void OnMouseDown() {
    Debug.Log("Clicked");
    Instantiate(destroyedVase, transform.position, transform.rotation);
    Destroy(gameObject);
}
}
