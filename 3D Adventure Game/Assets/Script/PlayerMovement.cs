using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 0.5f;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * speed);
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Treasure")
        {
            score++;
            Destroy(collision.gameObject);
            Debug.Log("The score is " + score);
        }
        if(collision.gameObject.tag == "ScoreEnemy")
        {
            score--;
        }
        if(collision.gameObject.tag == "DeathEnemy")
        {
            //SceneManagement.LoadScene(SceneManger.GetActiveScene().buildIndex + 1);
        }
        
    }
}
