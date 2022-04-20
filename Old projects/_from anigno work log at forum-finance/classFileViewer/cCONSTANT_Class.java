public class cCONSTANT_Class extends cCONSTANT_General{
    short name_index;
    cCONSTANT_Class(cFile file,cTree tree){
        this.tag = 7;
        this.tree=tree;
         this.name_index=file.readShort();
        addToTree();
    }
    public String toString(){
        String s="";
        s=s+" tag="+this.tag;
        s=s+" name_index="+this.name_index;
        s=s+" " + this.ConstantName;
    return s;
    }//toString()
}//class cCONSTANT_Class