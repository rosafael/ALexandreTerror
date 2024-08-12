using UnityEngine;

public class PegarIntens : MonoBehaviour
{
    public float raycastDistance = 2f; 
    public GameObject objetoParaHabilitarChaveCasa; 
    public GameObject objetoParaHabilitarMachado;  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("ChaveCasa"))
                {
                    if (objetoParaHabilitarChaveCasa != null)
                    {
                        objetoParaHabilitarChaveCasa.SetActive(true);
                    }

                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("Machado"))
                {
                    if (objetoParaHabilitarMachado != null)
                    {
                        objetoParaHabilitarMachado.SetActive(true);
                    }
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
