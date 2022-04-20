public class cCONSTANT_NameAndType extends cCONSTANT_General{
    short name_index;
    short descriptor_index;
    cCONSTANT_NameAndType(cFile file,cTree tree){
        this.tag=12;
        this.tree=tree;
        name_index=file.readShort();
        descriptor_index=file.readShort();
        addToTree();
    }
    public String toString(){
        String s="";
        s=s+" tag="+this.tag;
        s=s+" name_index="+name_index;
        s=s+" descriptor_index="+descriptor_index;
        s=s+" " + this.ConstantName;
    return s;
    }//toString()

}//class cCONSTANT_NameAndType
