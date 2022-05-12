using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGun : GeneralGuns
{

    public TypeGun gun;
    public GameObject bullet;
    [SerializeField]
    Transform bulletSocket;
    [SerializeField]
    Transform Teleportholder;
    GameObject teleport;
    int numbteleport=0;
    void Start()
    {
        ammo = gun.Ammo;
        magazine = gun.MagazineGun;
        cadence = gun.Cadence;
        begin();
    }
    public override void begin()
    {

        base.begin();
    }
    public override void Shoot()
    {

        if (numbteleport < 2)
        {
            RaycastHit hit;
            
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(bulletSocket.transform.position, bulletSocket.transform.TransformDirection(Vector3.forward), out hit, 20))
            {
                Vector3 pos = new Vector3(hit.point.x,1,hit.point.z);
                teleport = Instantiate(bullet,pos,Quaternion.identity,Teleportholder);
                teleport.GetComponent<TelportBullet>().TelportHolder = Teleportholder;
                numbteleport++;
            }
        }

    }

    public override void Reload()
    {
        if (!Isgrabed)
            return;

        if(numbteleport>0)
            Destroy(Teleportholder.GetChild(0).gameObject);
        if (numbteleport > 1)
            Destroy(Teleportholder.GetChild(1).gameObject);
        numbteleport = 0;

    }
}
