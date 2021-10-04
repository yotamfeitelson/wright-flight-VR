using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GifIt : MonoBehaviour
{
    public Texture2D[] frames;
    public int framesPerSecond = 30;
    public RawImage img;
   

    // Update is called once per frame
    void FixedUpdate()
    {
        
        var index = Time.time * framesPerSecond; 
        index = index % frames.Length; 
        img.texture = frames[(int)index];
    }
}
