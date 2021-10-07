using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincharacter : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float movementspeed = 10f;
    [SerializeField] float Xmax;
    [SerializeField] float Xmin;
    [SerializeField] float Ymax;
    [SerializeField] float Ymin;
    [SerializeField] float projectspeed = 10f;
    [SerializeField] float fireperiod = 0.05f;
    Coroutine firingcoroutine;

    float leftboundary = 0.0614f;
    float rightboundary = 0.9386f;
    float topboundary = 0.975f;
    float bottomboundary = 0.025f;


    // Start is called before the first frame update

    void Start()
    {
        Screenboundaries();
    }



    // Update is called once per frame
    void Update()
    {
        Move();
        fire();
    }

    private void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingcoroutine = StartCoroutine(Firecontinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingcoroutine);
        }
    }
    IEnumerator Firecontinuously()
    {

        while (true)
        {
            GameObject laserX = Instantiate(
                bullet, transform.position, Quaternion.identity);
            laserX.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectspeed);


            yield return new WaitForSeconds(fireperiod);

            /*
         if (laserPrefeb.GetComponent<Transform>().transform.position.y > 10f || 
                laserX.GetComponent<Transform>().transform.position.y > 10f)
          {
                Destroy(laserX);
                Destroy(laserPrefeb);
            }
            */
        }

    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementspeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementspeed;

        var newXpos = Mathf.Clamp(transform.position.x + deltaX, Xmin, Xmax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, Ymin, Ymax);

        transform.position = new Vector2(newXpos, newYpos);
    }

    private void Screenboundaries()
    {
        Camera gamecamera = Camera.main;
        Xmin = gamecamera.ViewportToWorldPoint(new Vector3(leftboundary, 0, 0)).x;
        Xmax = gamecamera.ViewportToWorldPoint(new Vector3(rightboundary, 0, 0)).x;
        Ymin = gamecamera.ViewportToWorldPoint(new Vector3(0, bottomboundary, 0)).y;
        Ymax = gamecamera.ViewportToWorldPoint(new Vector3(0, topboundary, 0)).y;
    }
}
