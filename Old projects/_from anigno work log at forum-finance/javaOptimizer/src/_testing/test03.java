package _testing;

import utils.cTimer;

public class test03 {

    long ret=0;

    public static void main(String args[]) {
        new test03();
    }

    public test03(){
        cTimer timer = new cTimer();
        for (int j = 0; j < 10; j++) {
            timer.start();
            for (int i = 0; i < 1000; i++) {
                ret+=factorial(i);
            }//for
            timer.stop();
            System.out.println("time=" + timer.getTimeDif()+" "+ret);
        }//for
    }//main()

    public double factorial(int number) {
        double ret = 1;
        for (int i = 1; i < number; i++) {
            ret=ret*i;
        }//for
        return ret;
    }//test01()

}//class test01
