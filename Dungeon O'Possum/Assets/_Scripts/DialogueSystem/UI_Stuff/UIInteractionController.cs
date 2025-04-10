using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIInteractionController : MonoBehaviour  {
    [SerializeField] TextMeshProUGUI m_Text;
    [SerializeField] InteractionInstigator m_WatchedInteractionInstigator;

    void Update() { m_Text.enabled = m_WatchedInteractionInstigator.enabled && m_WatchedInteractionInstigator.HasNearbyInteractables();  }
}