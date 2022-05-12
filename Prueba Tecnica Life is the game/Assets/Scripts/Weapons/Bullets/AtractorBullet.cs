using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtractorBullet : MonoBehaviour
{
   
    public Transform enviroment;
    [SerializeField]
    float rotationMaxSpeed=100;
   
    public float timeWork;
    float rotationSpeed=15;
    bool cancelAtractor = true;
    Vector3 direction;

    private void Start()
    {
        GetComponent<SphereCollider>().isTrigger = true;
        Invoke("CancelAtractor",timeWork);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        rotationSpeed=Mathf.Clamp(rotationSpeed+ 0.5f,15f,rotationMaxSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null&&!cancelAtractor)
        {
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().AddForce(Vector3.up*Random.Range(0.01f,0.1f),ForceMode.Impulse);
            other.GetComponent<Rigidbody>().AddForce((transform.position-other.transform.position)*Random.Range(0.1f,0.8f));
            other.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            //Vector3
            //other.GetComponent<Rigidbody>().AddForce;
        }
    }
   

   
    public void CancelAtractor()
    {
        cancelAtractor = true;
        int numchild = this.gameObject.transform.childCount;
        for (int i= numchild-1; i>=0;i--)
        {
            Transform currentrans = transform.GetChild(i);
            currentrans.SetParent(enviroment);
            currentrans.GetComponent<Rigidbody>().useGravity = true;
        }
        GetComponent<SphereCollider>().isTrigger = false;
    }

    private void OnEnable()
    {
        cancelAtractor = false;
    }
    private void OnDisable()
    {
        CancelAtractor();
    }
}
