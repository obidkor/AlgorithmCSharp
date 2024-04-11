using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /* 문제 : https://wikidocs.net/124755 */
    internal class Program
    {
        static String[] menu; // 메뉴리스트
        static int[] price; // 가격리스트
        static int[] good; // 만족도 점수리스트
        static int limit; // 가격 상한선

        static int[] visited;
        static List<String> orderList;
        static int totalPrice;
        static int totalGood;
        static void Main(string[] args)
        {
            //변수선언
            menu = new String[] { "치킨", "피자", "족발", "중식", "곱창", "분식", "회" }; // 메뉴리스트
            price = new int[] { 20000, 30000, 40000, 64000, 33000, 24000, 73000 }; // 가격리스트
            good = new int[] { 100, 150, 190, 250, 200, 120, 300}; // 만족도 리스트

            //구현을 위해 생성한 변수
            visited = new int[7]; // 해당 지역은 이미 방문했음.
            limit = 150000; // 돈 한계
            int priceSum = 0; //가격을 더해서 임시 저장할 변수
            int goodSum = 0; // 만족도 더해서 임시 저장할 변수
            List<String> tempOrder = new List<String>();    //메뉴를 임시 저장할 변수
            orderList = new List<String>(); //최종 오더리스트

            // 재귀함수 호출
            order(priceSum, goodSum,tempOrder);

            Console.WriteLine("totalPrice : " + totalPrice); //가격호출
            Console.WriteLine("totalGood : " + totalGood); // 만족도 호출
            Console.Write("시킨메뉴 : ");
            foreach (var item in orderList) // 메뉴호출
            {
                Console.Write(item + ",");
            }

        }

        /*파라미터 : 가격합, 만족도합, 재귀로 돌 orderlist*/
        private static void order(int priceSum, int goodSum,List<String> tempOrder)
        {
            //3. 탈출 조건
            if (priceSum > limit)
            {
                return;
            }
            // 탈출 못하면 기록하기
            else if (priceSum <= limit 
                     && totalGood < goodSum) // 가지치기(만족도가 클때만 기록하기)
            {
                totalPrice = priceSum;
                totalGood = goodSum;
                orderList = new List<String>(tempOrder);
            }
            
            // 경로탐색
            for(int i = 0; i < menu.Length; i++) 
            {
                // 안간 경로일 경우만 가자 
                if (visited[i] == 0)
                {
                    //메뉴배정
                    tempOrder.Add(menu[i]);
                    priceSum = priceSum + price[i];
                    goodSum = goodSum + good[i];
                    visited[i] = 1;

                    // 재귀함수
                    order(priceSum, goodSum,tempOrder);

                    //원복
                    visited[i] = 0;
                    goodSum = goodSum - good[i];
                    priceSum = priceSum - price[i];
                    tempOrder.Remove(menu[i]);
                }
            }
            
            return;
        }
    }
}
