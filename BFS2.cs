using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {

        /* 미로탈출문제 : https://wikidocs.net/125662 */
        static void Main(string[] args)
        {
            //미로배열 만드는 과정
            String[,] map = {
                { "S", "0", "0", "0", "W", "0", "W" },
                { "W", "0", "W", "0", "0", "0", "0" },
                { "0", "0", "0", "W", "0", "W", "0" },
                { "0", "W", "W", "0", "0", "0", "0" },
                { "0", "0", "W", "W", "0", "W", "W" },
                { "W", "0", "W", "0", "0", "0", "0" },
                { "0", "0", "0", "W", "0", "0", "G" } };

            // 변수생성
            Queue<int> myQ = new Queue<int>(); // 배열에 입력된 값 1,1
            int[,] visited = new int[7, 7]; // 다녀온 경로를 기억해서 무한루프를 돌지 안도록 해주는 배열(메모장)
            int answer = 0;

            // 시작 노드 입력("S" = (0,0)
            myQ.Enqueue(0); // x좌표
            myQ.Enqueue(0); // y좌표
            visited[0, 0] = 1; // 시작노드 값

            // Q를 전부 탐색할동안 반복
            while(myQ.Count > 0)
            {
                // 큐의 맨 앞의 노드값을 "배서" 저장
                int x = myQ.Dequeue();
                int y = myQ.Dequeue();
                Console.WriteLine("myQ : ");
                foreach (var item in myQ) 
                {
                    Console.Write(item + ",");
                }
                
                // 해당 노드에 대해 연산수행
                // doSmthing();

                // 인접한 노드 저장
                // 위쪽 노드
                if(x-1 >= 0) //  index 범위안에 있고
                {
                    if (visited[x - 1, y]  == 0) // 아직 방문하지 ㅇ낳았고
                    {
                        if (!"W".Equals(map[x - 1, y]))  // 가고자 하는 점이 벽("W")이 아니어야함.
                        {
                            myQ.Enqueue(x - 1); // x좌표 
                            myQ.Enqueue(y); // y좌표
                            visited[x - 1, y] = visited[x,y] + 1; // 이미 간곳의 cnt를 저장하기에 기저장된 값 + 1
                        }
                    }
                }

                // 아래쪽 노드
                if(x + 1 < 7) // index 범위안에 있고
                {
                    if (visited[x+1,y] == 0) // 방문한적 없는 곳
                    {
                        if (!"W".Equals(map[x + 1, y])) // 벽에 안막혀있으면
                        {
                            myQ.Enqueue(x + 1);
                            myQ.Enqueue(y);
                            visited[x + 1, y] = visited[x, y] + 1;
                        }
                    }
                }

                // 왼쪽노드
                if(y-1 >= 0)// index 범위안에 있고
                {
                    if (visited[x,y-1] == 0) // 방문한적 없는곳
                    {
                        if (!"W".Equals(map[x, y - 1])) // 벽에 안막혀 있으면
                        {
                            myQ.Enqueue(x);
                            myQ.Enqueue(y-1);
                            visited[x, y - 1] = visited[x, y] + 1;
                        }
                    }
                }

                // 오른쪽 노드
                if(y+1 < 7) // index 범위안에 있고
                {
                    if (visited[x,y+1] == 0)  // 방문한 적 없고
                    {
                        if (!"W".Equals(map[x, y + 1])) // 벽에 안막혀 있으면
                        {
                            myQ.Enqueue(x);
                            myQ.Enqueue(y + 1);
                            visited[x, y + 1] = visited[x, y] + 1;
                        }
                    }
                }

                // 방문한 곳 출력
                Console.WriteLine();
                Console.WriteLine("visited : ");
                for (int i  = 0; i < 7; i++)
                {
                    for(int j = 0; j < 7; j++)
                    {
                        Console.Write(visited[i, j] + ",");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("====================================");

            }

            // 정답 출력
            answer = visited[6, 6];
            Console.WriteLine(answer);

        }
    }
}
