using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;


public class Mapbox : MonoBehaviour
{
	public string accessToken;
	public float centerLatitude = 20.858f;
	public float centerLongitude = 39.6479f;
	public float zoom = 9.96f;
	public int bearing = 0;
	public int pitch = 0;

	public enum style { Light, Dark, Streets, OutDoors, Satellite, SatelliteStreets };
	public style mapStyle = style.Streets;

	public enum resolution { low = 1, high = 2 };
	public resolution mapResolution = resolution.low;

	private int mapWidth = 300;
	private int mapHeight = 200;
	private string[] styleStr = new string[] {"light-v10", "dark-v10", "streets-v11", "outdoors-v11", "satellite-v9", "satellite-streets-v11"};
	private string url = "";
	private bool mapIsLoading = false;
	private Rect rect;
	private bool updateMap = true;

	private string accessTokenLast;
	private float centerLatitudeLast = 20.858f;
	private float centerLongitudeLast = 39.6479f;
	private float zoomLast = 9.96f;
	private int bearingLast = 0;
	private int pitchLast = 0;
	private style mapStyleLast = style.Streets;
	private resolution mapResolutionLast = resolution.low;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetMapbox());
        rect = gameObject.GetComponent<RawImage>().rectTransform.rect;
        mapWidth = (int)Math.Round(rect.width);
        mapHeight = (int)Math.Round(rect.height);
    }

    void Update()
    {
        if (updateMap && (accessTokenLast != accessToken || !Mathf.Approximately(centerLatitudeLast, centerLatitude) || !Mathf.Approximately(centerLongitudeLast, centerLongitude) || zoomLast != zoom || bearingLast != bearing || pitchLast != pitch || mapStyleLast != mapStyle || mapResolutionLast != mapResolution))
        {
            rect = gameObject.GetComponent<RawImage>().rectTransform.rect;
            mapWidth = (int)Math.Round(rect.width);
            mapHeight = (int)Math.Round(rect.height);
            StartCoroutine(GetMapbox());
            updateMap = false;
        }
    }
    
    IEnumerator GetMapbox()
    {
        url = "https://api.mapbox.com/styles/v1/mapbox/" + styleStr[(int)mapStyle] + "/static/" + centerLatitude + "," + centerLongitude + "," + zoom + "," + bearing + "/" + mapWidth + "x" + mapHeight + "?" + "access_token=" + accessToken;
        mapIsLoading = true;
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("WWW ERROR: " + www.error);
        }
        else
        {
            mapIsLoading = false;
            gameObject.GetComponent<RawImage>().texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            accessTokenLast = accessToken;
            centerLatitudeLast = centerLatitude;
            centerLongitudeLast = centerLongitude;
            zoomLast = zoom;
            bearingLast = bearing;
            pitchLast = pitch;
            mapStyleLast = mapStyle;
            mapResolutionLast = mapResolution;
            updateMap = true;
        }
    }
}