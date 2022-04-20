package optimizer;

import java.util.ArrayList;

public class cVarList {
    public ArrayList list=new ArrayList();

    public void addUniqueByVarName(cVar var){
        for(int i=0;i<list.size();i++){
            cVar v=(cVar)list.get(i);
            if(var.varName.equals(v.varName))return;
        }//for
        list.add(var);
    }//addUnique()

    public void removeByName(String varName){
        for(int i=0;i<size();i++){
            String name=get(i).varName;
            if(name.equals(varName))list.remove(i);
        }//for
    }//removeByName()

    public int size(){
        return list.size();
    }//size()

    public cVar get(int i){
        return (cVar)list.get(i);
    }//get()

    public String toString(){
        String ret="";
        for(int i=0;i<list.size();i++){
            ret+=((cVar)list.get(i)).toString()+"\n";
        }//for
        return ret;
    }//toString()
}//class cVarList
