import controls.calendar.aCalendar;

import javax.swing.*;

public class runner extends JApplet {
    aCalendar calendar;

    public void init() {
        super.init();
        calendar=new aCalendar(getContentPane(),30,30,2);
        setSize(300,400);
    }
}
