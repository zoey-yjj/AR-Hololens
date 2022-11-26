using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class NewBehaviourScript : MonoBehaviour, IMixedRealityTouchHandler
{

    public float speed = 3;
    public bool collision = false;
    public Animator anim;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ChangeAnimationOnTouch();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   // private void OnTriggerEnter(Collider collision) {
   //     anim.Play("Doggo_sit");
   // }

   public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
       // string ptrName = eventData.Pointer.PointerName;
        Debug.Log($"Touch started from");
    }
    public void OnTouchCompleted(HandTrackingInputEventData eventData) {
        Debug.Log($"Touch completed from");
    }
    public void OnTouchUpdated(HandTrackingInputEventData eventData) {
        Debug.Log($"Touch updated from");
     }

    public void ChangeAnimationOnTouch()
    {
        // Add and configure the touchable
        var touchable = target.AddComponent<NearInteractionTouchableVolume>();
        touchable.EventsToReceive = TouchableEventType.Pointer;

        //var material = target.GetComponent<Renderer>().material;
        // Change color on pointer down and up
        var pointerHandler = target.AddComponent<PointerHandler>();
        pointerHandler.OnPointerDown.AddListener((e) => anim.SetBool("Collision", true));
        pointerHandler.OnPointerUp.AddListener((e) => anim.SetBool("Collision", false));
    }
}
