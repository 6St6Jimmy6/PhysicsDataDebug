using System;
using System.Numerics;

namespace Physics_Data_Debug
{
    public class Angle3D
    {
        //private static object AngleFormat;
        //internal object Format;

        public Angle3D(/*double positiveOrNegativeDirection1, double positiveOrNegativeDirection2,*/ double rotationY)
        {
            //LiveData.rotationX = positiveOrNegativeDirection1;
            LiveData.rotationYRad = rotationY;
            LiveData.rotationYDeg = rotationY * LiveData.dRadToDeg;
            //LiveData.rotationZ = positiveOrNegativeDirection2;

        }
        public static Angle3D GetAngles(Matrix4x4 playerRotation)
        {
            double positiveOrNegativeDirection1, positiveOrNegativeDirection2, thetaY, rotationY = 0.0;
            thetaY = Math.Asin(playerRotation.M11);
            positiveOrNegativeDirection1 = Math.Atan2(playerRotation.M12, playerRotation.M13);
            positiveOrNegativeDirection2 = Math.Atan2(playerRotation.M11, playerRotation.M12);

            if (positiveOrNegativeDirection1 < (Math.PI) && positiveOrNegativeDirection2 >= (Math.PI / 2))
            {
                rotationY = thetaY;
            }
            /*
            else if (positiveOrNegativeDirection1 >= (Math.PI) && positiveOrNegativeDirection2 >= (Math.PI / 2))
            {
                rotationY = (Math.PI) - thetaX;
            }
            else if(positiveOrNegativeDirection1 >= (Math.PI) && positiveOrNegativeDirection2 <= (-Math.PI / 2))
            {
                rotationY = (Math.PI) - thetaX;
            }
            */
            else if (positiveOrNegativeDirection1 >= (Math.PI))
            {
                rotationY = (Math.PI) - thetaY;
            }
            else if (positiveOrNegativeDirection1 < (Math.PI) && positiveOrNegativeDirection2 <= (-Math.PI / 2))
            {
                rotationY = 2 * (Math.PI) + thetaY;
            }
            else
            {
                rotationY = 2 * (Math.PI);
            }

            /*
            if(positiveOrNegativeDirection < (Math.PI / 2))
            {
                rotationY = Math.PI - thetaX;
            }
            else if(playerRotation.M23 >= 0)
            {
                rotationY = 2* Math.PI + thetaX;
            }
            else
            {
                rotationY = thetaX;
            }*/
            
            // Create return object.
            Angle3D angles = new Angle3D(/*positiveOrNegativeDirection1, positiveOrNegativeDirection2, */rotationY);

            // Convert to degrees.;
            //angles.Format = AngleFormat.Degrees;

            // Return angles.
            return angles;
        }
    }
}