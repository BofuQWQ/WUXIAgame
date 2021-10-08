using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    [SerializeField] float movementspeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementspeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementspeed;

        // var newXpos = Mathf.Clamp(transform.position.x + deltaX, Xmin, Xmax);
        // var newYpos = Mathf.Clamp(transform.position.y + deltaY, Ymin, Ymax);

        var newXpos = transform.position.x + deltaX;
        var newYpos = transform.position.y + deltaY;
        transform.position = new Vector3(newXpos, newYpos, -10);
    }
}
