using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class printTargetDisplayed : MonoBehaviour, ITrackableEventHandler
{
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        //if(newStatus == TrackableBehaviour.Status.TRACKED) Debug.Log()
        Debug.Log(GetComponent<TrackableBehaviour>().TrackableName);
    }
}
