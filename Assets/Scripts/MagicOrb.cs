using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOrb : MonoBehaviour
{
    //speed, hitpoint, shoot sound, hit sound,particle

    public int hitpoint = 10;
    public float speed = 5.0f;
    public AudioClip audioHit = null;
    public AudioClip audioShoot = null;
    public ParticleSystem particle = null;
    private bool canMove = true;
    // Start is called before the first frame update
    void Awake()
    {
        this.GetComponent<AudioSource>().PlayOneShot(audioShoot);
    }

    // Update is called once per frame
    void Update() 
    {
        MoveObject(); 
    }

    void MoveObject()
    {
        if(canMove)
        this.transform.Translate(0,0,speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<AudioSource>().PlayOneShot(audioHit);
        this.GetComponent<Renderer>().enabled = false;
        this.GetComponent<Collider>().enabled = false;
        var emi = particle.emission;
        emi.enabled= false;
        canMove = false;
        Destroy(this.gameObject,audioHit.length);

    }
}
