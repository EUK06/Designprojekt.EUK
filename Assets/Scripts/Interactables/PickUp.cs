using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{

    public GameObject Cube;
    public int scoreValue = 1;

    protected override void Interact()
    {
        GameManager.instance.AddScore(scoreValue);
        base.Interact();
        Destroy(Cube);
    }

    
}


