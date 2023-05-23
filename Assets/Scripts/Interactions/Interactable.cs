using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //lägga till en InteractionEvent component to this gameobject.
    public bool useEvents;

    //medelande som visas när spelaren tittar på ett interagerbart objekt
    [SerializeField]
    public string promtMessage;
    [SerializeField]

    //denna funktion kallas från våran spelare
    public void BaseInteract()
    {
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact()
    {
        //ingen kod i dennna funktion
        //template function som ska bli overriden av våra subclasses

    }

}