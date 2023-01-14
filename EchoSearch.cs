using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoSearch : MonoBehaviour
{
    ShootBullet shootbullet;
    CircleCollider2D cc;
    internal Vector3 shootDir;
    internal bool detected = false;
    public int expandRadius = 10;
    public float echoDelay = 0.001f;
    
    
    bool canShoot = true;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 7, true);
        Physics2D.IgnoreLayerCollision(7, 7, true);
        shootbullet = GetComponent<ShootBullet>();
        cc = gameObject.GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        this.canShoot = shootbullet.canShoot;
        if (!detected) {
            detected = true;
            StartCoroutine(Expand());     
        }
    }

    IEnumerator Expand()
    {
        cc.radius = 0.5f;
        if (canShoot)
        {
            while (cc.radius <= (0.1 * expandRadius))
            {
                cc.radius += 0.1f;
                if (!detected) { break; }
                yield return new WaitForSeconds(echoDelay);
            }
        }
        else
        {
            detected = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        shootDir = collision.gameObject.transform.position - gameObject.transform.position;
        shootbullet.Shooting();      
        detected = false;        
    }
}
