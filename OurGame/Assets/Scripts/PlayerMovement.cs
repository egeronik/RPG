using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap wrld;
    public Tilemap HighlitionMap;
    public TileBase Higlition;



    private Vector2 movementInput;

    private Vector3 direction;


    bool hasMoved;

    public float X;
    public float Y;

    Vector3Int next = new Vector3Int(0,0,0);


    void Start()
    {
       
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if(hit.collider!=null)
        Debug.Log(hit.collider.name);
        GetMovementDirection();



        if(next != HighlitionMap.WorldToCell(transform.position + direction))
        {
            HighlitionMap.SetTile(next, null);
            next = HighlitionMap.WorldToCell(transform.position + direction);
            HighlitionMap.SetTile(next, Higlition);
        }



        if (Input.GetButtonUp("Fire1"))
        {
            hasMoved = false;
        }
        else if (Input.GetButtonDown("Fire1") && !hasMoved)
        {
            hasMoved = true;
            transform.position += direction;
            
           // Vector3Int currentTile = wrld.WorldToCell(transform.position);
            //Debug.Log(wrld.GetTile(currentTile).ToString());
            //Debug.Log(currentTile);

        }

    }

   
    public void GetMovementDirection()
    {

        Vector3 mouse = Input.mousePosition;
        mouse = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(mouse) - transform.position;
        mouse.z = 0;
        //Debug.Log(mouse);

      //  transform.position = mouse;
      
        if (mouse.x < 0)
        {
            if (mouse.y > 1f)
            {
                direction = new Vector3(-X/2, Y/2);
            }
            else if (mouse.y < -1f)
            {
                direction = new Vector3(-X/2, -Y/2);
            }
            else
            {
                direction = new Vector3(-X, 0, 0);
            }
            
        }
        else if (mouse.x > 0)
        {
            if (mouse.y > 1f)
            {
                direction = new Vector3(X/2, Y/2);
            }
            else if (mouse.y < -1f)
            {
                direction = new Vector3(X/2, -Y/2);
            }
            else
            {
                direction = new Vector3(X, 0, 0);
            }

            
            
        }
        

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
    }
}

    

