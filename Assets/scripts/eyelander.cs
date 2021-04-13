using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eyelander : MonoBehaviour
{


   [SerializeField]
    float maxRelativeVelocity; 

  [SerializeField]
    float thrustForce = 150f;

    [SerializeField]
    float torqueForce = 25f;

    [SerializeField] float fuel = 500f;
    [SerializeField] float fuelDecrease = 10f;
    [SerializeField] float fuelDecreaseB = 5f;

    [SerializeField]
    float maxRotation = 10f;

    [SerializeField] Text fuelText;

    private void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if (fuel > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(thrustForce * transform.up * Time.deltaTime);
                fuel -= fuelDecrease * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (fuel > 0)
            {
                GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
                fuel -= fuelDecreaseB * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (fuel > 0)
            {
                GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);
                fuel -= fuelDecreaseB * Time.deltaTime;
            }
        }

        fuelText.text = "FuelAmount: " + Mathf.RoundToInt(fuel).ToString();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Aterrei!");
            if(collision.relativeVelocity.magnitude > maxRelativeVelocity || Mathf.Abs(transform.localEulerAngles.z) > maxRotation)
            {
                Debug.Log("Mas explodi :(");
            }
        }
        else
        {
            Debug.Log("Bati na lua :(");
        }
    }
}