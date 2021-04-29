using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    //public float ThetaScale = 0.01f;
    //public float radius = 3f;
    //private int Size;
    private LineRenderer LineDrawer;
    private float Theta = 0f;

    [System.Obsolete]
    IEnumerator DrawTheCircle(float ThetaScale, float radius, int Size, float time)
    {
        float timepassed = 0;
        Theta = 0f;
        Size = (int)((1f / ThetaScale) + 1f);
        LineDrawer.SetVertexCount(Size);
        while (timepassed < time)
        {
            for (int i = 0; i < Size; i++)
            {
                Theta += (2.0f * Mathf.PI * ThetaScale);
                float x = radius * Mathf.Cos(Theta);
                float y = radius * Mathf.Sin(Theta);
                LineDrawer.SetPosition(i, new Vector3(x, y, 0));
                yield return null;
            }
        }
    }
}
