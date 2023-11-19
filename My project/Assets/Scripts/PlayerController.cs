using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float horizontal;
    float vertical;
    [SerializeField] float rotationSpeed;
    [SerializeField] float speed;
    [SerializeField] GameManager gameManager;
    private void Awake() {
        rb=GetComponent<Rigidbody>();
    }
    private void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(transform.position.y<=-2 || transform.position.z<=-15){
            gameManager.LoseEvento();
        }
    }
    private void FixedUpdate() {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        rb.velocity = new Vector3(horizontal*speed,rb.velocity.y,vertical*speed);
    }
}
