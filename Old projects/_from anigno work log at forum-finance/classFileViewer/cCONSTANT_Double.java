public class cCONSTANT_Double extends cCONSTANT_General{
   int high_bytes;
   int low_bytes;
    cCONSTANT_Double(cFile file,cTree tree){
        this.tag=6;
        this.tree=tree;
        high_bytes=file.readInt();
        low_bytes=file.readInt();
        addToTree();
    }
    public String toString(){
        String s="";
        s=s+" tag="+this.tag;
        s=s+" high_bytes="+high_bytes;
        s=s+" low_bytes="+low_bytes;
        s=s+" " + this.ConstantName;
    return s;
    }//toString()
}
