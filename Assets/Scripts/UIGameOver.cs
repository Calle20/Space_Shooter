using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    public Image overlay;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver==GameStates.Game_Over && textMesh.enabled == false)
        {
            textMesh.enabled = true;
            overlay.enabled = true;
        }
    }
}
