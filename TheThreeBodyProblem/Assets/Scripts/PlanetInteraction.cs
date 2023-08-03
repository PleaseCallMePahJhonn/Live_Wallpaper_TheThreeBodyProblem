using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInteraction : MonoBehaviour
{
    public GameObject planet1;
    public GameObject planet2;
    public bool isGrabbed = false;
    private Rigidbody2D rBody, rBody1, rBody2;
    //private float G = 6.67f * Mathf.Pow(10, -11);
    private float G = 6.67f;
    // Start is called before the first frame update
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        rBody1 = planet1.GetComponent<Rigidbody2D>();
        rBody2 = planet2.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isGrabbed)
        {
            Vector2 v1 = new Vector2(planet1.transform.position.x - transform.position.x, planet1.transform.position.y - transform.position.y);
            float pow_r1 = Mathf.Pow(v1.x, 2) + Mathf.Pow(v1.y, 2);
            Vector2 v2 = new Vector2(planet2.transform.position.x - transform.position.x, planet2.transform.position.y - transform.position.y);
            float pow_r2 = Mathf.Pow(v2.x, 2) + Mathf.Pow(v2.y, 2);

            float abs_f1 = G * rBody.mass * rBody1.mass / pow_r1;
            float abs_f2 = G * rBody.mass * rBody2.mass / pow_r2;

            Vector2 F1 = v1 * abs_f1;
            Vector2 F2 = v2 * abs_f2;
            Vector2 F = F1 + F2;
            rBody.AddForce(F);
        }
        else
        {
            //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mPosition.x, mPosition.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            print(rBody.velocity);
            float pow_x = Mathf.Pow(rBody.velocity.x, 2);
            float pow_y = Mathf.Pow(rBody.velocity.y, 2);
            float v = Mathf.Pow(pow_x + pow_y, 0.5f);
            if(v>2f)
            {
                rBody.velocity = -0.2f * rBody.velocity;
                print("Velocity Overfast!");
            }
            else
            {
                rBody.velocity = -0.33f * rBody.velocity;
            }
        }
    }
}
