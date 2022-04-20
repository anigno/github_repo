public class cCONSTANT_General {
    cTree tree;
    byte tag;
    static long uniqueIndex=1;
    long index;
    String t=this.getClass().toString();
    String ConstantName=t.substring(7,t.length());

    public void addToTree(){
        cNode newNode=new cNode();
        newNode.current=this;
        tree.addNode(newNode);
        index=uniqueIndex++;
    }//addToTree()
}//class cConstantGeneral
