﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectRatio : MonoBehaviour
{
    #region Fields
    public float targetAspectX = 16;
    public float targetAspectY = 9;
    [HideInInspector]
    public float fieldOfView = 60;

    [HideInInspector]
    private Camera m_camera;
    #endregion //Fields

    #region Messages
    void Start () {
        // set the desired aspect ratio (the values in this example are
        // hard-coded for 16:9, but you could make them into public
        // variables instead so you can set them at design time)
        float targetaspect = targetAspectX / targetAspectY;

        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // obtain camera component so we can modify its viewport
        m_camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = m_camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            m_camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = m_camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            m_camera.rect = rect;
            
        }
    }

    void OnGUI()
    {
        GUI.Button(new Rect(0, 0, 100, 100), "shit");
        
    }
    #endregion //Messages
}
