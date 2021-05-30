using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed = 3;
    public float destroyTime = 2;
    public GameObject explor;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime*-1);

    }
    void OnDestroy()
    {
        GameObject exp = Instantiate(explor, transform.position, Quaternion.identity);
        Destroy(exp, 0.5f);
    }
    
}
