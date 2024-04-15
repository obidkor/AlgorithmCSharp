import java.util.*;
import java.lang.*;
import java.io.*;

// The main method must be in a class named "Main".
/* 말이동하기  : https://wikidocs.net/132151 */
class Main {
    public static void main(String[] args) {
                //1. 입력 및 변수 선언, 초기화
        //Scanner sc=new Scanner(System.in);

        int N= 25;

        ArrayList<Integer> visitedList=new ArrayList<Integer>();
        ArrayList<Integer> newvisitedList=new ArrayList<Integer>();
        HashMap<Integer,ArrayList<Integer>> visitedPath= new HashMap<Integer,ArrayList<Integer>>();
        

        LinkedList<Integer> pathQ=new LinkedList<Integer>();
        LinkedList<Integer> visitedQ=new LinkedList<Integer>();

        int Answer=0;
        //2. 시작점 설정
        pathQ.add(0);
        visitedList.add(0);
        visitedQ.add(0);

        //3. BFS 시작
        while(true) {
            //3.1 탐색할 지점의 좌표를 꺼내어 저장하고, 이동할 위치를 변수에 저장
            int now=pathQ.poll();
            int cnt=visitedQ.poll();
            

            int jump_forward_3=now+3;
            int jump_forward_7=now+7;
            int jump_back_3=now-3;
            int jump_back_7=now-7;


            //3.2 N에 도착했을 경우 while문을 탈출
            if(now==N) {
                Answer=cnt;
                break;
            }

            //3.3 조건에 맞게 이동 후 큐에 저장
            if(!visitedList.contains(jump_forward_3)) {
                pathQ.add(jump_forward_3);
                visitedList.add(jump_forward_3);
                newvisitedList.add(jump_forward_3);
                visitedQ.add(cnt+1);
            }
            if(!visitedList.contains(jump_forward_7)) {
                pathQ.add(jump_forward_7);
                visitedList.add(jump_forward_7);
                newvisitedList.add(jump_forward_7);
                visitedQ.add(cnt+1);
            }
            if(!visitedList.contains(jump_back_3)) {
                pathQ.add(jump_back_3);
                visitedList.add(jump_back_3);
                newvisitedList.add(jump_back_3);
                visitedQ.add(cnt+1);
            }
            if(!visitedList.contains(jump_back_7)) {
                pathQ.add(jump_back_7);
                visitedList.add(jump_back_7);
                newvisitedList.add(jump_back_7);
                visitedQ.add(cnt+1);
            }

            if(cnt >= 1){
                for(Integer val : visitedPath.get(cnt)){
                    newvisitedList.remove(val);
                }
            }
            
            visitedPath.put(cnt+1, (ArrayList<Integer>)newvisitedList.clone());
        }

        for (Integer key : visitedPath.keySet()) {	
        	System.out.println(key + " : " + visitedPath.get(key));	
        }
        
        System.out.println(Answer);
    }
}
