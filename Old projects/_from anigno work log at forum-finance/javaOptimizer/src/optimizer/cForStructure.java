package optimizer;
import JavaCC.SimpleNode;
import java.util.ArrayList;

/**
 * data for the for loop structure.
 * hold input vars and output vars and var types
 */
public class cForStructure {
    public SimpleNode forInitNode=null;
    public SimpleNode expressionNode=null;
    public SimpleNode forUpdateNode=null;
    public SimpleNode statementNode=null;

    public cVarList forInit=new cVarList();
    public cVarList expression=new cVarList();
    public cVarList forUpdate=new cVarList();
    public cVarList statement=new cVarList();

    public cVarList locals=new cVarList();

    public cVarList inputVars=new cVarList();
    public cVarList outputVars=new cVarList();

    public String toString(){
        String ret="";
        ret+="inputs:\n"+inputVars.toString();
        ret+="outputs:\n"+outputVars.toString();
        ret+="locas:\n"+locals.toString();
        return ret;
    }//toString()

    
}//class cForStructure
