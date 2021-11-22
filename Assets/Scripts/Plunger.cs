using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Plunger : MonoBehaviour
{
    float power;
    float maxPower = 2f;
    float powerCountPerTrick = 1;

    public Animator plungerAnim;

    Rigidbody ballRb;
    ContactPoint contact;

    bool ballReady;

    void Update()
    {
        if (ballReady)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (power <= maxPower)
                {
                    power += powerCountPerTrick * Time.deltaTime;
                }

                plungerAnim.SetBool("activate", true);
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                if (ballRb != null)
                {
                    ballRb.AddForce(-1 * power * contact.normal, ForceMode.Impulse);
                }

                plungerAnim.SetBool("activate", false);
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        ballReady = true;
        power = 0f;
        contact = col.contacts[0];
        ballRb = contact.otherCollider.attachedRigidbody;
    }

    private void OnCollisionExit(Collision col)
    {
        ballReady = false;
        ballRb = null;
    }
}
