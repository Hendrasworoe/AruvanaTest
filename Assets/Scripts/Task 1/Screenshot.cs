using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour
{
    [SerializeField] private CanvasGroupController _mainCanvasGroup;
    [SerializeField] private CanvasGroupController _shareCanvasGroup;

    private IEnumerator SS()
    {
        _mainCanvasGroup.ShowCanvas(false);

        yield return new WaitForEndOfFrame();

        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
        tex.Apply();

        SaveResultPicture(tex);

        _shareCanvasGroup.GetComponentInChildren<RawImage>().texture = tex;

        _shareCanvasGroup.ShowCanvas(true);

        ShareToSocialMedia.Instance.SetSharedPicture(tex);

        yield return new WaitUntil(() => _shareCanvasGroup.GetComponent<CanvasGroup>().alpha == 0);

        Destroy(tex);
    }

    private void SaveResultPicture(Texture2D savedPict)
    {
        string pict_name = "Screenshot_" + DateTime.Now.ToString("yyyyMMdd") + ".png";

        NativeGallery.SaveImageToGallery(savedPict, "Marker AR App Screenshots", name);
    }

    public void TakeScreenshot()
    {
        StartCoroutine(SS());
    }
}
