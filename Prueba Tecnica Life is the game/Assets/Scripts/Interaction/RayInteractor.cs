using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInteractor : MonoBehaviour
{

    [SerializeField]
    float radiusRay;
    [SerializeField]
    float maxDistanceRay=5;
    [SerializeField]
    LayerMask layer;

    [Header("Manager")]
    [SerializeField]
    InteractionManager interaction;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.SphereCast(transform.position,radiusRay,transform.TransformDirection(Vector3.forward), out hit, maxDistanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.transform.gameObject.GetComponent<GeneralGuns>() )
            {
                
                GameObject gobject =(GameObject) hit.transform.gameObject;
               
               
                interaction.GunDetected(gobject);
                  
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistanceRay, Color.white);
            
                interaction.CancelGunDetected();
        
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        
        Gizmos.DrawWireSphere(transform.position + (transform.TransformDirection(Vector3.forward) * maxDistanceRay), radiusRay);
    }
}
