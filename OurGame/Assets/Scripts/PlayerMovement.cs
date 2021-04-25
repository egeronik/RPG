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
    public GameObject dialogWindow;
    public float fightChance;

    private Vector3 direction;
    bool hasMoved;
    
    public float X;
    public float Y;

    Vector3Int next = new Vector3Int(0,0,0);


    void Start()
    {
        Vector3 tmp = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));
        transform.position = tmp;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null)
            PlayerPrefs.SetString("Biome", hit.collider.name);
        
        if (StateDataController.dialogWindowAlive)
        {
            HighlitionMap.SetTile(next, null);
            return;
        }

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
            PlayerPrefs.SetFloat("x", transform.position.x);
            PlayerPrefs.SetFloat("y", transform.position.y);
            if (Random.Range(0, 100) < fightChance)
            {
                dialogWindow.SetActive(true);
                StateDataController.dialogWindowAlive = true;
            }

        }

    }

   
    public void GetMovementDirection()
    {

        Vector3 mouse = Input.mousePosition;
        mouse = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenToWorldPoint(mouse) - transform.position;
        mouse.z = 0;
        //Debug.Log(mouse);

      //  transform.position = mouse;
      
        if (mouse.x *32/100 < 0)
        {
            if (mouse.y > 1f*23/100)
            {
                direction = new Vector3(-X, Y);
            }
            else if (mouse.y < -1f * 23 / 100)
            {
                direction = new Vector3(-X, -Y);
            }
            else
            {
                direction = new Vector3(-X, 0, 0);
            }
            
        }
        else if (mouse.x *32/100 > 0)
        {
            if (mouse.y > 1f*23/100)
            {
                direction = new Vector3(X , Y);
            }
            else if (mouse.y < -1f * 23 / 100)
            {
                direction = new Vector3(X , -Y);
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

    

