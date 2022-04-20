package optimizer;

import simpleNodeTree.cSimpleNodeTree;
import JavaCC.SimpleNode;

/**
 *Main optimizer class
 */
public class cOptimizer {
    cSimpleNodeTree mainTree;
    SimpleNode startNode;
    cForStructure forStructure=new cForStructure();

    /**
     * constructor
     * @param mainTree cSimpleNodeTree, the root of the main parsing tree
     * @param startNode SimpleNode, the node to start the optimization with
     */
    public cOptimizer(cSimpleNodeTree mainTree,SimpleNode startNode){
        this.mainTree = mainTree;
        this.startNode=mainTree.findNode(startNode,"ForStatement");
        setAllNodesScope(mainTree.root,"|0",0);
        //find input and output vars
        findVars();
        //get output vars type
        for(int i=0;i<forStructure.outputVars.size();i++){
            mainTree.getVarType(forStructure.outputVars.get(i),forStructure.outputVars.get(i).varName);
        }//for
        System.out.println(mainTree.printTree(mainTree.root, 0));
        System.out.println(forStructure);
    }//cOptimizer()

    /**
     *generate the optimized code
     * @return String, the optimized code
     */
    public String getOptimizedCode(){
        String ret="";
        ret+="//****** Copy source file to a new java file\n\n";
        ret+="//****** Add or change package declaration here (if needed)\n\n";
        ret+="//****** Add import optimizer's dataStructure\n";
        ret+="import optimizerDataStructure.*;\n\n";
        //ret+="//****** Add other imports here\n\n";
        //ret+="//****** Add class declaration here\n\n";
        ret+="//****** Add declaration for optDataStructure in class memebers declarations\n";
        ret+="optDataStructure myData=new optDataStructure();\n\n";
        //ret+="//****** Add other members declaration here\n\n";
        //ret+="//****** Add user code until the requested for loop here\n\n";
        ret+="//****** Add before the ''For'' loop: (key building)\n";
        ret+="String keyVar=";
        for(int i=0;i<forStructure.inputVars.size();i++){
            String s=forStructure.inputVars.get(i).varName;
            if(i!=0)ret=ret+"+";
            ret+="myData.ToStringFunction("+ s+")";
        }//for
        ret+=";\n";
        ret+="optDataNode dataNode=myData.FindNode(keyVar);\n";
        ret+="if(dataNode==null){\n\n";
        //ret+="//****** Add the ''for'' loop code here\n\n";
        ret+="//****** Add after the ''for'' code\n";
        //string for updating the data structure with the outputs
        ret+="dataNode=new optDataNode(keyVar);\n";
        for(int i=0;i<forStructure.outputVars.size();i++){
            String s=(String)forStructure.outputVars.get(i).varName;
            String varType = (String)forStructure.outputVars.get(i).varType;
            if( varType.equals("int")){
                s = "dataNode.Store("+s+")";
            }

            if( varType.equals("char")){
                s = "dataNode.Store("+s+")";
            }
            if( varType.equals("byte")){
                s = "dataNode.Store("+s+")";
            }
            if( varType.equals("double")){
                s = "dataNode.Store("+s+")";
            }
            if( varType.equals("float")){
                s = "dataNode.Store("+s+")";
            }
 //************************************************************************
 //zohar 10.05.05
             if( varType.equals("long")){
                s = "dataNode.Store("+s+")";
            }
//*************************************************************************
            //if it is an object no need for wrapping

            ret+="\tdataNode.Add("+s+");\n";
        }//for
        ret+="\tmyData.Insert(dataNode);\n";
        ret+="}else{\n";

        for (int i=0;i<forStructure.outputVars.size();i++){
            String varName=(String)forStructure.outputVars.get(i).varName;
            String varType = (String)forStructure.outputVars.get(i).varType;

            //the strings are according to the var type
            ret+=varName + " = ";
            if (varType.equals("int")){
                ret+="dataNode.RecieveInt("+i+");";
            }//if
            else
                if (varType.equals("char")){
                    ret+="dataNode.RecieveCharacter("+i+");";
                }//if
                else
                    if (varType.equals("byte")){
                        ret+="dataNode.RecieveByte("+i+");";
                    }//if
                    else
                        if (varType.equals("double")){
                            ret+="dataNode.RecieveDouble("+i+");";
                        }//if
                        else
                            if (varType.equals("float")){
                                ret+="dataNode.RecieveFloat("+i+");";
                            }//if
 //**********************************************************************************
//zohar 10.05.05
                            else
                                if (varType.equals("long")){
                                    ret+="dataNode.RecieveLong("+i+");";
                                  }//if
//*******************************************************************************
                            else
                            {//if object
                                ret+="("+varType+")dataNode.RecieveObject("+i+");";
                            }//else
            ret+="\n";
        }//for
        ret+="}\n\n";
//        ret+="//****** Add the rest of the code here\n";
        return ret;
    }//getOptimizedCode()

    /**
     * search for var names, add to input and output lists
     */
    private void findVars(){
        SimpleNode _statementExpressionList = null;
        //get the 4 FOR nodes (forInitNode,expressionNode,forUpdateNode,statementNode)
        mainTree.getForStructure(startNode,forStructure);
        //get all var names
        mainTree.findAllNodes(forStructure.forInitNode,"Name",forStructure.inputVars);
        mainTree.findAllNodes(forStructure.expressionNode,"Name",forStructure.inputVars);
        mainTree.findAllNodes(forStructure.forUpdateNode,"Name",forStructure.outputVars);
        mainTree.findAllNodes(forStructure.statementNode,"Name",forStructure.outputVars);
        //find local vars
        mainTree.findAllNodes(forStructure.forInitNode,"VariableDeclaratorId",forStructure.locals);
        mainTree.findAllNodes(forStructure.expressionNode,"VariableDeclaratorId",forStructure.locals);
        mainTree.findAllNodes(forStructure.forUpdateNode,"VariableDeclaratorId",forStructure.locals);
        mainTree.findAllNodes(forStructure.statementNode,"VariableDeclaratorId",forStructure.locals);
        //locals from forInit, (i=c,j=d then i,j are locals)
        if ((_statementExpressionList = mainTree.findNode(forStructure.forInitNode,"StatementExpressionList")) != null){
            mainTree.findAllNodes( _statementExpressionList,"StatementExpression",forStructure.locals);
        }//if
        //remove local Vars from input
        for(int i=0;i<forStructure.locals.size();i++){
            String varName=forStructure.locals.get(i).varName;
            forStructure.inputVars.removeByName(varName);
            forStructure.outputVars.removeByName(varName);
        }//for
        //todo: printing the for sub tree
        //System.out.println(forStructure);
    }//findVars()

    /**
     * check if a node is openinig new scope
     * @param node
     * @return boolean, true if the node is opening new scope
     */
    private boolean isOpenScope(SimpleNode node){
        if(node.idString.equals("BlockStatement")){
            if(node.firstToken.image.equals("for"))return true;
            if(node.firstToken.image.equals("while"))return true;
            if(node.firstToken.image.equals("do"))return true;
            if(node.firstToken.image.equals("if"))return true;
            if(node.firstToken.image.equals("switch"))return true;
            if(node.firstToken.image.equals("{"))return true;
        }//if
        if(node.idString.equals("ClassOrInterfaceBody"))return true;
        if(node.idString.equals("MethodDeclaration"))return true;
        return false;
    }//isOpenScope()

    /**
     * update the node.scope member for all nodes (recoursivlly)
     * @param node SimpleNode, the node to start with
     * @param prevScope String, previous scope of upper level
     * @param nextScope int, next scope counter
     * @return  int, next scope from counting
     */
    public int setAllNodesScope(SimpleNode node, String prevScope,int nextScope){
        if(isOpenScope(node)){
            node.scope=prevScope+"|"+nextScope;
            nextScope++;
        }else{
            node.scope=prevScope;
        }//if else
        if(node.children!=null){
            for(int i=0;i<node.children.length;i++){
                nextScope=setAllNodesScope((SimpleNode)node.children[i],node.scope,nextScope);
            }//for
        }//if
        return nextScope;
    }//setAllNodesScope()

}//class cOptimizer
