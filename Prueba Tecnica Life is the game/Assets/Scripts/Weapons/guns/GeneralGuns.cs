using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneralGuns :MonoBehaviour
{
    public bool Isgrabed { get; set; }
    protected string nameWeapon;
    protected int magazine;
    protected float cadence;
    protected int ammo;

    protected  InputManager control;
    bool canShoot=true;
  

    public virtual void begin()
    {
        control = FindObjectOfType<InputManager>();
        control.inputs.Character.interact.started += x => CanShoot();
        control.inputs.Character.Reload.started += x => Reload();
    }
    public  void CanShoot()
    {
        
        if (canShoot &&Isgrabed)
        {
            StartCoroutine(ShootWithCadence(cadence));
        }
    }
    public abstract void Shoot();
    public virtual void Reload() { }
    public virtual int Reload( int magazine,int ammo)
    {
        return ammo-magazine;
    }
  
 
   public IEnumerator ShootWithCadence(float cadence)
   {

        canShoot = false;
        Shoot();
        yield return new WaitForSeconds(cadence);
        canShoot = true;
   }

    
}

