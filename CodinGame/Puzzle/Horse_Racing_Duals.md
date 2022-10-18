# Horse Racing Duals
(https://www.codingame.com/training/easy/horse-racing-duals)

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
        int N = int.Parse(Console.ReadLine());
        int[] arr = new int[N];
        int P = 10000000;
        for (int i = 0; i < N; i++)
        {
            int pi = int.Parse(Console.ReadLine());
            arr[i] = pi;
        }
        
        Array.Sort(arr);
        
        for(int i = 1; i < N; i++)
        {
            int temp = arr[i] - arr[i - 1];
            if(P > temp)
            {
                P = temp;
            }
        }
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(P);
    }
}
```

``` bash
read -r N
P=10000000
for (( i=0; i<$N; i++ )); do
    read -r Pi
    arr+=("$Pi")
done

# int array 정렬
arr=(`for item in "${arr[@]}"; do echo "$item"; done | sort -n`)

for (( i=1; i<$N; i++ )); do
    temp=(${arr[i]})
    if [ $(($temp-${arr[i-1]})) -lt $P ];then
        P=$(($temp-${arr[i-1]}))
    fi
done

# Write an answer using echo
# To debug: echo "Debug messages..." >&2

echo ${P}
```


# 배운점
배열값의 가장 작은 차이값을 가지는 말을 찾는 문제  
받은 값을 배열로 받아서 정렬을 해준뒤 정렬된 값을 계산하여 가장 작은 차이값을 그대로 출력해주었다.  

추가적으로 메달획득이 bash로 문제를 해결하는 부분이여서 처음으로 쉘 스크립트를 이용해서 작성했다.  
띄어쓰기 까지 신경써야되는 부분과 컴파일러가 간단해서 잘못된 부분을 찾는게 힘들었고 재미있는 경험이었다.  
