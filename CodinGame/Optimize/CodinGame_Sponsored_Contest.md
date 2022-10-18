# CodinGame_Sponsored_Contest 
(https://www.codingame.com/training/medium/death-first-search-episode-1)

## 푸는중 코드 (10월 18일)
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
        int firstInitInput = int.Parse(Console.ReadLine());
        int secondInitInput = int.Parse(Console.ReadLine());
        int thirdInitInput = int.Parse(Console.ReadLine());
        int count = 0;
        
        // game loop
        while (true)
        {
            string downInput = Console.ReadLine();
            string leftInput = Console.ReadLine();
            string upInput = Console.ReadLine();
            string rightInput = Console.ReadLine();
            if(count == 1)
            {
                NowAround(downInput, leftInput, upInput, rightInput);
            }
            for (int i = 0; i < thirdInitInput; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int fifthInput = int.Parse(inputs[0]);
                int sixthInput = int.Parse(inputs[1]);
                if(count == 2 && i == 4)
                {
                    NowChar(fifthInput, sixthInput);
                }
            }
            
            
            if(count == 0)
            {
                Console.WriteLine("E");
            }
            else
            {
                Console.WriteLine("D");
            }
            count++;
        }
    }

    static public void NowChar(int fifthIn, int sixthIn)
    {
        Console.Write(fifthIn + " " + sixthIn + " ");
    }

    static public void NowAround(string fi, string si, string ti, string foi)
    {
        Console.Write(fi + " " + si + " " + ti + " " + foi);
    }
}
```


# 푸는중 (10월 18일)
```
아무런 힌트없이 출력 정답값도 없이 그저 코드를 해석해서 높은 점수를 얻게 만들어야 되는 방식 마치 암호문을 푸는것과 같았다.  
처음에는 입력되는 모든 변수를 확인해보았고 
턴당 변하지 않는 int값이 3개 1번 테스트 예제 기준으로 

3개의 int값  
firstInitInput - 35  
secondInitInput - 28
thirdInitInput - 5

이중 thirdInit은 게임 루프에 inputs 배열을 출력하는 부분을 얼마나 출력하는지에 관여

아래는 게임 루프에서 계속 변경되는 값
4개의 char값  
#
_
#
_

2개의 배열 int값
[11, 16, 11, 16, 13]
[15, 15, 17, 17, 25]

출력으로 사용할수 있는 문자는 A B C D E이다.

처음에는 문자의 아스키코드값을 이용해서 무언가를 한다고 생각했었고 해당 방향으로 알아보았지만 도저히 방향이 잡히지 않았다.  
그래서 결국 제공되는 힌트를 사용 2개의 배열 int값중에 본인 캐릭터의 위치값이 존재한다는 힌트를 얻을수 있었다.  

해당 힌트로 많은 점을 알수있엇는데 일단 firstInitInput, secondInitInput은 왠지 캐릭터가 가야될 목표 지점 x y 인것 같고
캐릭터의 위치값을 제외한 int값들은 아마 적들에 x y 현재 위치인것 같았다.  
그러면 출력으로 사용되는 문자는 자연적으로 캐릭터를 움직이는 방향으로 생각하였고 출력에 따른 int 배열값 변화를 먼저 확인하였다.

해당 배열과 4개의 char값의 변화를 확인한 결과 첫번째 테스트 케이스에서는 배열의 마지막값이 플레이어가 조종하는 캐릭터이고
# 벽 / _ 길이라는 점을 알수있었다.

방향은 직접 이동해보니 down/left/up/right 순이었고 이제 해당 값들을 이용해서 목표지점으로 캐릭터를 움직이면 될것같다.

일단 헷갈리지 않게 현재까지 알아낸 이동부분을 메소드로 제작해주었다.
```

