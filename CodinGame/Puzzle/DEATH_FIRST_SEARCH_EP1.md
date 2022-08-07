# DEATH FIRST SEARCH  
(https://www.codingame.com/training/medium/death-first-search-episode-1)

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
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // 게이트 웨이를 포함한 총 노드 수
        int L = int.Parse(inputs[1]); // 링크 수
        int E = int.Parse(inputs[2]); // 출구 게이트 웨이 수

        int count = 1;
        int bcount = 0;
        int[] gateWay = new int[E];
        int[] isVisit = new int[N + 1];
        List<int>[] edge = new List<int>[N + 1];
        Queue<int> node = new Queue<int>();

        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);

            if (edge[N1]==null)
            {
                edge[N1] = new List<int>();
            }
            edge[N1].Add(N2);

            if (edge[N2] == null)
            {
                edge[N2] = new List<int>();
            }
            edge[N2].Add(N1);
        }

        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            gateWay[i] = EI;
        }

        for (int i = 0; i <= N; i++)
        {
            if (edge[i]==null)
            {
                continue;
            }
            edge[i].Sort((x, y) => { return x.CompareTo(y); });
        }
        
        void Bfs(int start)
        {
            count = 1;
            isVisit = new int[N + 1];
            isVisit[start] = count++;
            node.Enqueue(start);
            foreach(int b in edge[start])
            {
                if(gateWay.Contains(b))
                {
                    isVisit[b] = count++;
                    node.Dequeue();
                    break;
                }
            }

            while(!(node.Count == 0))
            {
                int a = node.Dequeue();
                
                foreach(int b in edge[a])
                {
                    
                    if(isVisit[b] > 0)
                    {
                        continue;
                    }
                    
                    node.Enqueue(b);
                    isVisit[b] = count++;
                }
            }
        }
        


        // game loop
        while (true)
        {
            
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn
            Bfs(SI);
            int node_a = Array.IndexOf(isVisit, 1);
            int node_b = Array.IndexOf(isVisit, 2);
            
            Console.Write(node_a + " ");
            Console.WriteLine(node_b);
        }
    }

    
}
```


# 배운점
바이러스가 게이트웨이까지 도달하지 못하게 막는 그래프와 BFS를 이용해서 해결해야되는 퍼즐이었다.  
마침 BFS를 배운지 얼마안되서 활용해서 풀어보기 좋은 문제였다.  
바이러스의 이동경로를 계속해서 BFS로 탐색해주고 현재 바이러스의 위치와 다음에 바이러스가 이동할 위치를 막아버리고 BFS문안에 만약 바이러스와 게이트웨이가 노드가 이어져있는경우 해당 노드부터 제일먼저 막아버리는 방법으로 문제를 해결하였다.  

