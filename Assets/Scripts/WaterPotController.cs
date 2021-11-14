using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterPotController : MonoBehaviour
{
    // add speed
    public float speed = 1.0f;
    private Transform target;
    public bool isNearPot = false;
    public GameObject pot;
    Vector3 newPosition;
    Vector3 originalPosition;

    public enum State { noWater, water};
    public State potState;

    public GameObject waterDrop;
    public SpriteRenderer spriteRenderer;
    public Sprite sprout;

    // boolean to check 
    // Start is called before the first frame update
    GameObject timer;
    void Start()
    {
        //potState = State.noWater;
        spriteRenderer = pot.GetComponent<SpriteRenderer>();
        

        waterDrop.SetActive(false);

        pot = GameObject.Find("Flower_Pot");
        newPosition = new Vector2(pot.transform.position.x - 4, pot.transform.position.y + 2);
        originalPosition = new Vector2(transform.position.x, transform.position.y);  
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (isNearPot) {
            transform.position = Vector2.MoveTowards(transform.position, newPosition, 10 * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * -30.0f);
        } else {
            transform.position = Vector2.MoveTowards(transform.position, originalPosition, 10 * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * 0.0f);
        }
        
    }
    void OnMouseDown(){

        if (potState == State.noWater)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if(potState == State.water)
        {
            if (isNearPot)
            {
                isNearPot = false;
            }
            else
            {
                isNearPot = true;
            }
            Debug.Log("Sprite Clicked");

            Invoke("ChangeSprite", 1);
            
            //waterDrop.SetActive(false);
            //transform.position = Vector2.MoveTowards(transform.position, newPosition, 10 * Time.deltaTime);
        }
        
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = sprout;
    }
}
