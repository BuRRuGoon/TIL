# DEATH FIRST SEARCH  
(https://www.codingame.com/training/easy/temperatures)

## 내가 푼 방식
``` cs
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        int min = 10000;
        int index = 0;
        string[] inputs = Console.ReadLine().Split(' ');
        for (int i = 0; i < n; i++)
        {
            int t = int.Parse(inputs[i]);// a temperature expressed as an integer ranging from -273 to 5526

            if(Math.Abs(t) < Math.Abs(min))
            {
                min = t;
                index = i;
            }
            else if(Math.Abs(t) == Math.Abs(min))
            {
                if(t > min)
                {
                    min = t;
                    index = i;
                }
            }

            if(t == 0)
            {
                index = i;
                break;
            }
        }

        if(n > 0)
        {
            Console.WriteLine(inputs[index]);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}
```


# 배운점
간단한 절대값으로 값을 바꾸어서 0도에 가장 가까운 값을 찾는 문제이다.  
다만 같은 절대값일 경우 양수의 값이 좀더 가까운 값으로 취급 또한 제시되는 온도가 없을수도 있는 점만 추가적으로 작성해주면 
기본적으로 절대값 비교문제를 해결했을때와 같은 문제
