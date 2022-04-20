public class cCONSTANT_Long extends cCONSTANT_General{
    int high_bytes;
    int low_bytes;
    cCONSTANT_Long(cFile file,cTree tree){
        this.tag=5;
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
  }//class cCONSTANT_Long
