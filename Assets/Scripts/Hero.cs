using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 100.0f;
    public GameObject magicOrb = null;
    public Transform socket = null;
    public float playerHealth = 100.0f;
    public int magicOrbAmount = 20;
    public Color originalColor;
    public Color hitColor = Color.red;


    // Start is called before the first frame update
    void Awake()
    {
        originalColor = this.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        float move = Input.GetAxis("Vertical") * moveSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotateSpeed;
        this.transform.Translate(0, 0, move * Time.deltaTime);
        this.transform.Rotate(0, rotation * Time.deltaTime, 0);

    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (magicOrbAmount > 0)
            {
                magicOrbAmount--;
                GameObject obj = Instantiate(magicOrb, socket.position, socket.rotation);
                obj.name = "magicOrb";
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "cannonball")
        {
            float hit = other.GetComponent<CannonBall>().hitpoint;
            GetHealth(hit);
        }
    }

    void GetHealth(float hit)
    {
        if (playerHealth > 0)
        {
            playerHealth -= hit;
            StartCoroutine(GetHit());
            Debug.Log("PlayerHealth is " + playerHealth);
        }
        else
        {
            Debug.Log("GameOver");
        }
    }

    IEnumerator GetHit()
    {
        this.GetComponent<Renderer>().material.color = hitColor;
        yield return new WaitForSeconds(2.0f);
        this.GetComponent<Renderer>().material.color = originalColor;
    }
}
