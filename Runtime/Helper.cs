using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace RealmGames.PathFinding
{
    [Serializable]
    public class Helper
    {
        public Vector3[] Optimize(Vector3[] points)
        {
            List<Vector3> segments = new List<Vector3>();
            List<Vector3> current = new List<Vector3>();
            Vector3 last = Vector3.zero;
            Vector3 dir = Vector3.zero;
            Vector3 start = Vector3.zero;

            for (int i = 0; i < points.Length; i++)
            {
                Vector3 point = points[i];

                if (current.Count == 0)
                {
                    start = point;
                    last = point;
                    current.Add(point);
                }
                else if (current.Count == 1)
                {
                    dir = (last - point).normalized;
                    last = point;
                    current.Add(point);
                }
                else
                {
                    Vector3 direction = (last - point).normalized;

                    if (direction != dir)
                    {
                        segments.Add(start);
                        segments.Add(last);

                        current.Clear();

                        start = last;
                        current.Add(last);
                    }

                    dir = (last - point).normalized;
                    last = point;
                    current.Add(point);
                }
            }

            if (current.Count == 1)
            {
                segments.Add(current[0]);
            }
            else if (current.Count > 1)
            {
                segments.Add(current[0]);
                segments.Add(current[current.Count - 1]);
            }

            return segments.ToArray();
        }


    }
}