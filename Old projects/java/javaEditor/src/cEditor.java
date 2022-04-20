import javax.swing.*;
import javax.swing.text.StyledEditorKit;
import javax.swing.text.EditorKit;
import javax.swing.event.CaretListener;
import javax.swing.event.CaretEvent;
import java.awt.*;
import java.awt.event.KeyListener;
import java.awt.event.KeyEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;

public class cEditor extends JFrame implements CaretListener, KeyListener, MouseListener{
    JTextPane textPane;
    JScrollPane scrollPane;
    Container content;
    Font fontPlain = new Font("Serif", Font.PLAIN, 20);
    Font fontBold = new Font("Serif", Font.BOLD, 20);
    StyledEditorKit sek=new StyledEditorKit();
    JButton button;


    cEditor(){
        super("Java editor");
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        content=this.getContentPane();
        this.setSize(640,480);
        content.setLayout(null);
        //init components
        textInit();
        buttonInit();
        //show the JFrame after all components were added
        this.setVisible(true);
    }//cEditor()

    void buttonInit(){
        button = new JButton("color");
        button.addMouseListener(this);
        button.setBounds(400,100,100,50);

        content.add(button);
    }//buttonInit

    void textInit(){
        textPane=new JTextPane();
        textPane.setText("//java editor");

        textPane.addCaretListener(this);
        textPane.addKeyListener(this);
        textPane.addMouseListener(this);
        scrollPane=new JScrollPane(textPane);
        scrollPane.setBounds(10,10,300,400);
        content.add(scrollPane);
        textPane.setVisible(true);
        scrollPane.setVisible(true);
        textPane.setEditorKit(sek);
    }//textInit()
    int i=15;
    public void caretUpdate(CaretEvent e) {
        System.out.println("caret at:"+e.getDot()+" selection start at:"+e.getMark());
        System.out.println("selected text:"+textPane.getSelectedText());

        //textPane.setFont(new Font("taoma",1,i++));
    }//caretUpdate()

    public void keyReleased(KeyEvent e) {
        System.out.println("key="+e.getKeyCode());
    }//keyReleased()

    public void keyPressed(KeyEvent e) {}
    public void keyTyped(KeyEvent e) {}
    public void mouseClicked(MouseEvent e) {

    }
    public void mouseEntered(MouseEvent e) {}
    public void mouseExited(MouseEvent e) {}
    public void mousePressed(MouseEvent e) {}
    public void mouseReleased(MouseEvent e) {}
}//class cEditor
