using UnityEngine;


[CreateAssetMenu(fileName = "WeponData", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Wepon_SO : ScriptableObject
{
    public DataTypes.WeaponType WeponType;

    public GameObject WeponPrefab;

    public Sprite weponsprite;

    public int magSize;

    public float fireRate;

    public int ammo;

    public DataTypes.AmmoType ammoType;

    public GameObject ammoPrefab;




}
