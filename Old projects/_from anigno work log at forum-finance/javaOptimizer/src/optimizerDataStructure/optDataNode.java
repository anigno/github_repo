package optimizerDataStructure;

import java.util.ArrayList;

public class optDataNode {
    protected String state;
    public optDataNode next = null;
    public optDataNode parent;
    public optDataNode child;
    public optDataNode right;
    public optDataNode left;
    public optDataNode father;
    public int degree, level;
    public boolean mark;

    public ArrayList outputValue = new ArrayList();    //output vars values list

    //run time function to be called for storing values in arrayList
    //must wrap primitives to object first
    public Integer Store(int value) {
        return new Integer(value);
    }

    public Double Store(double value) {
        return new Double(value);
    }

    public Float Store(float value) {
        return new Float(value);
    }

    public Character Store(char value) {
        return new Character(value);
    }

    public Byte Store(byte value) {
        return new Byte(value);
    }

    public Long Store(long value) {
        return new Long(value);
    }

    //run time functions for recieving values for output types
    //if primitive, un wrap it with special function

    public int RecieveInt(int i) {
        return ((Integer) this.outputValue.get(i)).intValue();
    }

    public double RecieveDouble(int i) {
        return ((Double) this.outputValue.get(i)).doubleValue();
    }

    public double RecieveFloat(int i) {
        return ((Float) this.outputValue.get(i)).floatValue();
    }

    public char RecieveCharacter(int i) {
        return ((Character) this.outputValue.get(i)).charValue();
    }

    public byte RecieveByte(int i) {
        return ((Byte) this.outputValue.get(i)).byteValue();
    }

    public Object RecieveObject(int i) {
        return this.outputValue.get(i);
    }

    public long RecieveLong(int i) {
        return ((Long) this.outputValue.get(i)).longValue();
    }


    //create new node with key
    public optDataNode(String _state) {
        state = _state;
        right = this;
        left = this;
    }

    public String GetState() {
        return state;
    }

    //avl tree mannage functions

    public optDataNode CopyOfNode() {
        optDataNode n = new optDataNode(this.state);
        return n;
    }

    public int CompareTo(String state) {
        int i = this.state.compareTo(state);
        if (i > 0) {
            //this.state is bigger then state
            return 1;
        }
        if (i < 0) {
//     		this.state is smaller then state
            return -1;
        }
        if (i == 0) {
            //there are equel
            return 0;
        }

        //    	default :
        //don't know to compare one starts with number and other with letter
        return -1000;
    }//compareTo()

    //creating the key for this node from the input vars
    public String CreateString(ArrayList al) {
        String s = new String();
        for (int i = 0; i < al.size(); i++) {
            //todo possible change
            //instead of using the string value of each var, use the hash code
            s = s + al.get(i);
        }
        return s;
    }//createString()

    //overloading add(), for adding object type values to the arraylist of vars, for this node
    public void Add(int val) {
        this.outputValue.add(new Integer(val));
    }

    public void Add(Object val) {
        this.outputValue.add(val);
    }

    public void Add(double val) {
        this.outputValue.add(new Double(val));
    }

    public void Add(byte val) {
        this.outputValue.add(new Byte(val));
    }

    public void Add(float val) {
        this.outputValue.add(new Float(val));
    }

    public void Add(char val) {
        this.outputValue.add(new Character(val));
    }

    public void Add(long val) {
        this.outputValue.add(new Long(val));
    }



    public void findValues(Object obj) {
        Integer i = null;
        Double d = null;
        Float f = null;
        Character c = null;
        Byte b = null;
        Long l = null;

        if (obj.getClass() == i.getClass()) {
            i = new Integer(((Integer) obj).intValue());
        }
        if (obj.getClass() == d.getClass()) {
            d = new Double(((Double) obj).doubleValue());
        }
        if (obj.getClass() == f.getClass()) {
            f = new Float(((Float) obj).floatValue());
        }
        if (obj.getClass() == c.getClass()) {
            c = new Character(((Character) obj).charValue());
        }
        if (obj.getClass() == b.getClass()) {
            b = new Byte(((Byte) obj).byteValue());
        }

        if (obj.getClass() == l.getClass()) {
            l = new Long(((Long) obj).longValue());
        }
    }//findValues()

}//class optDataNode




