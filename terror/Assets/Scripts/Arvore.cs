using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour
{
    public float raycastDistance = 2f;
    public GameObject Machado; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Tree") && Machado.activeInHierarchy)
                {
                    Destroy(hit.collider.gameObject); 
                    Destroy(Machado); 
                }
            }
        }
    }
}
