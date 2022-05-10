using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideObject : InteractableObject
{
    public SliderGimmick slider;
    public override void Interact()
    {
        base.Interact();
        slider.Action();
    }
}
