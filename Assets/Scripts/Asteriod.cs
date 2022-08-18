using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    public float Speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(180, 180, 0) * Time.deltaTime);
        transform.Translate(Vector3.down * Speed * Time.deltaTime, Space.World);
        if (GameManager.instance.gameOver == GameStates.Game_Over || gameObject.transform.position.y < -16) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
            GameManager.instance.score += 1;
            Destroy(other.gameObject);
        }
    }
}

