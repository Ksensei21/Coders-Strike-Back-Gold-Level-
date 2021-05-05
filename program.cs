using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/


class Player
{
    static double clamp (double num, double min_value, double max_value) {
     return Math.Max(Math.Min(num, max_value), min_value);
    }
    
    static void Main(string[] args)
    {
        string[] inputs;
        int x_prev = 0;
        int y_prev = 0;
        double thrust;
        int booster= 1;
        int i = 0;
        
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
            int nextCheckpointX = int.Parse(inputs[2]); // x position of the next check point
            int nextCheckpointY = int.Parse(inputs[3]); // y position of the next check point
            int nextCheckpointDist = int.Parse(inputs[4]); // distance to the next checkpoint
            int nextCheckpointAngle = int.Parse(inputs[5]);
            inputs = Console.ReadLine().Split(' ');
            int opponentX = int.Parse(inputs[0]);
            int opponentY = int.Parse(inputs[1]); // angle between your pod orientation and the direction of the next checkpoint
            int x_now = x;
            int y_now = y;
            int speed_x = x_now - x_prev;
            int speed_y = y_now - y_prev;
    
            if (i == 0) {
                Console.WriteLine(nextCheckpointX + " " + nextCheckpointY + " 100");
            }
            else {
                if ((nextCheckpointAngle < -90) || (nextCheckpointAngle > 90)) {
                thrust = 0;
                Console.WriteLine((nextCheckpointX - 3 * speed_x) + " " + (nextCheckpointY - 3 * speed_y) + " " + thrust);
                }
                else {
                    if ((nextCheckpointAngle > -5) && (nextCheckpointAngle < 5) && (3000 < nextCheckpointDist) && (booster == 1)){
                        Console.WriteLine(nextCheckpointX + " " + nextCheckpointY + " " + "BOOST");
                        booster = 0;
                     }
                    else {
                        thrust = Convert.ToInt32(100 * clamp(1 - nextCheckpointAngle/90, 0, 1) * clamp(nextCheckpointDist / 1500, 0, 1));
                        Console.WriteLine((nextCheckpointX - 3 * speed_x)+ " " + (nextCheckpointY - 3 * speed_y)+ " " + thrust);
                    }
                }
            }
            i =+ 1;
            x_prev = x_now;
            y_prev = y_now;
        }
    }
}
