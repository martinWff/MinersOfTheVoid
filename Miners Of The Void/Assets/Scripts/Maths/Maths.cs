using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Maths
{
  public static class Vectors {
        public static float Distance(Vector2 position1, Vector2 position2)
        {
            return Mathf.Sqrt(Mathf.Pow(position2.x - position1.x, 2) + Mathf.Pow(position2.y - position1.y, 2));

        }


    }
}