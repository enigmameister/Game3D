using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gun : MonoBehaviour
{
    public Animator gunAnims;
    public AudioSource shotSound;
    public AudioSource reload; 
    public WeaponSwitch WS;  
    public Pickup pickup;
    public GameObject muzzleFlash, bulletHoleGraphic;
  
    public int damage;
   
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShoots;
    public int maxammo, bulletsPerTap; 
    public bool allowButtonHold;
    int ammo, bulletsShot;

    bool shooting, readyToShoot, reloading; 
    
    public Camera fpsCam; 
    public Transform attackPoint; 
    public RaycastHit rayHit; 
    public LayerMask whatIsEnemy;

    public float camShakeMagnitude, camShakeDuratoin;
    public TextMeshProUGUI ammoCount;
 
    private void Awake()
    {
        ammo = maxammo;
        readyToShoot = true;

    }

    private void Update()
    {
        if (pickup.equip)
        {
            MyInput();
            ammoCount.SetText(ammo + "|" + maxammo);

            
            if (Input.GetKey(KeyCode.F))
            {
                gunAnims.SetTrigger("Looking");
            }

        }
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && ammo < maxammo && !reloading)
                                                                         
            Reload();  


        if (readyToShoot && shooting && !reloading && ammo > 0)
                                                                
        {
            bulletsShot = bulletsPerTap;                
            shotSound.Play();                                   
            Shoot();                                        
            gunAnims.SetTrigger("Shooting");                
        }
    
    }
     private void Shoot() 
    {
        readyToShoot = false;
        // rozrzut
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            /* skrypt do przeciwnika 
            if (rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
            */
        }

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
  
        


        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        ammo--;
        maxammo--;
        bulletsShot--; 

        Invoke("ResetShot", timeBetweenShooting);
         
        if (bulletsShot > 0 && ammo > 0)
        {
            Invoke("Shoot", timeBetweenShoots);
        }
 
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.collider.GetComponent<Damagable>() != null) 
            {
                hit.collider.GetComponent<Damagable>().TakeDamage(damage, hit.point, hit.normal);
            }

            else if (hit.collider.GetComponent<DamagableShooting>() != null)   
            {
                hit.collider.GetComponent<DamagableShooting>().TakeDamage(damage, hit.point, hit.normal);
            }
        }
    }

    private void ResetShot() 
    { 
          readyToShoot = true; 

    }
    private void Reload() 
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); 
        reload.Play();                   
        gunAnims.SetTrigger("Reload");   
    }

    private void ReloadFinished() 
    {
        ammo = maxammo; 
        reloading = false; 
    }
}