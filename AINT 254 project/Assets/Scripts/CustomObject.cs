using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomObject
{
    private string name;
    public enum TypeBlocks
    {
        wood,
        metal,
        dirt
    }

    private TypeBlocks myType;
    private Vector3 position;

    CustomObject()
    {

    }

    public string getName()
    {
        return this.name;

    }

    public void setName(string nameIn)
    {
        this.name = nameIn;

    }
}
