using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static float Remap (this float from, float fromMin, float fromMax, float toMin,  float toMax)
    {
        float fromAbs  =  from - fromMin;
        float fromMaxAbs = fromMax - fromMin;      
       
        float normal = fromAbs / fromMaxAbs;
 
        float toMaxAbs = toMax - toMin;
        float toAbs = toMaxAbs * normal;
 
        float to = toAbs + toMin;
       
        return to;
    }

    public static float[] ConvertToArray(this Vector3 targetVec)
    {
        float [] arrFromVec = new float[3];
        arrFromVec[0] = targetVec.x;
        arrFromVec[1] = targetVec.y;
        arrFromVec[2] = targetVec.z;
        return arrFromVec;
    }
    
}
