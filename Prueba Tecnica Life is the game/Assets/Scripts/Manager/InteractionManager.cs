using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    GameObject PressF;
    [SerializeField]
    Transform socketGun;
    [SerializeField]
    Transform enviroment;
    [SerializeField]
    InputManager inputManager;
    [HideInInspector]
    public int Id;

  
    GameObject currentgun=null;
    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();

        CancelGunDetected();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GunDetected(GameObject gunselect)
    {
    
        
        PressF.SetActive(true);
        
        if (inputManager.canGrab)
        {
            if (currentgun != null)
            {
                DropGun();
            }
            currentgun = gunselect;

            gunselect.transform.parent = socketGun;
            gunselect.transform.position = Vector3.zero;
            gunselect.transform.localPosition = Vector3.zero;
            gunselect.transform.rotation = Quaternion.Euler(0,0,0);
            gunselect.transform.localRotation = Quaternion.Euler(0,0,0);
            gunselect.GetComponent<Rigidbody>().isKinematic = true;
            gunselect.GetComponent<GeneralGuns>().Isgrabed = true;
        }
    }
    public void CancelGunDetected()
    {
        PressF.SetActive(false);
    }
    public void DropGun()
    {
        currentgun.transform.parent = enviroment;
        currentgun.GetComponent<Rigidbody>().isKinematic = false;
        currentgun.GetComponent<GeneralGuns>().Isgrabed = true;
        currentgun = null;
    }
}
