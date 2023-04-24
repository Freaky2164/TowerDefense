using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image image;
    public Sprite startIamge;
    public Sprite pauseImage;
    private bool hasStarted;

    public void changeImage()
    {
        if (!hasStarted)
        {
            image.sprite = pauseImage;
            hasStarted = true;
        }
        else
        {
            image.sprite = startIamge;
            hasStarted = false;
        }
    }
}
