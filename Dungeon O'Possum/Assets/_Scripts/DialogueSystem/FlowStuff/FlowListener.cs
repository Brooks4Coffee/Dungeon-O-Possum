using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;





[Serializable]
public class FlowListenerEntry  {
    public FlowState state;
    public UnityEvent events;
}

//Not fun stuff, but basically a helper to the state machine that listens for events and moves around the 'flow' of convo
public class FlowListener : MonoBehaviour   { 

    [SerializeField] FlowChannel channel;
    [SerializeField] FlowListenerEntry[] entries;


    void Awake() {  channel.OnFlowStateChanged += OnFlowStateChanged;  }

    void OnDestroy() {  channel.OnFlowStateChanged -= OnFlowStateChanged;  }

    void OnFlowStateChanged(FlowState state)  {
        FlowListenerEntry foundEntry = Array.Find(entries, x => x.state == state);
        if (foundEntry != null) { foundEntry.events.Invoke();  }
    }
}
