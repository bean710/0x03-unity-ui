using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 200;
    public int health = 5;

    private Rigidbody rb3d;
    private int score = 0;

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
        CheckHealth();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = movement * speed * Time.deltaTime;
        rb3d.AddForce(movement);
    }

    private void CheckHealth()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            health = 5;
            score = 0;
            SceneManager.LoadScene("maze");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        switch (col.tag)
        {
            case "Pickup":
                score++;
                Debug.Log($"Score: {score}");
                Destroy(col.gameObject);
                break;
            case "Trap":
                health--;
                Debug.Log($"Health: {health}");
                break;
            case "Goal":
                Debug.Log("You win!");
                break;
        }
    }
}
