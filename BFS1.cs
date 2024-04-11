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

        static void Main(string[] args)
        {
            //배열 만드는 과정
            int[,] map = new int[4, 4];
            int temp = 1;
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++) 
                {
                    map[i, j] = temp;
                    temp++;
                }
            }

            // 변수생성
            Queue<Int32> myQ  = new Queue<Int32>();// 배열에 입력된 값
            Queue<Int32> myQ_x = new Queue<Int32>();// 값의 x좌표
            Queue<Int32> myQ_y = new Queue<Int32>();// 값의 y좌표

            int[,] visited = new int[4, 4]; // 방문한 좌표 표시

            // 시작노드 입력 (6 = (1,1))
            myQ.Enqueue(6);
            visited[1, 1] = 1;
            myQ_x.Enqueue(1);
            myQ_y.Enqueue(1);

            
            while(myQ.Count != 0)
            {
                // 큐의 맨 앞의 노드값 저장(queue에서 제거하지 않고 반환)
                int node = myQ.Peek();
                int x = myQ_x.Peek();
                int y = myQ_y.Peek(); 

                // 해당 노드에 대한 연산 수행
                //doSomething();

                // 인접한 노드 저장
                // 위쪽 노드
                if(x - 1 >= 0)
                {
                    if (visited[x - 1, y] != 1)
                    {
                        myQ.Enqueue(map[x - 1, y]);
                        visited[x - 1, y] = 1;
                        myQ_x.Enqueue(x - 1);
                        myQ_y.Enqueue(y);
                    }
                }

                // 아래쪽 노드
                if(x +1 < 4)
                {
                    if (visited[x+1, y] != 1)
                    {
                        myQ.Enqueue(map[x + 1, y]);
                        visited[x+1,y] = 1;
                        myQ_x.Enqueue(x + 1);
                        myQ_y.Enqueue(y);
                    }
                }

                // 왼쪽 노드
                if(y -1 >= 0)
                {
                    if (visited[x,y-1] != 1)
                    {
                        myQ.Enqueue(map[x,y-1]);
                        visited[x, y - 1] = 1;
                        myQ_x.Enqueue(x); 
                        myQ_y.Enqueue(y-1);
                    }
                }


                // 오른쪽 노드
                if(y + 1 < 4)
                {
                    if (visited[x,y+1] != 1)
                    {
                        myQ.Enqueue(map[x,y+1]);
                        visited[x, y + 1] = 1;
                        myQ_x.Enqueue(x);
                        myQ_y.Enqueue(y + 1);
                    }
                }

                // 연산이 끝난 노드 제거(queue에서 제거하여 반환)
                myQ.Dequeue();
                myQ_x.Dequeue();
                myQ_y.Dequeue();

                // visited 출력
                Console.WriteLine("visited : ");
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write(visited[i, j] + ",");
                    }
                    Console.WriteLine();
                }

                // 입력한값 출력
                Console.WriteLine("myQ : ");

                foreach(var item in myQ)
                {
                    Console.Write(item + ",");
                }

                Console.WriteLine();
                Console.WriteLine();


            }



        }
    }
}
