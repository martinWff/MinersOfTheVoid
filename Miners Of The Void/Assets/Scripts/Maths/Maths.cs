using System.Collections;
using System.Collections.Generic;
using UnityEngine;




  public static class Maths {
        public static float Distance(Vector2 position1, Vector2 position2)
        {
            return Mathf.Sqrt(Mathf.Pow(position2.x - position1.x, 2) + Mathf.Pow(position2.y - position1.y, 2));

        }
        public static float Deg2Rad(float number)
        {
            return (number * Mathf.PI) / 180;
        }
        public static float Rad2Deg(float number)
        {
            return (number * 180) / Mathf.PI;
        }
        public static Vector3 TransformUp(GameObject gO)
        {
            float angle = gO.transform.eulerAngles.z + 90;
            Vector3 up = new Vector3(Mathf.Cos(Deg2Rad(angle)), Mathf.Sin(Deg2Rad(angle)), 0);
            return up;
        }
            

    }
