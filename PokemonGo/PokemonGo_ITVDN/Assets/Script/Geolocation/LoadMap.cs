using UnityEngine;
using System.Collections;

public class LoadMap : MonoBehaviour
{
    const string ConsumerKey = "UtRpyiTLdvEEWKmCxpNTGX5IB1kUe644";

    public Renderer maprender;

    /// <summary>
    /// Latitude, Longitude
    /// </summary>
    private Vector2 PlayerPosition =
       new Vector2(50.254620f, 28.658708f);

    private int _zoom = 17;
    private string _maptype = "map";
    private string _url;

    private void Start()
    {
        StartLoadMap(PlayerPosition);
    }


    private void StartLoadMap(Vector2 playerPosition)
    {
        _url = "http://open.mapquestapi.com/staticmap/v4/getmap?key=" + ConsumerKey
            + "&size=1280,1280&zoom=" + _zoom
            + "&type=" + _maptype
            + "&center=" + PlayerPosition.x + "," + PlayerPosition.y;

        StartCoroutine(LoadImage());
    }

    private IEnumerator LoadImage()
    {
        WWW www = new WWW(_url);
        while (!www.isDone)
        {
            yield return null;
        }

        if (www.error == null)
        {
            yield return new WaitForSeconds(0.5f);
            maprender.material.mainTexture = null;
            Texture2D tmp;
            tmp = new Texture2D(1280, 1280, TextureFormat.RGB24, false);
            maprender.material.mainTexture = tmp;
            www.LoadImageIntoTexture(tmp);
        }
        else
        {
            yield return new WaitForSeconds(1);
            maprender.material.mainTexture = null;
        }

        maprender.enabled = true;
    }
}
