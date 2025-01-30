using UnityEngine;

interface IInteractable {
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource; // the position of the camera object this script is part of
    public float InteractRange; // how far away the player can interact with objects

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)){
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)){
                    interactObj.Interact();
                }
            }
        }
    }
}
