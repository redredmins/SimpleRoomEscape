﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenableProp : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closeSprite;

    protected SpriteRenderer renderer;


    protected virtual void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Open()
    {
        renderer.sprite = openSprite;
    }

    public void Close()
    {
        renderer.sprite = closeSprite;
    }
}
