package controls.calendar;

import controls.labelBase.aDayLabelButton;
import controls.labelBase.aLabelButton;
import controls.labelBase.aLabel;
import utilClasses.aDate;
import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseListener;
import java.awt.event.MouseEvent;
import java.util.ArrayList;

public class aCalendar extends JPanel implements MouseListener {

    private aDayLabelButton[][] dayLabel;   //days label button to show and get input from calendar
    private aLabel[] monthLabels;     //month labels to show on calendar
    private int cellWidth;
    private int cellHeight;
    private int extraWeeks;     //extra weeks to display at the begining and at the end of current month
    private int totalWeeks;     //calculated number of display weeks, =(6+2*extraWeeks)
    private aDate currentDate;  //the selected date of this control
    private aLabelButton nextMonth;
    private aLabelButton prevMonth;
    private aLabelButton currentMonth;
    private aLabel[] daysHeader;
    ArrayList calendarDateSelectionListeners;
    ArrayList markedDates;

    public aCalendar(Container container,int cellWidth,int cellHeight,int extraWeeks){
        super(null);
        setBorder(BorderFactory.createEtchedBorder());
        container.add(this);
        this.cellWidth=cellWidth;
        this.cellHeight=cellHeight;
        this.extraWeeks=extraWeeks;
        totalWeeks=6+2*extraWeeks;
        setFont(new Font("Tahoma", Font.PLAIN, cellHeight * 2 / 3));
        currentDate=new aDate();    //set initial date for today
        calendarDateSelectionListeners=new ArrayList();
        markedDates=new ArrayList();
        prevMonth=new aLabelButton(this,cellWidth*2,cellHeight,"Prev");
        prevMonth.setLocation(0,cellHeight*(totalWeeks+1));
        prevMonth.addMouseListener(this);
        nextMonth=new aLabelButton(this,cellWidth*2,cellHeight,"Next");
        nextMonth.setLocation(cellWidth*6,cellHeight*(totalWeeks+1));
        nextMonth.addMouseListener(this);
        currentMonth=new aLabelButton(this,cellWidth*4,cellHeight,"");
        currentMonth.setLocation(cellWidth*2,cellHeight*(totalWeeks+1));
        currentMonth.addMouseListener(this);
        initDaysHeaderLabels();
        initDayLabels();
        initMonthLabels();
        setPanelSize();
    }

    public void addMarkedDate(aDate date){
        markedDates.add(date);
    }

    public void removeMarkedDate(aDate date){
        markedDates.remove(date);
    }

    public void clearMarkedDates(){
        markedDates.clear();
    }

    private void initDaysHeaderLabels(){
        daysHeader=new aLabel[8];
        String[] days={"Su","Mo","Tu","We","Tr","Fr","Sa"};
        for(int i=0;i<7;i++){
            daysHeader[i]=new aLabel(this,cellWidth,cellHeight*2/3,days[i]);
            daysHeader[i].setLocation(cellWidth*i,cellHeight/3);
        }

    }
    private void initMonthLabels(){
        monthLabels=new aLabel[totalWeeks/4+2];
        for(int i=0;i<totalWeeks/4+2;i++){
            monthLabels[i]=new aLabel(this,cellWidth-3,cellHeight-2,"");
        }
    }

    private void initDayLabels(){
        dayLabel=new aDayLabelButton[7][totalWeeks];
        for(int i=0;i<7;i++){
            for(int j=0;j<totalWeeks;j++){
                dayLabel[i][j]=new aDayLabelButton(this,cellWidth-2,cellHeight-2);
                dayLabel[i][j].setLocation(1+i*cellWidth,1+(j+1)*cellHeight);
                dayLabel[i][j].addMouseListener(this);
            }
        }
    }

    public void setForeground(Color color){
        super.setForeground(color);
        if(dayLabel==null)return;
        for(int i=0;i<7;i++){
            for(int j=0;j<totalWeeks;j++){
                dayLabel[i][j].setForeground(color);
            }
        }
        for(int i=0;i<totalWeeks/4+2;i++){
            monthLabels[i].setForeground(color);
        }
        prevMonth.setForeground(color);
        nextMonth.setForeground(color);
        currentMonth.setForeground(color);
        for(int i=0;i<8;i++){
            daysHeader[i].setForeground(color);
        }
    }

    public void setBackground(Color color){
        super.setBackground(color);
        if(dayLabel==null)return;
        for(int i=0;i<7;i++){
            for(int j=0;j<totalWeeks;j++){
                dayLabel[i][j].setBackground(color);
            }
        }
        for(int i=0;i<totalWeeks/4+2;i++){
            monthLabels[i].setBackground(color);
        }
        prevMonth.setBackground(color);
        nextMonth.setBackground(color);
        currentMonth.setBackground(color);
        for(int i=0;i<8;i++){
            daysHeader[i].setBackground(color);
        }
    }

    private void setPanelSize(){
        setSize(cellWidth*(7+1),cellHeight*(6+2+2*extraWeeks));
    }

    //set date to the first date on the displayed calendar, to begin count days with
    private void setStartDate(aDate date){
        //move to 1st of current month
        while(date.getDay()!=1)date.changeDays(-1);
        //move to sunday
        while(date.getDayOfWeek()!=0)date.changeDays(-1);
        //move extra weeks backwards
        for(int i=0;i<7*extraWeeks;i++)date.changeDays(-1);
    }

    public void paint(Graphics g){
        super.paint(g);
        currentMonth.setText(""+currentDate.getMonth()+"/"+currentDate.getYear());
        aDate date=new aDate(currentDate);
        setStartDate(date);
        int n=date.getMonth();
        int m=n;
        int mCnt=0; //monthLabel index counter
        for(int j=0;j<totalWeeks;j++){
            for(int i=0;i<7;i++){
                n=date.getMonth();
                //check if month number has changes to add month label
                if(n==m){
                    monthLabels[mCnt].setText(""+n);
                    monthLabels[mCnt].setLocation(7*cellWidth+1,(j+1)*cellHeight+1);
                    if(n!=currentDate.getMonth()){
                        monthLabels[mCnt].setForeground(getBackground().darker());
                    }else{
                        monthLabels[mCnt].setForeground(getForeground());
                    }
                    //check if first and secont month labels are at the same position
                    if(mCnt==1 && monthLabels[0].getY()==monthLabels[1].getY()){
                        //move second month below first month label
                        monthLabels[1].setLocation(7*cellWidth+1,(j+2)*cellHeight+1);
                    }
                    mCnt++;
                    m++;
                }
                dayLabel[i][j].setForeground(getForeground());
                dayLabel[i][j].setDate(date);
                //check and set not current month forecolor to deferent color
                if(dayLabel[i][j].getDate().getMonth()!=currentDate.getMonth())dayLabel[i][j].setForeground(getBackground().darker());
                date.changeDays(+1);
                if(date.getDay()==1){
                    g.drawLine((i+1)*cellWidth,(j+2)*cellHeight,(i+1)*cellWidth,(j+1)*cellHeight);
                    g.drawLine((i+1)*cellWidth,(j+2)*cellHeight,0,(j+2)*cellHeight);
                    g.drawLine((i+1)*cellWidth,(j+1)*cellHeight,8*cellWidth,(j+1)*cellHeight);
                }
            }
        }
        g.drawLine(0,cellHeight,0,cellHeight*(totalWeeks+1));
        g.drawLine(cellWidth*7,cellHeight,cellWidth*7,cellHeight*(totalWeeks+1));
        g.drawLine(0,cellHeight,cellWidth*8,cellHeight);
        g.drawLine(0,cellHeight*(totalWeeks+1),cellWidth*8,cellHeight*(totalWeeks+1));
    }

    public void addDateSelectionListener(calendarDateSelectionListener listener){
        calendarDateSelectionListeners.add(listener);
    }

    public void removeDateSelectionListener(calendarDateSelectionListener listener){
        calendarDateSelectionListeners.remove(listener);
    }

    private void fireDateSelectionEvent(aDate date){
        for(Object object:calendarDateSelectionListeners){
            ((calendarDateSelectionListener)object).calendarDateSelectioMade(date);
        }
    }

    public void mouseClicked(MouseEvent e) {
        if(e.getSource()==prevMonth){
            currentDate.changeMonth(-1);
            repaint();
            return;
        }
        if(e.getSource()==nextMonth){
            currentDate.changeMonth(1);
            repaint();
            return;
        }
        if(e.getSource()==currentMonth){
            currentDate.setDate(new aDate());
            repaint();
            return;
        }
        if(e.getSource().getClass()==dayLabel[0][0].getClass()){
            fireDateSelectionEvent( ((aDayLabelButton)e.getSource()).getDate() );
        }
    }

    public void mousePressed(MouseEvent e) {
    }
    public void mouseReleased(MouseEvent e) {
    }
    public void mouseEntered(MouseEvent e) {
    }
    public void mouseExited(MouseEvent e) {
    }


}
