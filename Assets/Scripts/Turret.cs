using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject cannonball = null;
    public Transform Player = null;
    public float minDelay = 1.0f;
    public float maxDelay = 4.0f;
    public float turretHealth = 100.0f;
    private float delayTime = 0.0f;
    private float lastTime = 0.0f;
    public Color originalColor;
    public Color hitColor = Color.white;


    void Awake()
    {
        originalColor = this.GetComponent<Renderer>().material.color;
    }
    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        Shoot();
    }

    void FollowPlayer()
    {
        this.transform.LookAt(Player);
    }

    void Shoot()
    {
        if (Time.time > delayTime + lastTime)
        {
            lastTime = Time.time;
            delayTime = randomtime();
            GameObject obj = Instantiate(cannonball, this.transform.position, this.transform.rotation) as GameObject;
            obj.name = "cannonball";
        }
    }

    float randomtime()
    {
        return Random.Range(minDelay, maxDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "magicOrb")
        {
            float hit = other.GetComponent<MagicOrb>().hitpoint;
            GetHealth(hit);
        }
    }

    void GetHealth(float hit)
    {
        if (turretHealth > 0)
        {
            turretHealth -= hit;
            StartCoroutine(GetHit());
            Debug.Log("Turret Health is " + turretHealth);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator GetHit()
    {
        this.GetComponent<Renderer>().material.color = hitColor;
        yield return new WaitForSeconds(2.0f);
        this.GetComponent<Renderer>().material.color = originalColor;
    }
}
