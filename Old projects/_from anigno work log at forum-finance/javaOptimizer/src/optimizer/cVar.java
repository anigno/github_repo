package optimizer;

import JavaCC.SimpleNode;

public class cVar {
    public String varName="";
    public String varType="";
    public SimpleNode varNode=null;

    public String toString(){
        String ret="";
        ret+=varType+" "+varName+" "+varNode.scope;
        return ret;
    }//toString()


}//class cVar
