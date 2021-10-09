using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float movementspeed = 10f;
    [SerializeField] float Xmax;
    [SerializeField] float Xmin;
    [SerializeField] float Ymax;
    [SerializeField] float Ymin;
    [SerializeField] float projectspeed = 10f;
    [SerializeField] float fireperiod = 0.05f;
    [SerializeField] float shootspeed = 3f;
    Coroutine firingcoroutine;

    void Start()
    {
        
    }

    
    void Update()
    {
        Move();
        fire();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementspeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementspeed;

       // var newXpos = Mathf.Clamp(transform.position.x + deltaX, Xmin, Xmax);
       // var newYpos = Mathf.Clamp(transform.position.y + deltaY, Ymin, Ymax);

        var newXpos = transform.position.x + deltaX;
        var newYpos = transform.position.y + deltaY;
        transform.position = new Vector2(newXpos, newYpos);
    }
    private void fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            GameObject bulletX = 
                Instantiate(bullet, 
                transform.position,
                Quaternion.identity) as GameObject;

            //Êó˜ËÎ»ÖÃ
            Vector2 mousepos = Input.mousePosition;
            Vector2 objectpos = transform.position;
            Vector2 direction = mousepos - objectpos;
            //direction.z = 0f;
            direction = direction.normalized;
            //ÞD
            bulletX.transform.up = direction;

            // ÒÆ„Ó

            bulletX.GetComponent<Rigidbody2D>().velocity = direction*shootspeed;
            //  bulletX.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectspeed);
        }


        /*
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
            GameObject bulletx = Instantiate(
                bullet, transform.position, Quaternion.identity);
            bulletx.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectspeed);

   
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


