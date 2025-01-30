using UnityEngine;

public class NumberGenerator : MonoBehaviour, IInteractable // accepts calls via the IInteractable interface
{
    public void Interact(){
        Debug.Log(Random.Range(0, 100)); // code to run when object is interacted with
    }
}
