using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArijabBullet : MonoBehaviour
{
    [SerializeField]
    float airjabForce;
    GameObject obj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            Vector3 vec = (transform.position -obj.transform.position ).normalized;
            vec = vec + Vector3.up * airjabForce * Time.deltaTime;
            Debug.Log(vec);
            other.GetComponent<CharacterController>().enabled = false;
            obj.GetComponent<Rigidbody>().AddForce(airjabForce * Time.deltaTime * vec, ForceMode.Impulse);
            other.GetComponent<CharacterController>().enabled = true;
            return;
        }
        if (other.GetComponent<Rigidbody>()!=null)
        {
            Debug.Log("enter");
            obj = other.gameObject;
       

            obj.GetComponent<Rigidbody>().AddForce(airjabForce * Time.deltaTime * (obj.transform.position - transform.position), ForceMode.Impulse);
        }
        
    }
   
    
   

}
