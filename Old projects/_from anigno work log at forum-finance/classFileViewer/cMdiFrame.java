import javax.swing.*;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;

public class cMdiFrame extends JFrame implements MouseListener {
    JDesktopPane desktop;
    cMainFrame mainFrame;
    JMenuBar menuBar;
    JMenu menuFile;
    JMenuItem menuOpen;
    JMenuItem menuExit;
    JMenu menuHelp;
    JMenuItem menuAbout;
    JFileChooser fileChooser;
    cFileFilter filter;
    cTree tree;
    cConstantViewer constantViewer[];

    cMdiFrame(){
        super("Class file viewer");
        desktop=new JDesktopPane();
        setContentPane(desktop);
        setSize(640,480);
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setDefaultLookAndFeelDecorated(true);
        menuInit();
        show();
    }//cMdiForm()

    private void menuInit(){
        menuBar=new JMenuBar();
        menuFile=new JMenu("File");
        menuOpen=new JMenuItem("Open class file");
        menuOpen.addMouseListener(this);
        menuExit=new JMenuItem("Exit");
        menuExit.addMouseListener(this);
        menuHelp=new JMenu("Help");
        menuAbout=new JMenuItem("About");
        menuAbout.addMouseListener(this);
        menuBar.add(menuFile);
        menuFile.add(menuOpen);
        menuFile.add(menuExit);
        menuBar.add(menuHelp);
        menuHelp.add(menuAbout);
        setJMenuBar(menuBar);
        show();
    }//menuInit()

    private void createConstantFrames(JDesktopPane desktop){
            constantViewer=new cConstantViewer[13];
            String constantName[]={
                                "",
                                "CONSTANT_Utf8",
                                "",
                                "CONSTANT_Integer",
                                "CONSTANT_Float",
                                "CONSTANT_Long",
                                "CONSTANT_Double",
                                "CONSTANT_Class",
                                "CONSTANT_String",
                                "CONSTANT_Fieldref",
                                "CONSTANT_Methodref",
                                "CONSTANT_InterfaceMethodref",
                                "CONSTANT_NameAndType",
            };
            //create all the cConstantViewer's for each constant (no number 2)
            for(int a=1;a<=12;a++){
                if(constantName[a]!=""){    //no number 2!
                    constantViewer[a]=new cConstantViewer(constantName[a],(short)a,tree);
                    new Thread(constantViewer[a]).start();
                    desktop.add(constantViewer[a],0);
                    constantViewer[a].setVisible(true);
                }//if
            }//for
        }//createConstantFrames()


    public void mouseClicked(MouseEvent event) {
        //To change body of implemented methods use File | Settings | File Templates.
    }

    public void mouseEntered(MouseEvent event) {    }

    public void mouseExited(MouseEvent event) {    }

    public void mousePressed(MouseEvent event) {    }

    public void mouseReleased(MouseEvent event) {
        if(event.getComponent()==menuOpen){
            fileChooser=new JFileChooser();
            filter=new cFileFilter();
            fileChooser.setFileFilter(filter);
            int ret=fileChooser.showOpenDialog(this);
            if(ret==JFileChooser.APPROVE_OPTION){
                //create new cMainFrame and call tree creator and create constants frames
                String fileName=new String(fileChooser.getSelectedFile().toString());
                int i=fileName.lastIndexOf('\\');
                //getting file name only
                String fName;
                if (i > 0 &&  i < fileName.length() - 1){
                    fName=new String(fileName.substring(i+1));
                }else{
                    fName=new String("");
                }//if else
                mainFrame=new cMainFrame(desktop,fName);    //creting general data frame
                cTreeCreator treeCreator=new cTreeCreator(fileName,this,mainFrame.list);
                tree=treeCreator.tree;
                createConstantFrames(this.desktop);
            }//if
        }//if
        if(event.getComponent()==menuExit){
            System.exit(0);
        }//if
        if(event.getComponent()==menuAbout){
            JOptionPane.showMessageDialog(
                                        this,
                                        "Class file viewer\nStudent Id: 29024783",
                                        "Ex3Prog",
                                        JOptionPane.OK_OPTION
                                );
        }//if
    }//mouseReleased()
}//class cMdiForm
