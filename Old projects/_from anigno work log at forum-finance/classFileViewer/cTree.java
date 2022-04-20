public class cTree {
    cNode root=new cNode();
    cNode last=root;
    int count=0;

    void addNode(cNode newNode){
        last.next = newNode;
        last=newNode;
        count++;
    }//addNode

    public String[] print(){
        String s[]=new String[this.count];
        cNode it=this.root.next;
        int a=0;
        while(it!=null){
            s[a++]=it.print();
            it=it.next;
        }//while
        return s;
    }//print()

    public  cNode getNodeByIndex(int index){
        int a=1;
        for(cNode it=root.next;it!=null;it=it.next){
            if(a==index)return it;
            a++;
        }//for
        System.out.println("Error, index not found!");
        return root;
    }//getNodeByIndex()
}//class cTree