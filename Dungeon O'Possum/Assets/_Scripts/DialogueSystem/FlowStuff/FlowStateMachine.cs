using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TUTORIAL USED: https://www.youtube.com/watch?v=JnPHXoARH80
//State machine stuff
public class FlowStateMachine : MonoBehaviour   {
    [SerializeField] FlowChannel channel;
    [SerializeField] FlowState startupState;

    FlowState currentState;
    public FlowState CurrentState => currentState;

    static FlowStateMachine thisInstance;
    public static FlowStateMachine Instance => thisInstance;


    //usual awake stuff
    private void Awake()   {
        thisInstance = this;
        channel.OnFlowStateRequested += SetFlowState;
    }

    //On start, set up state
    private void Start()   { SetFlowState(startupState); }

    //when death: trigger event
    private void OnDestroy()   {
        channel.OnFlowStateRequested -= SetFlowState;
        thisInstance = null;
    }

    //set current state
    private void SetFlowState(FlowState state)   {
        if (currentState != state)   {
            currentState = state;
            channel.RaiseFlowStateChanged(currentState);
        }
    }
}
