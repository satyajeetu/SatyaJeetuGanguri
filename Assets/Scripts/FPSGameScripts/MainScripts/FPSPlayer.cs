using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayer : Player , IKillable , IAttackable
{

    Wepon_SO CurrentWeapon;

    bool isShooting = false;

    private float lastShot = 0;

    void Awake()
    {
        

    }
    void Start()
    {
        CurrentWeapon = PrimaryWepons[0];
    }

   
    void Update()
    {
        handleInputs();
        
        if (isShooting)
        {
            ShootWithCurrentWeapon();
        }

        
    }

    public void handleInputs()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
        if (Input.GetMouseButtonUp(0))
        {
            stopAttack();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeapon(true, false);
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeWeapon(false, true);
        }
    }



    public void ChangeWeapon( bool isPrimary , bool isFirst)
    {
        if(isPrimary && isFirst)
        {
            CurrentWeapon = PrimaryWepons[0];
        }

        if(isPrimary && !isFirst)
        {
            CurrentWeapon = PrimaryWepons[1];
        }

        if (!isPrimary)
        {
            CurrentWeapon = SecondaryWepon;
        }
    }

    public void ShootWithCurrentWeapon()
    {
        //Instantiate Bullet with force from Wepon Tip

        if (Time.time > CurrentWeapon.fireRate + lastShot)
        {
            var tempBullet = Instantiate(CurrentWeapon.ammoPrefab, transform.position, transform.rotation);

            CurrentWeapon.ammo -= 1;
            
            lastShot = Time.time;
        }


    }

    public void Attack()
    {
        isShooting = true;


    }

    public void stopAttack()
    {
        isShooting = false;
    }

    public void TakeDamage(float damage)
    {

        if (health > damage)
            health -= damage;
        else
            health = 0;
    }


}
