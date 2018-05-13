using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringUtils {

    public static string ZeroToLeft(int points) {
        if(points / 1 <= 10) {
            return string.Concat("0000000", points);    
        } else if (points / 10 <= 10) {
            return string.Concat("000000", points);
        } else if (points / 100 <= 10) {
            return string.Concat("00000", points);
        } else if (points / 1000 <= 10) {
            return string.Concat("0000", points);
        } else if (points / 10000 <= 10) {
            return string.Concat("000", points);
        } else if (points / 100000 <= 10) {
            return string.Concat("00", points);
        }
        return string.Concat("0", points);
    }
}
