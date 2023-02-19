using UnityEngine;

public class ObjectBlinking : MonoBehaviour
{
    [SerializeField] private float _blinkSpeed = 5f;
    private Renderer _itsRenderer;

    private Color _originColor;
    private Color _transparent;

    // Start is called before the first frame update
    void Start()
    {
        _itsRenderer = GetComponent<Renderer>();

        _originColor = _itsRenderer.material.color;
        _transparent = new Color(_originColor.r, _originColor.g, _originColor.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        _itsRenderer.material.color = Color.Lerp(_originColor, _transparent, Mathf.PingPong(Time.time * _blinkSpeed, 1));
    }
}
