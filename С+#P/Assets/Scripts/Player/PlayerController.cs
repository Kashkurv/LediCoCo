using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool goGame;
    public float speed;
    private float moveInput;
    private float moveInputVertikal;
    private float moveInputHorizontal;
    public Joystick joystick;

    private Rigidbody2D rb;

    [SerializeField] private int sortingOrderBase = 500;
    [SerializeField] private int offset;
    private Renderer renderer;
    private GameManager gameManager;
    //[SerializeField] GameObject eggMagnit;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
        gameManager = GameManager.instance;
        //goGame =false;
    }

    private void FixedUpdate() 
    {
        
        /*
        moveInputHorizontal = joystick.Horizontal;
        moveInputVertikal = joystick.Vertical;
        rb.velocity = new Vector2(moveInputHorizontal*speed,moveInputVertikal*speed);
        */
        if(goGame)
        {
        moveInputHorizontal = Input.GetAxis("Horizontal");
        moveInputVertikal = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveInputHorizontal*speed,moveInputVertikal*speed);
        }
       
        //eggMagnit.transform.position = new Vector2(transform.position.x,transform.position.y);
    }
    void LateUpdate()
    {
       
    }
}
