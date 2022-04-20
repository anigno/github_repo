package gui;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.*;
import JavaCC.*;
import TokenList.cTokenList;
import simpleNodeTree.*;
import optimizer.cOptimizer;

public class tGui extends JFrame implements MouseListener,ActionListener{

    JavaParser parser;
    cTokenList tokenList;
    JTextArea txtCode;
    JScrollPane txtCodeScrollPane;
    cListBox lstSourceCode;
    JButton btnOptimize;
    cSimpleNodeTree tree;                                     //the builded parse tree
    SimpleNode startNode=null;                      //the user choosen start node
    Menu mnuFile = new Menu("File");
    MenuItem mnuFileOpen = new MenuItem("Open");
    MenuItem mnuFileExit = new MenuItem("Exit");

    //the only main to run this application
    public static void main(String args[]) {
        new tGui();
    }//main()

    public tGui(){
        super("Java optimizer");
        initFrame();
    }//JavaOptimizer()

    private void initFrame(){
        //frame init
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.getContentPane().setLayout(null);
        this.setSize(910,620);
        createMenu();
        //lstSourceCode
        lstSourceCode=new cListBox();
        lstSourceCode.listScrollPane.setBounds(0,0,300,550);
        this.getContentPane().add(lstSourceCode.listScrollPane);
        lstSourceCode.addMouseListener(this);
        //txtCode
        txtCode=new JTextArea();
        txtCodeScrollPane=new JScrollPane(txtCode);
        txtCodeScrollPane.setBounds(400,0,500,550);
        this.getContentPane().add(txtCodeScrollPane);
        this.show();
        //btnOptimize
        btnOptimize=new JButton("Optimize");
        btnOptimize.addMouseListener(this);
        btnOptimize.setBounds(300,0,100,50);
        this.getContentPane().add(btnOptimize);
    }//initFrame()


    private void createMenu(){
        MenuBar mnuMain=new MenuBar();
        //Menu  mnuFile=new Menu("File");
        //MenuItem mnuFileOpen=new MenuItem("Open");
        mnuFileOpen.addActionListener(this);
        //MenuItem mnuFileExit=new MenuItem("Exit");
        mnuFileExit.addActionListener(this);
        mnuFile.add(mnuFileOpen);
        mnuFile.add(mnuFileExit);
        mnuMain.add(mnuFile);
        this.setMenuBar(mnuMain);
    }//createMenu

    private void writeTokensInListBox(){
        /*writes user program, as tokens in lstSourceCode listBox*/
        String sourceText="";
        int lastLine=0;
        for(int i=0;i<tokenList.tokens.size();i++){
            Token t=(Token)(tokenList.tokens.get(i));
            if(lastLine!=t.beginLine){
                lastLine=t.beginLine;
                lstSourceCode.addElement(sourceText);
                sourceText="";
            }//if
            sourceText+=t.image+" ";
        }//for
    }

    //****** EVENTS FUNCTIONS******
    private void mnuFileOpen_clicked(){
        //clear content
        lstSourceCode.removeAll();
        //create and show file dialog
        FileDialog fd=new FileDialog(this);
        fd.show();
        if(fd.getFile()!=null){
            try {
                parser = new JavaParser( new FileInputStream(fd.getDirectory()+fd.getFile()) );
            } catch (FileNotFoundException e1) {
                e1.printStackTrace();
            }//catch
            try {
                //run the parser
                parser.CompilationUnit();
                System.out.println("Java Parser Version 1.1:  Java program parsed successfully.");
                //get the JavaParser's root node
                SimpleNode root=(SimpleNode) parser.jjtree.rootNode();
                //set the SimpleNodeTree
                tree=new cSimpleNodeTree(root);
                //create and build the token arrayList
                tokenList=new cTokenList(root);
                //write the tokens in a listBox
                writeTokensInListBox();
            }catch (ParseException e2) {
                //todo: handle parser error message to user!
                System.out.println(e2.getMessage());
                System.out.println("Java Parser Version 1.1:  Encountered errors during parse.");
            }//catch
        }//if
    }//mnuFileOpen_clicked()

    private void btnOptimize_clicked(){
        int lineNumber=lstSourceCode.getSelectedIndex();
        Token firstTokenSelected=null;
        //check for selection in listBox
        if(lstSourceCode.getSelectedIndex()>-1){
            //get the first token selected by line number
            for(int i=0;i<tokenList.tokens.size();i++){
                Token t=(Token)tokenList.tokens.get(i);
                if(t.beginLine==lineNumber){
                    firstTokenSelected=(Token)tokenList.tokens.get(i);
                    break;
                }//if
            }//for
            //search for "for" starting with the firstTokenSelected
            Token t=null;
            for(t=firstTokenSelected;t.image.toLowerCase()!="for";t=tokenList.getNextToken(t));
            firstTokenSelected=t;
            //get the start node for the first token selected
            startNode=firstTokenSelected.connectedNode;
            System.out.println("first token selected: "+firstTokenSelected.image);
            //System.out.println(tree.toString(startNode));

            //System.out.println(tree.printTree(tree.root, 0));
            //create and run the optimizer
            cOptimizer opt=new cOptimizer(tree,startNode);
            txtCode.setText(opt.getOptimizedCode());
        }//if
    }//btnOptimize_clicked()

    //****** EVENTS HANDLERS ******
    public void mouseReleased(MouseEvent e) {
        Object source=e.getComponent();
        if(source==btnOptimize){
            btnOptimize_clicked();
        }//if
    }//mouseReleased()

    public void actionPerformed(ActionEvent e) {
        if(e.getSource()==mnuFileOpen)mnuFileOpen_clicked();
        if(e.getSource()==mnuFileExit)System.exit(0);
    }//actionPerformed()

    public void mouseClicked(MouseEvent e) {}
    public void mouseEntered(MouseEvent e) {}
    public void mouseExited(MouseEvent e) {}
    public void mousePressed(MouseEvent e) {}
}//class main
