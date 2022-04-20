package _testing;

public class test02 {
    public static void main(String args[]){
        new test02();
    }
    public test02(){
        long a=5;
        int b=6;
        long c=0;
        for(int i=0;i<a;i++){
            double j=i/b;
            c=c+b;
        }//for
        System.out.println(c);
    }//main()
}//class test03
