using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterState : MonoBehaviour
{
    public GameObject cam;
    public bool isGrounded;
    public string colliderTag;


    private void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    private void Update()
    {
        if(transform.position.y < 0.95)
        {
            cam.transform.parent = null;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision incollision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision outcollision)
    {
        isGrounded = false;
    }
}
