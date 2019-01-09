using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [Header("Variable")]
    public float minimapUpdateTime;

    [Header("Components")]
    public MinimapDisplayer minimapDisplayer;

    //Haritada surekli bir hareket mevcutsa araliklarla surekli guncelle
    //Haritada aktif bir hareket yoksa Bina kurulumu gibi olaylarda UpdateMinimap
    //fonksiyonu ile guncelleme yapliyor

    float timer;
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= minimapUpdateTime)
        {
            timer = 0f;
            UpdateMinimap();
        }
    }
    
    public void UpdateMinimap()
    {
        minimapDisplayer.UpdateMinimap();
    }

}
