public class cCONSTANT_Float extends cCONSTANT_General{
    int bytes;
    cCONSTANT_Float(cFile file,cTree tree){
        this.tag=4;
        this.tree=tree;
        bytes=file.readInt();
        addToTree();
    }
    public String toString(){
        String s="";
        s=s+" tag="+this.tag;
        s=s+" bytes="+bytes;
        s=s+" " + this.ConstantName;
    return s;
    }//toString()
}//class cCONSTANT_Float