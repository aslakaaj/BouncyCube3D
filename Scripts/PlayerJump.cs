using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 10;
    private Rigidbody rb;
    private SpringJoint spring;
    private GameObject anchor;

    public bool jumpSetting = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        spring = gameObject.GetComponent<SpringJoint>();

        anchor = GameObject.Find("Anchor_Point");
        anchor.transform.Translate(0, rb.transform.position.y + 2, 0);
    }

    void FixedUpdate()
    {
        float jump = Input.GetAxis("Jump");
        anchor.transform.Translate(0, jump * jumpSpeed * Time.fixedDeltaTime, 0);

        if (jump <= 1)
        {
            if (jump == 1)
            {
                jumpSetting = true;
            }
        }

        if (jumpSetting == true && jump < 1)
        {
            rb.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider _anchor)
    {
        if (_anchor.gameObject.tag == "Anchor")
        {
            Debug.Log("TOUCHED");
            Destroy(spring);
        }

    }
}
