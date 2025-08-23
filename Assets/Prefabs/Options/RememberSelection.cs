using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RememberSelection : MonoBehaviour {
        [SerializeField] private EventSystem eventSystem;
        [SerializeField] private GameObject lastSelectedElement;

    private void Reset() {
        eventSystem = FindObjectOfType<EventSystem>();

        if (!eventSystem) {
            Debug.Log("Did not find an Event System in this scene.", this);
            return;
        }

        lastSelectedElement = eventSystem.firstSelectedGameObject;
    }

    private void Update() {
        if (!eventSystem) {
            return;
        }

        if (eventSystem.currentSelectedGameObject && lastSelectedElement != eventSystem.currentSelectedGameObject) {
            lastSelectedElement = eventSystem.currentSelectedGameObject;
        }

        if (!eventSystem.currentSelectedGameObject && lastSelectedElement) {
            eventSystem.SetSelectedGameObject(lastSelectedElement);
        }
    }
}



public class EventSystemAccess : MonoBehaviour {
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Selectable firstItemToSelect;

    private void Start() {
        if (eventSystem == null) {
            return;
        }

        eventSystem.firstSelectedGameObject = firstItemToSelect.gameObject;
    }
}