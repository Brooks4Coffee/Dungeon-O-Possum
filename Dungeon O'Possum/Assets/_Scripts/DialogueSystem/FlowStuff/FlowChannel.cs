using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Basically creating a whole menu thing for us to make objects, along with some methods with event stuff 

[CreateAssetMenu(menuName = "Scriptable Objects/Flow/Flow Channel")]
public class FlowChannel : ScriptableObject   {
    public delegate void FlowStateCallback(FlowState state);    //i think these are used in the other flow scripts, so I'm keeping them public just in case
    public FlowStateCallback OnFlowStateRequested;
    public FlowStateCallback OnFlowStateChanged;

    public void RaiseFlowStateRequest(FlowState state)  { OnFlowStateRequested?.Invoke(state);  }
    public void RaiseFlowStateChanged(FlowState state)  { OnFlowStateChanged?.Invoke(state); }
}