using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
  
    public GameObject HandModelPrefap;
    

    private InputDevice targetDevice;
    private GameObject spawnHandModel;
    private Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        init();
    }
    void init(){
        List<InputDevice> devices = new List<InputDevice>();
            InputDevices.GetDevices(devices);

            foreach (var item in devices){
                Debug.Log(item.name + item.characteristics);
            }

            if(devices.Count > 0){
                targetDevice = devices[0];
            }
            else{
                Debug.LogError("Didn't find controller");
                spawnHandModel = Instantiate(HandModelPrefap, transform);
            }
            spawnHandModel = Instantiate(HandModelPrefap, transform);
            handAnimator = spawnHandModel.GetComponent<Animator>();

    }
    void UpdateHandAnimation(){
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)){
            handAnimator.SetFloat("Trigger",triggerValue);
        }
        else{
            handAnimator.SetFloat("Trigger",0);

        }
           if(targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue)){
            handAnimator.SetFloat("Grip",gripValue);
        }
        else{
            handAnimator.SetFloat("Grip",0);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!targetDevice.isValid){
            init();
        }
        else{
            spawnHandModel.SetActive(true);
            UpdateHandAnimation();
            targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
            if(primaryButtonValue)
                Debug.Log("Pressing Primary Button");
            targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
            if(triggerValue > 0.1f)
                Debug.Log("TriggerValue : " + triggerValue);
            targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
            if(primary2DAxisValue != Vector2.zero)
                Debug.Log("Analog Stick : " + primary2DAxisValue);
        }
    }
}
