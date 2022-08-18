using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*speed*Time.deltaTime);
        if (GameManager.instance.gameOver==GameStates.Game_Over || gameObject.transform.position.y > 3)
        {
            Destroy(gameObject);
        }
    }
}
