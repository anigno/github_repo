package simpleNodeTree;

import JavaCC.SimpleNode;
import JavaCC.JavaParserTreeConstants;

import java.util.ArrayList;

import optimizer.cForStructure;
import optimizer.cVarList;
import optimizer.cVar;


public class cSimpleNodeTree {

    public SimpleNode root=null;

    //constructor
    public cSimpleNodeTree(SimpleNode root){
        this.root=root;
    }//cSimpleNode()

    //print the tree from the root
    public String toString(){
        return printTree(root,0);
    }//toString()

    //print sub-tree from node
    public String toString(SimpleNode node){
        return printTree(node,0);
    }//toString()

    //build the printing tree (recoursive function)
    public String printTree(SimpleNode parserNode,int n){
        String ret="";
        for(int i=0;i<n;i++)ret+="|  ";
        ret+="|--";
        ret+=parserNode.toString();
/*
        ret+=" ( "+parserNode.firstToken.image;
        ret+=" , "+parserNode.otherToken.image;
        ret+=" , "+parserNode.lastToken.image+" )";
*/
        ret+="\n";
        if(parserNode.children!=null){
            if(parserNode.children.length>0){
                for(int i=0;i<parserNode.children.length;i++){
                    ret+=printTree((SimpleNode)parserNode.children[i],n+1);
                }//if
            }//if
        }//if
        return ret;
    }//printTree

    public int getIdFromName(String name){
        for(int i=0;i<JavaParserTreeConstants.jjtNodeName.length;i++){
            if(JavaParserTreeConstants.jjtNodeName[i]==name){
                return i;
            }//if
        }//for
        return -1;
    }//getIdFromName

    /*get the 4 FOR nodes*/
    public void getForStructure(SimpleNode root, cForStructure forStructure){
        forStructure.forInitNode=(SimpleNode)root.children[0];
        forStructure.expressionNode=(SimpleNode)root.children[1];
        forStructure.forUpdateNode=(SimpleNode)root.children[2];
        forStructure.statementNode=(SimpleNode)root.children[3];
    }//getForStructure()

    public SimpleNode findNode(SimpleNode root,String nameID){
        int id=getIdFromName(nameID);
//        System.out.println(JavaParserTreeConstants.jjtNodeName[root.id]);
        if(id==root.id)return root;
        if(root.children!=null){
            for(int i=0;i<root.children.length;i++){
                SimpleNode n=findNode((SimpleNode)root.children[i],nameID);
                if(n!=null)return n;
            }//for
        }//if
        return null;
    }//findNode()

    //find all node with nameID, add them to arraylist
    public void findAllNodes(SimpleNode root,String nameID,cVarList ret){
        int id=getIdFromName(nameID);
        //System.out.println(JavaParserTreeConstants.jjtNodeName[root.id]);
        if(id==root.id){
            cVar v=new cVar();
            v.varNode=root;
            v.varName=root.firstToken.image;
            ret.addUniqueByVarName(v);
        }//if
        if(root.children!=null){
            for(int i=0;i<root.children.length;i++){
                findAllNodes((SimpleNode)root.children[i],nameID,ret);
            }//for
        }//if
    }//findAllNodes()

    public void getVarType(cVar var,String varName){
        String scope=var.varNode.scope;
        String ret="";
        while(scope.length()>0){
            ret=searchVarType(var.varNode,(SimpleNode)root,varName,scope);
            //check for __TERMINATE_ string, to abandon current scope
            if( (ret.length()>0)&&(!ret.equals("__TERMINATE_"))){
                var.varType=ret;
                return;
            }//if
            scope=scope.substring(0,scope.lastIndexOf('|'));
        }//while
    }//getVarType()

    private String searchVarType(SimpleNode originNode,SimpleNode node,String varName,String scope){
        if(node.scope.equals(scope)){
            if(node.idString.equals("FieldDeclaration")){
                if(node.otherToken.image.equals(varName))return node.firstToken.image;
            }//if
            if(node.idString.equals("LocalVariableDeclaration")){
                if(node.otherToken.image.equals(varName))return node.firstToken.image;
            }//if
        }//if
        if(node.children!=null){
            for(int i=0;i<node.children.length;i++){
                //check reach origin node,
                //  will not continue after it (simple return __TERMINATE_ string)
                //the length is move then zero, so recoursive function will return to
                //parent call
                if((SimpleNode)node.children[i]==originNode)return "__TERMINATE_";
                String ret=searchVarType(originNode,(SimpleNode)node.children[i],varName,scope);
                if(ret.length()>0)return ret;
            }//for
        }//if
        return "";
    }//searchType()
/*
    public String getNodeVarType(SimpleNode node){
        String ret="";
        while(node.parent!=null){
            node=(SimpleNode)node.parent;
            ret=searchType(node,node.firstToken.image);
            if(!ret.equals(""))return ret;
        }//while
        return ret;
    }//getNodeVarType()

    private String searchType(SimpleNode node,String varName){
        String ret="";

        return ret;
    }//searchType()
  */
}//class cSimpleNode
