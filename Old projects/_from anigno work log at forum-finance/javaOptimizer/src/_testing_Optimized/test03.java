//****** Add package declaration here
package _testing_Optimized;
//****** Add import optimizer's dataStructure
import optimizerDataStructure.*;

//****** Add other imports here
import utils.cTimer;

//****** Add class declaration here
public class test03 {

//****** Add declaration for optDataStructure in class memebers declarations
optDataStructure myData=new optDataStructure();

//****** Add other members declaration here
    long ret = 0;

//****** Add user code until the requested for loop here
    public static void main(String args[]) {
        new test03();
    }

    public test03() {
        cTimer timer = new cTimer();
        for (int j = 0; j < 10; j++) {
            timer.start();
            for (int i = 0; i < 1000; i++) {
                ret+=factorial(i);
            }//for
            timer.stop();
            System.out.println("time=" + timer.getTimeDif() + " " + ret);
        }//for
    }//main()

    public double factorial(int number) {
        double ret = 1;

//****** Add before the ''For'' loop:

String keyVar=myData.ToStringFunction(number);
optDataNode dataNode=myData.FindNode(keyVar);
if(dataNode==null){

//****** Add the ''for'' loop code here
    for (int i = 1; i < number; i++) {
        ret = ret * i;
    }//for

//****** Add after the ''for'' code

dataNode=new optDataNode(keyVar);
dataNode.Add(dataNode.Store(ret));
myData.Insert(dataNode);
}else{
ret = dataNode.RecieveDouble(0);
}

//****** Add the rest of the code here
        return ret;
    }//test01()

}//class test01
