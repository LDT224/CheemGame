using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheemControl : MonoBehaviour
{
    Vector3 mousePos;
    public float movespeed =5;
    public float minX = -6f;
    public float maxX = 6f;
    public float minY = -4f;
    public float maxY = 4f;
    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos = new Vector3(Mathf.Clamp(mousePos.x,minX,maxX), Mathf.Clamp(mousePos.y,minY,maxY), 0);
        }
        transform.position = Vector3.Lerp(transform.position, mousePos, movespeed * Time.deltaTime);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        gameController.GetComponent<GameController>().Endgame();
    }
}
