using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public string tagFilter;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerEnter (Collider other){ // 1
        if (other.CompareTag(tagFilter)){ // 2
            Destroy(gameObject); // 3
        }
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
