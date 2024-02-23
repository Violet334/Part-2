using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    //declare variables
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    Rigidbody2D rb;
    Animator animator;
    public float happiness;
    public float maxHappiness = 10;
    int maxSceneIndex = 3;
    // Start is called before the first frame update
    void Start()
    {
        //get components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //character movement
        movement = destination - (Vector2)transform.position;
        //stop character figeting
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        //update movement from mouse click
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("move", movement.magnitude);
    }

    public void hurt()
    {
        //play hurt animation
        animator.SetTrigger("hurt");
    }
    //increase happiness bar
    public void Happy(float value)
    {
        happiness += value;
        happiness = Mathf.Clamp(happiness, 0, maxHappiness);
        animator.SetTrigger("happy");

        if(happiness == maxHappiness)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
            if (currentSceneIndex == maxSceneIndex)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
