package _testing;

public class test01 {

    public test01() {
        int k = 5;
        long l = 0;
        for (int i = 0; i < k; i++) {
            l += i;
        }//for
        System.out.println(l);
    }//test01()

    public static void main(String args[]) {
        new test01();
    }//main()
}//class test01
