using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocomotionManager : MonoBehaviour
{
    [Header("Look")]
    [SerializeField]
    Transform mainCharacter;
    
    float gravity;
    
   
    public float speed = 3;

    CharacterController characterController;

    [Header("Look")]
    [SerializeField]
    Transform fPSCamera;

    [SerializeField]
    Vector2 sensitivity=new Vector2(2,2);

    [SerializeField]
    [Range(40, 90)]
    float yClamp=80f;
    ///
    float xRotation;
    //inputs Values
    Vector2 pos, look;

    float mouseX, mouseY;
    CharacterControl inputs;
    
    private void Awake()
    {
        inputs = new CharacterControl();
        // read value
        inputs.Character.Move.performed += context =>pos= context.ReadValue<Vector2>();
        inputs.Character.Look.performed += context =>look= context.ReadValue<Vector2>();
        //stop reading value
        inputs.Character.Move.canceled += x => pos = Vector2.zero;
        inputs.Character.Look.canceled += x => look = Vector2.zero;
    }
    void Start()
    {
        // get CharacterController
        characterController = mainCharacter.gameObject.GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        MoveCharacter();
        LookFPS();
    }

    public void MoveCharacter()
    {
        
        Vector3 move = fPSCamera.right * pos.x + Vector3.up*gravity+mainCharacter.transform.forward* pos.y;
        characterController.Move( move * speed * Time.deltaTime);
    }

    public void LookFPS()
    {
        mouseX = look.x * sensitivity.x * Time.deltaTime;
        mouseY = look.y * sensitivity.y * Time.deltaTime;
        
        // horizontal rotate
        mainCharacter.Rotate(Vector3.up * mouseX);
       
        //vertical rotate
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -yClamp, yClamp);
        fPSCamera.localRotation=Quaternion.Euler(xRotation, 0, 0);

    }

    //Enable and disable the Inputs actions
    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }


}
