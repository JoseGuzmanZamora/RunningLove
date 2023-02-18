using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    private Animator anim;
    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate() {
        var horizontalPress = Input.GetAxis("Horizontal");
        var runningPress = Input.GetKey(KeyCode.Space);
        anim.SetBool("isRunning", runningPress);

        var finalPosition = new Vector3(
            runningPress ? horizontalPress : 0, transform.position.y, runningPress ? 1 : 0).normalized * (movementSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(
            new Vector3(
                transform.position.x + finalPosition.x, 
                transform.position.y, 
                transform.position.z + finalPosition.z)
        );
    }
}
