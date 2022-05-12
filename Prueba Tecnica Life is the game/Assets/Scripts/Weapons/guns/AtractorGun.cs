using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtractorGun : GeneralGuns
{
    public TypeGun gun;
    public GameObject bullet;
    [SerializeField]
    Transform bulletSocket;
    [SerializeField]
    Transform enviroment;

    GameObject atractor;
    private void Start()
    {
        ammo = gun.Ammo;
        magazine = gun.MagazineGun;
        cadence = gun.Cadence;
        begin();
    }
    public override void Shoot()
    {
        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(bulletSocket.transform.position, bulletSocket.transform.TransformDirection(Vector3.forward), out hit, 20))
        {
           
            atractor= Instantiate(bullet, hit.point, Quaternion.identity,enviroment);
            atractor.GetComponent<AtractorBullet>().enviroment = enviroment;
            atractor.GetComponent<AtractorBullet>().timeWork = gun.Cadence - 0.5f;
            Destroy(atractor, gun.Cadence);
        }
    }

    public override void begin()
    {
        
        base.begin();
    }
}
