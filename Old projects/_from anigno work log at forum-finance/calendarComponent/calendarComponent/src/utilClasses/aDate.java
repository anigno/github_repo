package utilClasses;

import java.util.Date;

public class aDate {
    private int day;
    private int month;
    private int year;
    private Date date;

    public boolean equals(aDate date) {
       if (day != date.day) return false;
        if (month != date.month) return false;
        if (year != date.year) return false;
        return true;
    }

    public aDate(){
        date=new Date();
        initVars();
    }

    public aDate(aDate otherDate){
        date=new Date();
        this.setDay(1); //prevent month from changing because of day to big
        this.setYear(otherDate.getYear());
        this.setMonth(otherDate.getMonth());
        this.setDay(otherDate.getDay());
        initVars();
    }//aDate()

    public aDate(int year,int month,int day){
        date=new Date();
        this.setDay(1); //prevent month from changing because of day to big
        this.setYear(year);
        this.setMonth(month);
        this.setDay(day);
        initVars();
    }

    private void initVars(){
        day=date.getDate();
        month=date.getMonth()+1;
        year=date.getYear()+1900;
    }//initVars()

    public void changeDays(int days){
        date.setDate(this.day+days);
        initVars();
    }//nextDay()
    public void changeMonth(int month){
        date.setMonth(this.month+month-1);
        initVars();
    }//nextDay()
    public void changeyears(int years){
        date.setYear(this.year+years-1900);
        initVars();
    }//nextDay()

    public int getDay() {
        return day;
    }

    public int getMonth() {
        return month;
    }

    public int getYear() {
        return year;
    }

    public int getDayOfWeek(){
        return date.getDay();
    }

    public void setDay(int day) {
        date.setDate(day);
        initVars();
    }

    public void setMonth(int month) {
        date.setDate(1);
        date.setMonth(month-1);
        initVars();
    }

    public void setYear(int year) {
        date.setYear(year-1900);
        initVars();
    }

    public void setDate(aDate otherDate){
        this.setDay(1); //prevent month from changing because of day to big
        this.setYear(otherDate.getYear());
        this.setMonth(otherDate.getMonth());
        this.setDay(otherDate.getDay());
        initVars();
    }

    public String toString(){
        String s;
        s=""+day+"/"+month+"/"+year;
        return s;
    }//toString()


}//class aDate
