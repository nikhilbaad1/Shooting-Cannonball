using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public int hitpoint = 20;
    public float minForce = 400.0f;
    public float maxForce = 700.0f;
    public AudioClip audioHit = null;
    public AudioClip audioClip = null;
   public  ParticleSystem particle = null;
    private bool isActive = true;
    public float delayTime = 2.0f;

    private void Awake()
    {
        this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, GetRandomValue(), GetRandomValue()));
        this.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }

    float GetRandomValue()
    {
        return Random.Range(minForce, maxForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            isActive = false;
            this.GetComponent<AudioSource>().PlayOneShot(audioHit);
            //particle do something
            StartCoroutine(DisableParticle());

        }
    }

    IEnumerator DisableParticle()
    {
        yield return new WaitForSeconds(delayTime);
        var emi = particle.emission;
        emi.enabled = false;
        hitpoint = 0;
    }

}
