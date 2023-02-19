using UnityEngine;

public class CanvasGroupController : MonoBehaviour
{
    private CanvasGroup _itsCanvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        _itsCanvasGroup = GetComponent<CanvasGroup>();
    }

    public void ShowCanvas(bool isShow)
    {
        _itsCanvasGroup.alpha = isShow ? 1f : 0f;
        _itsCanvasGroup.blocksRaycasts = isShow;
        _itsCanvasGroup.interactable = isShow;
    }
}
