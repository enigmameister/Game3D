using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            bulletRB.velocity = this.transform.forward * BulletSpeed;
        }
    }
}
