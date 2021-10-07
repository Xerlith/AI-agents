using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Trait
{
    public SOTags.Tag tag;
    public float value;

    public Trait (SOTags.Tag tag, float value)
    {
        this.tag = tag;
        this.value = value;
    }
}
