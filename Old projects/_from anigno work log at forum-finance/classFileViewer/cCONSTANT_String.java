public class cCONSTANT_String extends cCONSTANT_General{
    short string_index;
    cCONSTANT_String(cFile file,cTree tree){
        this.tag=8;
        this.tree=tree;
        string_index=file.readShort();
        addToTree();
    }
    public String toString(){
         String s="";
         s=s+" tag="+this.tag;
         s=s+" string_index="+string_index;
        s=s+" " + this.ConstantName;
     return s;
     }//toString()
}//class cCONSTANT_String
