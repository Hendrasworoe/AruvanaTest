using UnityEngine;

public class ShareToSocialMedia : MonoBehaviour
{
    private static ShareToSocialMedia _instance;
    public static ShareToSocialMedia Instance { get { return _instance; } }

    private Texture2D _pictureShare;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void Share()
    {
        new NativeShare()
            .AddFile(_pictureShare)
            .SetSubject("Look what I see")
            .SetText("Share your experience with AR")
            .Share();
    }

    public void SetSharedPicture(Texture2D pict)
    {
        _pictureShare = pict;
    }
}
