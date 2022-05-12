using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public CharacterControl inputs;

    public bool canInteract=false, canGrab=false, canDrop=false;
    private void Awake()
    {
        inputs = new CharacterControl();
        // read value
        // started
        
        inputs.Character.Grab.performed += x => canGrab = true;
        
        //canceled
       
        inputs.Character.Grab.canceled += x => canGrab= false;

    }


    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }
}
