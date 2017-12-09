using System;
using System.Collections.Generic;

namespace SpirographGenerator
{
    public class SpirographGenerator
    {
        #region Private properties

        /// <summary>
        /// Radius of the ring on whose circumference the
        /// circle is rotating.
        /// </summary>
        private int RingRadius { get; set; }

        /// <summary>
        /// Radius of the circle which is rotating on the ring.
        /// </summary>
        private int CircleRadius { get; set; }

        /// <summary>
        /// Distance of the point from circle's center.
        /// Spirograph is traced by the movement of this point.
        /// </summary>
        private int DistanceFromCenter { get; set; }

        /// <summary>
        /// Distance of center of the rotating circle from center
        /// </summary>
        private int DistOfCircleFromCenter { get; set; }

        /// <summary>
        /// Value by which the angle of rotation should be increased.
        /// This decides the precision of output image.
        /// 
        /// This is the increment in angle made by rotating circle's center
        /// when it rotates on the ring.
        /// </summary>
        private double AngleIncrement { get; set; }

        /// <summary>
        /// Angle the inner circle's center would have completed by the time
        /// it reaches the original point again. (possibly more than necessary, but safe angle)
        /// </summary>
        private double CompletionAngle { get; set; }

        /// <summary>
        /// Useful in computation
        /// </summary>
        private double RingToCircleRadio { get; set; }

        #endregion

        #region Private Helpers

        private void SetCompletionAngle()
        {
            // inner circle should rotate as much as the ratio of outer ring to
            // inner circle's radius is
            CompletionAngle = Math.PI * 2 * (RingRadius);
        }

        #endregion

        /// <summary>
        /// Create an instance to generate the points of spirograph
        /// </summary>
        /// <param name="ringRadius">Outer ring radius</param>
        /// <param name="circleRadius">Radius of rotating circle</param>
        /// <param name="distanceFromCenter">
        /// Distance of point from the center of rotating circle
        /// </param>
        /// <param name="angleIncrement">Rate at which angle should be incremented</param>
        public SpirographGenerator(int ringRadius,
            int circleRadius,
            int distanceFromCenter,
            double angleIncrement)
        {
            RingRadius = ringRadius;
            CircleRadius = circleRadius;
            DistanceFromCenter = distanceFromCenter;
            AngleIncrement = angleIncrement;

            RingToCircleRadio = ((double)RingRadius / (double)CircleRadius);
            DistOfCircleFromCenter = RingRadius - CircleRadius;
            SetCompletionAngle();
        }

        public IEnumerable<Tuple<double, double>> GenerateSpirograph()
        {
            double currentAngle = 0;
            double innerCircleRotationAngle = 0;
            double y;
            double x;

            do
            {
                // calculate position
                innerCircleRotationAngle = -1 * RingToCircleRadio * currentAngle;
                y = DistOfCircleFromCenter * Math.Cos(currentAngle) + DistanceFromCenter * Math.Cos(innerCircleRotationAngle);
                x = DistOfCircleFromCenter * Math.Sin(currentAngle) + DistanceFromCenter * Math.Sin(innerCircleRotationAngle);

                yield return new Tuple<double, double>(x, y);

                currentAngle += AngleIncrement;
            }
            while (currentAngle < CompletionAngle);
        }
    }
}
