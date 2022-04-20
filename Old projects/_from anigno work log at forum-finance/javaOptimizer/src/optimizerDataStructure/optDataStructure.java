package optimizerDataStructure;

import java.util.ArrayList;

//AVLTree.java
public class optDataStructure {
    public static final int NO_ERROR = 0;
    public static final int DUPLICATE_ELEMENT = 1;
    public static final int ELEMENT_NOT_FOUND = 2;
    //take the root and the current Node
    private optDataNode root;
    private optDataNode current;
    //check if the tree is valid
    private int errorCode;


    //overloading toStringFunction() to return a string for each var type
    public String ToStringFunction(Object obj) {
        return obj.toString();
    }

    public String ToStringFunction(int i) {
        return Integer.toString(i);
    }

    public String ToStringFunction(double i) {
        return Double.toString(i);
    }

    public String ToStringFunction(byte i) {
        return Byte.toString(i);
    }

    public String ToStringFunction(float i) {
        return Float.toString(i);
    }

    public String ToStringFunction(char i) {
        return Character.toString(i);
    }

    public String ToStringFunction(long i) {
        return Long.toString(i);
    }

    public int GetError() {
        return errorCode;
    }

    public optDataNode GetRoot() {
        return root;
    }

    public optDataStructure() {
        root = current = null;
        errorCode = NO_ERROR;
    }


//create the key string
    public String CreateString(ArrayList al) {
        String s = new String();
        for (int i = 0; i < al.size(); i++) {
            s = s + al.get(i) + "~";
        }
        return s;
    }


/*
    public String CreateString(ArrayList al){
     	String s = new String();
     	for (int i=0; i<al.size();i++){
     		s = s + al.get(i);
     	}
     	return s;
     }
*/

//	update level for each Node
    private void UpdateLevels(optDataNode p, int level) {
        if (p != null) {
            UpdateLevels(p.left, level + 1);
            p.level = level;
            UpdateLevels(p.right, level + 1);
        }
    }

    public void PrintTree(optDataNode p) {
        if (p != null) {
            PrintTree(p.left);
            System.out.print("state : " + p.state + " level : " + p.level + "\n");
            PrintTree(p.right);
        }
    }

    //update the tree as a simetric (left rotation) tree after delete of node and update level
    private void LLrotation(optDataNode p) {
        optDataNode cur = p, old1 = cur.left, old2 = old1.left;
        cur.left = old1.right;
        if (cur.left != null) {
            cur.left.parent = cur;
        }
        old1.right = cur;
        old1.left = old2;
        old1.parent = cur.parent;
        cur.parent = old1;
        if (old1.parent != null) {
            if (old1.CompareTo(old1.parent.state) < 0) {
                old1.parent.left = old1;
            } else {
                old1.parent.right = old1;
            }
        }

        if (old1.parent == null) {
            UpdateLevels(old1, 0);
            root = old1;
        } else {
            UpdateLevels(old1.parent, old1.parent.level);
        }

        current = cur;
    }


    //update the tree as a simetric (right rotation) tree after delete\insert of node and update level
    private void RRrotation(optDataNode p) {
        optDataNode cur = p, old1 = cur.right, old2 = old1.right;
        cur.right = old1.left;
        if (cur.right != null) {
            cur.right.parent = cur;
        }

        old1.left = cur;
        old1.right = old2;
        old1.parent = cur.parent;
        cur.parent = old1;
        if (old1.parent != null) {
            if (old1.CompareTo(old1.parent.state) > 0) {
                old1.parent.right = old1;
            } else {
                old1.parent.left = old1;
            }
        }
        if (old1.parent == null) {
            UpdateLevels(old1, 0);
            root = old1;
        } else {
            UpdateLevels(old1.parent, old1.parent.level);
        }
        current = cur;
    }

    private void LRrotation(optDataNode p) {
        optDataNode cur = p, old1 = cur.left, old2 = old1.right;
        cur.left = old2.right;
        if (cur.left != null) {
            cur.left.parent = cur;
        }
        old1.right = old2.left;
        if (old1.right != null) {
            old1.right.parent = old1;
        }
        old2.parent = cur.parent;
        cur.parent = old2;
        old1.parent = old2;
        old2.left = old1;
        old2.right = cur;
        if (old2.parent != null) {
            if (old2.CompareTo(old2.parent.state) < 0) {
                old2.parent.left = old2;
            } else {
                old2.parent.right = old2;
            }
        }
        if (old2.parent == null) {
            UpdateLevels(old2, 0);
            root = old2;
        } else {
            UpdateLevels(old2.parent, old2.parent.level);
        }
        current = cur;
    }

    private void RLrotation(optDataNode p) {
        optDataNode cur = p, old1 = cur.right, old2 = old1.left;
        cur.right = old2.left;
        if (cur.right != null) {
            cur.right.parent = cur;
        }
        old1.left = old2.right;
        if (old1.left != null) {
            old1.left.parent = old1;
        }
        old2.parent = cur.parent;
        cur.parent = old2;
        old1.parent = old2;
        old2.left = cur;
        old2.right = old1;
        if (old2.parent != null) {
            if (old2.CompareTo(old2.parent.state) > 0) {
                old2.parent.right = old2;
            } else {
                old2.parent.left = old2;
            }
        }
        if (old2.parent == null) {
            UpdateLevels(old2, 0);
            root = old2;
        } else {
            UpdateLevels(old2.parent, old2.parent.level);
        }
        current = cur;
    }

    //get the node parent
    private optDataNode FindParent(String key) {
        optDataNode p = root;
        optDataNode prev = null;
        while ((p != null) && (p.CompareTo(key) != 0)) {
            prev = p;
            if (p.CompareTo(key) < 0) {
                p = p.right;
            } else {
                p = p.left;
            }
        }
        return prev;
    }

    private int Max(int x, int y) {
        if (x > y) {
            return x;
        } else {
            return y;
        }
    }

    //find tree Height
    private int FindHeight(optDataNode p) {
        if (p == null) {
            return 0;
        } else {
            int leftHeight = 1 + FindHeight(p.left);
            int rightHeight = 1 + FindHeight(p.right);
            return Max(leftHeight, rightHeight);
        }
    }

    //looking for a value at the tree
    public optDataNode FindNode(String key) {
        optDataNode p = root;
        while ((p != null) && (p.CompareTo(key) != 0)) {
            if (p.CompareTo(key) < 0) {
                p = p.right;
            } else {
                p = p.left;
            }
        }
        return p;
    }

    //find the biggest value
    private optDataNode FindRightMost(optDataNode p) {
        while (p.right != null) {
            p = p.right;
        }
        return p;
    }
    //insert a Node

    public void Insert(optDataNode toInsert) {
        toInsert.left = toInsert.right = toInsert.parent = null;
        //check if tree is empty
        if (root == null) {
            root = current = toInsert;
            errorCode = NO_ERROR;
        } else {
            //check if exist
            optDataNode p = FindNode(toInsert.state);
            if (p == null) {
                optDataNode parent = FindParent(toInsert.state), par = null;
                if (parent.CompareTo(toInsert.state) > 0) {
                    parent.left = current = toInsert;
                } else {
                    parent.right = current = toInsert;
                }
                current.parent = parent;
                current.level = parent.level + 1;
                boolean done = false;
                int leftHeight = 0;
                int rightHeight = 0;
                char dir1 = ' ';
                char dir2 = ' ';
                while ((current != root) && (!done)) {
                    par = current.parent;
                    dir2 = dir1;
                    if (par.left == current) {
                        dir1 = 'L';
                    } else {
                        dir1 = 'R';
                    }
                    //check if simetric
                    leftHeight = FindHeight(par.left);
                    rightHeight = FindHeight(par.right);
                    if ((leftHeight == rightHeight) || (Math.abs(leftHeight - rightHeight) > 1)) {
                        done = true;
                    } else {
                        current = par;
                    }
                }
                if ((dir1 != ' ') && (dir2 != ' ') && (dir1 != dir2) && (Math.abs(leftHeight - rightHeight) > 1)) {
                    if (dir1 == 'L') {
                        LRrotation(par);
                    } else {
                        RLrotation(par);
                    }
                } else {
                    if (Math.abs(leftHeight - rightHeight) > 1) {
                        if (par.left == current) {
                            LLrotation(par);
                        } else {
                            RRrotation(par);
                        }
                    }
                }
                errorCode = NO_ERROR;
            } else {
                errorCode = DUPLICATE_ELEMENT;
            }
        }
    }

    //delete a Node
    public void Remove(String key) {
        optDataNode p = FindNode(key);
        if (p != null) {
            optDataNode parent = p.parent;
            if ((p.left == null) && (p.right == null)) {
                if (parent != null) {
                    if (parent.left == p) {
                        parent.left = null;
                    } else {
                        parent.right = null;
                    }
                } else {
                    root = null;
                }
            } else {
                if ((p.left == null) && (p.right != null)) {
                    if (parent != null) {
                        if (parent.left == p) {
                            parent.left = p.right;
                        } else {
                            parent.right = p.right;
                        }
                        p.right.parent = parent;
                    } else {
                        root = p.right;
                        root.parent = null;
                    }
                } else {
                    if ((p.left != null) && (p.right == null)) {
                        if (parent != null) {
                            if (parent.left == p) {
                                parent.left = p.left;
                            } else {
                                parent.right = p.left;
                            }
                            p.left.parent = parent;
                        } else {
                            root = p.left;
                            root.parent = null;
                        }
                    } else {
                        if ((p.left != null) && (p.right != null)) {
                            optDataNode righty = FindRightMost(p.left);
                            optDataNode rightyParent = righty.parent;
                            optDataNode temp = righty.CopyOfNode();
                            temp.left = p.left;
                            temp.right = p.right;
                            temp.parent = p.parent;
                            if (rightyParent != p) {
                                rightyParent.right = righty.left;
                            } else {
                                p.left = righty.left;
                            }
                            if (righty.left != null) {
                                righty.left.parent = rightyParent;
                            }
                            p = righty;
                        }
                    }
                }
            }
            p = null;
            current = parent;
            boolean done = false;
            int leftHeight;
            int rightHeight;
            while ((current != null) && (!done)) {
                char dir1;
                char dir2;
                leftHeight = FindHeight(current.left);
                rightHeight = FindHeight(current.right);
                if ((leftHeight == rightHeight) && (leftHeight != 0)) {
                    done = true;
                } else if (Math.abs(leftHeight - rightHeight) > 1) {
                    optDataNode temp;
                    if (leftHeight > rightHeight) {
                        dir1 = 'L';
                        temp = current.left;
                    } else {
                        dir1 = 'R';
                        temp = current.right;
                    }
                    leftHeight = FindHeight(temp.left);
                    rightHeight = FindHeight(temp.right);
                    if (leftHeight > rightHeight) {
                        dir2 = 'L';
                    } else {
                        if (leftHeight < rightHeight) {
                            dir2 = 'R';
                        } else {
                            dir2 = dir1;
                        }
                    }
                    if (dir1 == 'L') {
                        if (dir2 == 'L') {
                            LLrotation(current);
                        } else {
                            LRrotation(current);
                        }
                    } else {
                        if (dir1 == 'R') {
                            if (dir2 == 'L') {
                                RLrotation(current);
                            } else {
                                RRrotation(current);
                            }
                        }
                    }
                } else {
                    parent = current.parent;
                    current = parent;
                }
            }
            //end while
            if (parent == null) {
                UpdateLevels(root, 0);
            } else {
                UpdateLevels(parent, parent.level);
            }
            errorCode = NO_ERROR;
        } else {
            errorCode = ELEMENT_NOT_FOUND;
        }
    }

    public optDataNode AlreadyIncludes(optDataNode p) {
        return FindNode(p.state);
    }

    public int GetErrorCode() {
        return errorCode;
    }

}
