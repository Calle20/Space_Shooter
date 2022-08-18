using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    public float moveSpeed;
    public GameObject laserObject;
    public GameObject cannonLeft;
    public GameObject cannonRight;
    public TextMeshProUGUI textMeshOver;   
    public TextMeshProUGUI textMeshRestart;
    public Image overlay;

    void Start()
    {
        textMeshOver.text = "Welcome";
        textMeshRestart.text = "Press Enter to start";
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver==GameStates.Ingame)
        {
            Movement();
        }
         Shooting();
    }

    void Movement()
    {
        Vector3 movement = Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -14, 14);
        transform.position = position;
    }
    void Shooting()
    {
        if(Input.GetButtonDown("Fire1")&& GameManager.instance.gameOver==GameStates.Ingame)
        {
            if (GameManager.instance.gameOver==GameStates.Ingame)
            {
                Instantiate(laserObject, cannonRight.transform.position, laserObject.transform.rotation);
                Instantiate(laserObject, cannonLeft.transform.position, laserObject.transform.rotation);
            }
            
        }
        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.Return))
        {
            if (GameManager.instance.gameOver == GameStates.Game_Over)
            {
                EnableSpaceShipRenderer(true);
                GameManager.instance.gameOver = GameStates.Ingame;
                textMeshOver.enabled = false;
                textMeshRestart.enabled = false;
                overlay.enabled = false;
                GameManager.instance.score = 0;
            }
            else if (GameManager.instance.gameOver == GameStates.Start)
            {
                GameManager.instance.gameOver = GameStates.Ingame;
                textMeshOver.text = "Game Over";
                textMeshRestart.text = "Press Enter to Restart";
                textMeshOver.enabled = false;
                textMeshRestart.enabled = false;
                overlay.enabled = false;
                GameManager.instance.score = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asterioid") 
        {
            EnableSpaceShipRenderer(false);
            GameManager.instance.gameOver = GameStates.Game_Over;
        }
    }
    void EnableSpaceShipRenderer(bool enable)
    {
        gameObject.GetComponent<Renderer>().enabled = enable;
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<Renderer>().enabled = enable;
        }  
    }
}
