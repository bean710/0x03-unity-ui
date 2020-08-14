using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 200;
    public int health = 5;

    private Rigidbody rb3d;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        rb3d = GetComponent<Rigidbody>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = movement * speed * Time.deltaTime;
        rb3d.AddForce(movement);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Pickup")
        {
            score++;
            Debug.Log($"Score: {score}");
            Destroy(col.gameObject);
        }
        else if (col.tag == "Trap")
        {
            health--;
            Debug.Log($"Health: {health}");
        }
    }
}
