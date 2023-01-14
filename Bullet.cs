using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    UiScore uiKills;

    public Vector3 dir;
    public float bulletSpeed = 10;

    private void Awake()
    {
        uiKills = GameObject.Find("Score").GetComponent<UiScore>();
    }

    public void Setup(Vector3 shootDir)
    {
        this.dir = shootDir;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDir));
        Destroy(gameObject, 2f);
        Physics2D.IgnoreLayerCollision(0, 0, true);
    }

    void FixedUpdate()
    {
        transform.position += bulletSpeed * Time.deltaTime * dir.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            uiKills.ChangeScore(collision.gameObject.GetComponent<bouncy_script>().scoreWorth);
        }
        Destroy(this.gameObject);
    }



    //<----------------NEBITNA STVAR, KORISTIM SAMO DA PREVEDEM UGAO---------------->//
    public float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

}

