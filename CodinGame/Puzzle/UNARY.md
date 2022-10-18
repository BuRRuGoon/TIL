# UNARY
(https://www.codingame.com/ide/puzzle/unary)

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
        StringBuilder sb = new();
        StringBuilder bin = new();
        string MESSAGE = Console.ReadLine();
        for(int k = 0; k < MESSAGE.Length; k++)
        {
            int acci = Convert.ToInt32(MESSAGE[k]);
            
            // 비트 변환시 6비트로 출력될 경우 맨앞에 0이 생략되므로 해당 부분을 위한 0추가
            if(Convert.ToString(acci, 2).Length < 7)
            {
                bin.Append(0);
            }
            bin.Append(Convert.ToString(acci, 2));
        }
        
        char now = bin[0];

        if(now == '0')
        {
            sb.Append("00 0");
        }
        else
        {
            sb.Append("0 0");
        }

        for(int i = 1; i < bin.Length; i++)
        {
            if(bin[i] == now)
            {
                sb.Append(0);
            }
            else
            {
                sb.Append(" ");

                if(bin[i] == '0')
                {
                    sb.Append("00 0");
                    now = '0';
                }
                else
                {
                    sb.Append("0 0");
                    now = '1';
                }
            }
        }

        Console.WriteLine(sb.ToString());
    }
}
```


# 배운점
주어진 문자열을 아스키코드값으로 변경 해당 아스키 코드 값을 다시 2진수로 변경되어 나온 2진수 문자열을 0만을 이용한 문자로 변경하는 것이다.  
1,2번 테스트 케이스는 쉽게 해결했는데 3번부터 무엇이 문제점인지 찾기가 힘들었다.  
결과값을 역으로 역산해보니 2진수 문자열이 달랐고 2진수로 변경했을때 7비트가 아닌 앞에 0이 생략된 6비트로 변경이 되던 부분을 찾았다.  
그래서 만약 6비트를 출력하게되면 앞에 2진수앞에 0을 추가해주는 작업을 구현하였고 나머지 부분은 헷갈리지않고 풀어낸것 같다.
