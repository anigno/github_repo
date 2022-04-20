import java.util.Vector;

public class cNode {
    Object current=null;    //current constant reference
    cNode next=null;
    Vector connection=new Vector();     //other cNodes that share data with this cNode
    int lineNumber=0;       //line number in the JList, where this node is places
    cConstantViewer constantViewer;     //the cConstantViewr that hold this cNode

    public void addConnection(cNode node){
        connection.addElement(node);
        //node.connection.addElement(this);
    }//addConnection()

    public String print(){
        String s="";
        cCONSTANT_General c=(cCONSTANT_General) current;
        //System.out.println(c.index+":"+ c);
        s=s+c.index+":"+ c;
        return s;
    }//print()
}//class cNode
