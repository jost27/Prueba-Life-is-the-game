using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicGun : GeneralGuns
{
    public TypeGun gun;
    public GameObject bullet;
   
    [SerializeField]
    Transform bulletsocket;

    [SerializeField]
    float projectilforce;
    GameObject _bullet;
    private void Start()
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
        _bullet=Instantiate(bullet,bulletsocket.position,bulletsocket.rotation);
      
        _bullet.GetComponent<Rigidbody>().AddForce(bulletsocket.forward* projectilforce );
        Destroy(_bullet,4);
    }

  
}
