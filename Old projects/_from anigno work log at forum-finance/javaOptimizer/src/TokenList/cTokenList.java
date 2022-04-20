package TokenList;
import JavaCC.SimpleNode;
import JavaCC.Token;
import java.util.ArrayList;

public class cTokenList {
    public ArrayList tokens=new ArrayList();

    public cTokenList(SimpleNode node){
        buildTokenList(node,-1);
    }//cTokenList()

    //build token list from simpleNode as root
    private int  buildTokenList(SimpleNode node,int id){
        int lastId=id;
        int retId=-1;
        if(lastId<node.firstToken.uniqueID){
            tokens.add(node.firstToken);
            lastId=node.firstToken.uniqueID;
        }//if
        if(lastId<node.otherToken.uniqueID){
            tokens.add(node.otherToken);
            lastId=node.otherToken.uniqueID;
        }//if
        if(node.children!=null){
            for(int i=0;i<node.children.length;i++){
                retId= buildTokenList((SimpleNode)node.children[i],lastId);
                if(retId>lastId)lastId=retId;
            }//for
            if(lastId<node.lastToken.uniqueID){
                tokens.add(node.lastToken);
                lastId=node.lastToken.uniqueID;
            }//if
        }//if
        return lastId;
    }//buildTokenList

    public Token getNextToken(Token token){
        Token t=null;
        for(int i=0;i<this.tokens.size();i++){
            t=(Token)this.tokens.get(i);
            if(t.uniqueID==token.uniqueID){
                //check for next token and return the next token
                if(i+1<=this.tokens.size()){
                    return (Token)this.tokens.get(i+1);
                }//if
            }//if
        }//for
        return null;
    }//getNextToken()
}//class cTokenList
