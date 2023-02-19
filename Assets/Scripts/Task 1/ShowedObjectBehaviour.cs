using UnityEngine;

public class ShowedObjectBehaviour : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private float _zoomMultiplierSpeed = 1f;
    [SerializeField] private float _maxZoomScale = 2f;

    private void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            Rotating();
        }

        if (Input.touchCount == 2)
        {
            Zooming();
        }

    }

    private void Rotating()
    {
        Touch screen_touch = Input.GetTouch(0);

        if (screen_touch.phase == TouchPhase.Moved)
        {
            transform.Rotate(_rotationSpeed * screen_touch.deltaPosition.y, -1 * _rotationSpeed * screen_touch.deltaPosition.x, 0f);
        }
    }

    private void Zooming()
    {
        Touch first_touch = Input.GetTouch(0);
        Touch second_touch = Input.GetTouch(1);

        Vector2 prev_first_touch = first_touch.position - first_touch.deltaPosition;
        Vector2 prev_second_touch = second_touch.position - second_touch.deltaPosition;

        float prev_delta = (prev_first_touch - prev_second_touch).magnitude;
        float cur_delta = (first_touch.position - second_touch.position).magnitude;

        float zoom_modifier = (first_touch.deltaPosition - second_touch.deltaPosition).magnitude * _zoomMultiplierSpeed;

        if (prev_delta > cur_delta && transform.localScale.x > 0.1f)
        {
            transform.localScale -= Vector3.one * zoom_modifier;
        }
        if (prev_delta < cur_delta && transform.localScale.x < _maxZoomScale)
        {
            transform.localScale += Vector3.one * zoom_modifier;
        }
    }
}
