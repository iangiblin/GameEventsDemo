using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickEventRaiser : MonoBehaviour
{
    // A Simple targeting tool to test aim & shoot logic in the desktop.

    [SerializeField] private GameEvent _gameEvent;
    
    private Camera _camera;
    
    // ----------------------------------------------------------------
    void Start()
    {
        if (_gameEvent == null)
        {
            Debug.LogError($"You forgot to assign a GameEvent to {this}");
        }
        
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    // ----------------------------------------------------------------
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        
            if (Physics.Raycast(ray, out hit) != false)
            {
                if (hit.collider.gameObject != null)
                {
                    Debug.Log($"Mouse hit point: {hit.point}, on {hit.collider.gameObject}");
                    if (_gameEvent != null)
                    {
                        _gameEvent.Invoke();
                    }
                }
            }
        }
    }
}
