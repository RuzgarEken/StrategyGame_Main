using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjeDisplayer : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    public TMPro.TextMeshProUGUI objeName;

    public void Set(MapObjeData mapObjeData)
    {
        image.sprite = mapObjeData.image;
        image.color = mapObjeData.defaultColor;

        objeName.text = mapObjeData.name;

        image.gameObject.SetActive(true);
        objeName.gameObject.SetActive(true);
    }

    public void Set(Instance mapInstance)
    {
        image.sprite = mapInstance.image;
        image.color = mapInstance.defaultColor;

        objeName.text = mapInstance.name;

        image.gameObject.SetActive(true);
        objeName.gameObject.SetActive(true);
    }

    public void Clear()
    {
        image.gameObject.SetActive(false);
        objeName.gameObject.SetActive(false);
    }

}
