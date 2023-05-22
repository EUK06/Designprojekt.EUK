using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //l�gga till en InteractionEvent component to this gameobject.
    public bool useEvents;

    //medelande som visas n�r spelaren tittar p� ett interagerbart objekt
    [SerializeField]
    public string promtMessage;
    [SerializeField]

    //denna funktion kallas fr�n v�ran spelare
    public void BaseInteract()
    {
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact()
    {
        //ingen kod i dennna funktion
        //template function som ska bli overriden av v�ra subclasses

    }

}