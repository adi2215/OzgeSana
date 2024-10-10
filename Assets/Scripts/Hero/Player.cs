using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    private float horizontalValue;
    private float verticalValue;
    public float moveSpeed = 1f;
    private bool Open_Page = false;
     public GameObject Page;
    
    [SerializeField] public Vector2 movementInput;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;

    public float movementSpeed;
    public CameraFollow Trigger_Stay;
    public AnimUiTAB BoxTab;
    public GameObject Logo;

    public ManagerScene mg;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Logo.SetActive(false);
            if (!Open_Page)
            {
                Page.SetActive(true);
                Open_Page = true;
            }
            else
            {
                Page.SetActive(false);
                Open_Page = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            mg.Aul();
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            mg.Aul();
        }
    }

     //Анимация и Поворот персонажа влево или права
    private void FixedUpdate()
    {
        if (Trigger_Stay.PlayerTrig)
        {
            animator.SetBool("IsMoving", false);
            return;
        }

        if (DialogManager.isActive != true)
        {
            ProcessInputs();
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }

        if (movementInput != Vector2.zero)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    //Ходьба Персонажа
    void ProcessInputs()
    {

        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(horizontalValue, verticalValue);
        movementSpeed = Mathf.Clamp(movementInput.magnitude, 0.0f, 1.0f);

        movementInput.Normalize();
        if (movementInput != Vector2.zero)
        {
            rb.MovePosition(rb.position + movementInput * moveSpeed * movementSpeed * Time.fixedDeltaTime);
        }
    }

}
