using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelportBullet : MonoBehaviour
{
    public Transform TelportHolder;

    private void Start()
    {
        transform.SetParent(TelportHolder);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() == null && TelportHolder.childCount < 2) // only must be 2 teleports
            return;
        
        if (TelportHolder.GetChild(0) == this.transform  )
        {           
            Vector3 teleportposition = new Vector3(TelportHolder.GetChild(1).position.x, other.transform.position.y, TelportHolder.GetChild(1).position.z + 2);
            Teleportation(teleportposition, other.gameObject);
        }
        else
        {                       
            Vector3 teleportposition= new Vector3( TelportHolder.GetChild(0).position.x , other.transform.position.y,  TelportHolder.GetChild(0).position.z+2);
            Teleportation(teleportposition, other.gameObject);

        }
            

    }
    void Teleportation(Vector3 pos,GameObject other)
    {
        if (other.GetComponent<CharacterController>() == null)
            return;
        other.GetComponent<CharacterController>().enabled = false;
        other.transform.position = pos;
        other.GetComponent<CharacterController>().enabled = true;
    }
 
    private void OnEnable()
    {
        transform.SetParent(TelportHolder);
    }
}
