using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchStatusManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.TryGetComponent(out ShowedObjectBehaviour showed_object))
            {
                Debug.Log(showed_object.name + " is touched");
                showed_object.isTouched = true;
            }
        }
    }
}