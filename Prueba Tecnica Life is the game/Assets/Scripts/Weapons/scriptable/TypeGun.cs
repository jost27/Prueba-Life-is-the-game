using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "new Gun", menuName = "Gun")]
public class TypeGun : ScriptableObject
{
    public string GunName;
    [Tooltip("number of shots per reload")]
    public int MagazineGun;
    public int Ammo;
    public ShotType Shot;
    
    [Range(0f,5f)]
    public float Cadence=0.3f;

}
public enum ShotType
{
    Parabolic, Atractor,Airjab,Teleport,None
}
