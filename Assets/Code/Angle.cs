using UnityEngine;
using System;

public static class Angle {
    public static float Normalize(float angle){
        while(angle >= 360){
            angle -= 360;
        }

        while(angle < 0){
            angle += 360;
        }

        return angle;
    }

    public static int GetXYQuadrant(float x, float y){
        int quadrant = 3;

        if(x >= 0 && y >= 0){
            quadrant = 1;
        } else if(x >= 0 && y < 0){
            quadrant = 4;
        } else if(x < 0 && y >= 0){
            quadrant = 2;
        }

        return quadrant;
    }

    public static int GetAngleQuadrant(float angle){
        angle *= Mathf.Rad2Deg;
        angle = Angle.Normalize(angle);
        int quadrant = 4;

        if(angle >= 0 && angle <= 90){
            quadrant = 1;
        } else if(angle > 90 && angle <= 180){
            quadrant = 2;
        } else if(angle > 180 && angle <= 270){
            quadrant = 3;
        }

        return quadrant;
    }

    public static float ClockwiseAtan(float y, float x){
        float angle = Mathf.Rad2Deg * Mathf.Atan(y / x);

        int quadrant = GetXYQuadrant(x, y);

        if(quadrant == 1 || quadrant == 4){
            angle = 90 - angle;
        } else if(quadrant == 2){
            angle = 360 - (90 + angle);
        } else if(quadrant == 3){
            angle = 270 - angle;
        }

        return Mathf.Deg2Rad * angle;
    }
}