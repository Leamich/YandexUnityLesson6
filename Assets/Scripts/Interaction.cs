using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interaction : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) {

            if (hit.collider.TryGetComponent(out Clickable clickable)) {
                if (Input.GetMouseButtonDown(0)) {
                    clickable.Hit();
                }
            }
            
            if (hit.collider.TryGetComponent(out Hoverable hoverable))
            {
                Debug.Log(hoverable);
                hoverable.OnHover();
            }
        }

    }
}
