﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewMonoBehaviour : MonoBehaviour
{
    string fileName = "BASIC256_greyscale_Mona_Lisa";
    Texture2D graph;

    void Start()
    {
        LoadImage();
        ConvertToGrayscale();
    }

    void LoadImage()
    {
        graph = Resources.Load(fileName, typeof(Texture2D)) as Texture2D;
    }

    void ConvertToGrayscale()
    {
        Color32[] pixels = graph.GetPixels32();
        for (int x = 0; x < graph.width; x++)
        {
            for (int y = 0; y < graph.height; y++)
            {
                Color32 pixel = pixels[x + y * graph.width];
                int p = ((256 * 256 + pixel.r) * 256 + pixel.b) * 256 + pixel.g;
                int b = p % 256;
                p = Mathf.FloorToInt(p / 256);
                int g = p % 256;
                p = Mathf.FloorToInt(p / 256);
                int r = p % 256;
                float l = (0.2126f * r / 255f) + 0.7152f * (g / 255f) + 0.0722f * (b / 255f);
                Color c = new Color(l, l, l, 1);
                graph.SetPixel(x, y, c);
            }
        }

        graph.Apply(false);
        var bytes = graph.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "ImageSaveTest.png", bytes);
    }
}
