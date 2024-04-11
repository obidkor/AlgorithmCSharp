using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /* 문제 : https://wikidocs.net/124080 */
    internal class Program
    {

        static int[] visited1;
        static int[] result;
        static int N;
        static void Main(string[] args)
        {
            //변수선언
            Console.Write("수입력 : ");
            N = Convert.ToInt32(Console.ReadLine()); // 주사위 갯수
            visited1 = new int[N]; // 해당 주사위는 넘겼음.
            result = new int[N]; // 결과

            int diceNum = 0; // 초기세팅

            // 재귀함수 호출
            roll(diceNum);

        }

        public static void roll(int diceNum)
        {
            // 탈출조건 : 주사위 갯수 다 굴렸을때
            if (diceNum == N)
            {
                foreach (var item in result)
                {
                    Console.Write($"[{string.Join(", ", item)}]");
                }
                Console.WriteLine();
                return;
            }
            else
            {
                //1~6까지 배정
                for (int i = 1; i <= 6; i++)
                {
                    // 가지치기
                    if (visited1[diceNum] != 1  //1. 해당 주사위 돌렸으면 out
                        && (diceNum == 0 || result[diceNum-1] < i)) // 2. 이미 그전에 나온 주사위 눈이면 out(첫번째 주사위 제외)
                    {
                        // 값 배정
                        result[diceNum] =  i;
                        visited1[diceNum] = 1;
                        diceNum++;

                        //재귀함수
                        roll(diceNum);
                        
                        // 값 원복
                        diceNum--;
                        visited1[diceNum] = 0;
                        result[diceNum] = 0;
                    }
                }
                
            }
            return;
        }
    }
}
