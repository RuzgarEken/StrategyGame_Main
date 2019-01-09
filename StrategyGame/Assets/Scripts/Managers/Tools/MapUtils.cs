using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUtils
{
    static int sumX;
    static int sumY;
    public static bool IsIndexInArea(Index index, Index areaFirstIndex, Index areaLastIndex)
    {
        if (areaFirstIndex.x <= index.x 
            && index.x <= areaLastIndex.x
            && areaFirstIndex.y <= index.y
            && index.y <= areaLastIndex.y
        )
            return true;
        else 
            return false;
    }

    public static bool PositionInArea(Vector2 position, Index areaFirstIndex, Index areaLastIndex)
    {
        if (areaFirstIndex.x <= position.x
            && position.x <= areaLastIndex.x
            && areaFirstIndex.y <= position.y
            && position.y <= areaLastIndex.y
        )
            return true;
        else
            return false;
    }

    public static bool IsAreaInsideOfArea(Index innerAreaFirstIndex, Index innerAreaLastIndex, Index outerAreaFirstIndex, Index outerAreaLastIndex)
    {
        if (innerAreaFirstIndex.x >= outerAreaFirstIndex.x
            && innerAreaLastIndex.x <= outerAreaLastIndex.x
            && innerAreaFirstIndex.y >= outerAreaFirstIndex.y
            && innerAreaLastIndex.y <= outerAreaLastIndex.y
        )
            return true;
        else
            return false;
    }

    public static bool IsAreaIntersectWithOther(Index innerAreaFirstIndex, Index innerAreaLastIndex, Index outerAreaFirstIndex, Index outerAreaLastIndex)
    {
        if (innerAreaFirstIndex.x > outerAreaLastIndex.x || innerAreaLastIndex.x < outerAreaFirstIndex.x)
            return false;
        if (innerAreaFirstIndex.y > outerAreaLastIndex.y || innerAreaLastIndex.y < outerAreaFirstIndex.y)
            return false;

        return true;
    }

    public static void GetIndexDistanceToAreaMidPoint(Index index, Index areaFirstIndex, Index areaLastIndex, out Vector2 distanceToMidPoint)
    {
        distanceToMidPoint.x = ((float)(areaFirstIndex.x + areaLastIndex.x) / 2 - index.x) * 0.32f;
        distanceToMidPoint.y = ((float)(areaFirstIndex.y + areaLastIndex.y) / 2 - index.y) * 0.32f;
    }

    public static void SetSumValues(Index firstIndex, Index lastIndex, out int sumX, out int sumY)
    {
        if (firstIndex.x <= lastIndex.x)
            sumX = 1;
        else
            sumX = -1;

        if (firstIndex.y <= lastIndex.y)
            sumY = 1;
        else
            sumY = -1;
    }

}
