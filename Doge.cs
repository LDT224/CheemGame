using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doge : MonoBehaviour
{
    public GameObject boom;
    public float minBoomTime = 2;
    public float maxBoomTime = 4;
    private float boomTime = 0;
    private float lastBoomTime = 0;
    private GameObject Cheem;
    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        UpdateBoomTime();
        Cheem = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= lastBoomTime + boomTime)
        {
            ThroughBoom();
        }
    }

    void UpdateBoomTime()
    {
        lastBoomTime = Time.time;
        boomTime = Random.Range(minBoomTime, maxBoomTime + 1);
    }

    void ThroughBoom()
    {
        GameObject bom = Instantiate(boom, transform.position, Quaternion.identity);
        bom.GetComponent<Boom>().target = Cheem.transform.position;
        UpdateBoomTime();
        gameController.GetComponent<GameController>().GetPoint();
    }
}
