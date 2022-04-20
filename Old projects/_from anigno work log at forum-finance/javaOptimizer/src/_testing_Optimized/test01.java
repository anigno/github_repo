//****** Add package declaration here
package _testing_Optimized;
//****** Add import optimizer's dataStructure
import optimizerDataStructure.*;
import _testing.*;

//****** Add other imports here

//****** Add class declaration here
public class test01 {

//****** Add declaration for optDataStructure in class memebers declarations
optDataStructure myData=new optDataStructure();

//****** Add other members declaration here

//****** Add user code until the requested for loop here
    public test01() {
        int k = 5;
        long l = 0;

//****** Add before the ''For'' loop:
String keyVar=myData.ToStringFunction(k);
optDataNode dataNode=myData.FindNode(keyVar);
if(dataNode==null){

//****** Add the ''for'' loop code here
    for (int i = 0; i < k; i++) {
        l += i;
    }//for

//****** Add after the ''for'' code
dataNode=new optDataNode(keyVar);
dataNode.Add(dataNode.Store(l));
myData.Insert(dataNode);
}else{
l = dataNode.RecieveLong(0);
}

//****** Add the rest of the code here
        System.out.println(l);
    }//test01()

    public static void main(String args[]) {
        new _testing.test01();
    }//main()
}//class test01
