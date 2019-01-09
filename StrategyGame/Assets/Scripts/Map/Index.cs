using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Index {
    public int x;
    public int y;

    #region Constructors

    public Index() { }

    public Index(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Index(Index index)
    {
        this.x = index.x;
        this.y = index.y;
    }

    #endregion

    #region Setters

    public void Set(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void Set(Index index)
    {
        this.x = index.x;
        this.y = index.y;
    }

    #endregion

    #region Operators

    public override bool Equals(System.Object obj)
    {
        Index index = obj as Index;
        return this.x == index.x && this.y == index.y;
    }

    public override int GetHashCode()
    {
        return (x * 597) ^ (y * 1173);
    }

    public static Vector2 ToVector2(Index index)
    {
        return new Vector2(index.x, index.y);
    }

    public static Index operator +(Index index1, Index index2)
    {
        Index newIndex = new Index();
        newIndex.x = index1.x + index2.x;
        newIndex.y = index1.y + index2.y;
        return newIndex;
    }

    public static Index operator -(Index index1, Index index2)
    {
        Index newIndex = new Index();
        newIndex.x = index1.x + index2.x;
        newIndex.y = index1.y + index2.y;
        return newIndex;
    }

    public static Index operator *(Index index, int number){
        Index newIndex = new Index();
        newIndex.x = index.x * number;
        newIndex.y = index.y * number;
        return newIndex;
    }

    public static Index operator *(int number, Index index)
    {
        return index * number;
    }

    #endregion

    #region Static Variables

    /// <summary>(0,0)</summary>
    public static readonly Index zero = new Index(0, 0);
    /// <summary>(1,0)</summary>
    public static readonly Index right = new Index(1, 0);
    /// <summary>(-1,0)</summary>
    public static readonly Index left = new Index(-1, 0);
    /// <summary>(0,1)</summary>
    public static readonly Index up = new Index(0, 1);
    /// <summary>(0,-1)</summary>
    public static readonly Index down = new Index(0, -1);
    /// <summary>(-1,1)</summary>
    public static readonly Index leftUp = new Index(-1, 1);
    /// <summary>(1,1)</summary>
    public static readonly Index rightUp = new Index(1, 1);
    /// <summary>(-1,-1)</summary>
    public static readonly Index leftDown = new Index(-1, -1);
    /// <summary>(1,-1)</summary>
    public static readonly Index rightDown = new Index(1, -1);

    #endregion

}
