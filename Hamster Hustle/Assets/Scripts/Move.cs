using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -3) * Time.deltaTime;        
    }


    //This code is supposed to delete environment left behind so that it does not take up too much memory
    // For some reason this is having a bug with the obstacles
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
           // Destroy(gameObject);
        }
    }
}
