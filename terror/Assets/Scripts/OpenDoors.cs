using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public float rayDistance = 5f; 
    public KeyCode interactionKey = KeyCode.E; 
    public GameObject chaveDaEscada;

    void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    // Destrói o objeto
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("DoorEscada") && chaveDaEscada != null && chaveDaEscada.activeInHierarchy)
                {
                    Destroy(chaveDaEscada);

                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
