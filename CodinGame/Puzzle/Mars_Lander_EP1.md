# Mars Lander EP1  
(https://www.codingame.com/training/easy/mars-lander-episode-1)

## 내가 푼 방식
``` cs
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        int surfaceN = int.Parse(Console.ReadLine()); // the number of points used to draw the surface of Mars.
        for (int i = 0; i < surfaceN; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
        }

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            int hSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
            int vSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
            int fuel = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
            int rotate = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
            int power = int.Parse(inputs[6]); // the thrust power (0 to 4).


            // 2 integers: rotate power. rotate is the desired rotation angle (should be 0 for level 1), power is the desired thrust power (0 to 4).
            if(vSpeed < -39)
            {
                Console.WriteLine("0 4");
            }
            else
            {
                Console.WriteLine("0 0");
            }
        }
    }
}
```


# 배운점
문제 자체는 Mars Lander EP1이 Easy 난이도이기 때문에 쉬웠다.
각도와 우주선의 위치를 조절할 필요가 없어서 사실상 파워를 조절해서 속도가 40이하로 착륙시키면 되고 추가적으로 
메달은 300기름 이상을 남겨야 되기 때문에 그 부분까지 생각해서 풀어보았다.  

먼저 속도는 0 아예 부스터를 가동하지 않는 것부터 4까지 있는데 
4부스터는 우주밖으로 다시 나갈정도로 강력한 파워이다.  

이 강력한 파워와 0만을 이용해서 우주선이 40속도 이상으로 올라가지 않도록 설정만 해주었다.