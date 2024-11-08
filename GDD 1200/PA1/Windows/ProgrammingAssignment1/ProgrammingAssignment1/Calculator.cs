namespace ProgrammingAssignment1
{
    /// <summary>
    /// Calculates distance and angle between two points
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Constructor. Calculates and prints the distance 
        /// and angle between the two given points
        /// </summary>
        /// <param name="point1X">point 1 x</param>
        /// <param name="point1Y">point 1 y</param>
        /// <param name="point2X">point 2 x</param>
        /// <param name="point2Y">point 2 y</param>
        public Calculator(float point1X, float point1Y,
            float point2X, float point2Y)
        {
            // STUDENTS: add your code here
            float deltaY;
            float deltaX;

            //Calculate deltaX and deltaY
            deltaY = point2Y - point1Y;
            deltaX = point2X - point1X;

            //Declare Side A and Side B
            float sideA;
            float sideB;

            //Set SideA to deltaX and SideB to deltaY
            sideB = deltaY;
            sideA = deltaX;

            //Declare and Calculate sideC
            float sideC;
            sideC = MathF.Sqrt(MathF.Pow(sideA, 2) + MathF.Pow(sideB, 2));

            //Calcuate the angle in radians
            float angleRad;
            angleRad = MathF.Atan2(deltaY, deltaX);

            //Convert angle from radians to degrees
            float angleDeg;
            angleDeg = angleRad * (180 / MathF.PI);

            //Print to console
            Console.WriteLine(sideC + " " + angleDeg);


        }
    }
}