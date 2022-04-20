package utils;
/**
 * timer with start and stop controlls
 */
public class cTimer {
    long begin=0;
    long end=0;
    /**
     * reset the timer and start counting
     */
    public void start(){
        begin = System.currentTimeMillis();
    }//start()
    /**
     * stop the timer
     */
    public void stop(){
        end=System.currentTimeMillis();
    }//stop();
    /**
     * get the time between start() and stop()
     * @return long, time in milliseconds
     */
    public long getTimeDif(){
        return end-begin;
    }//getTimeDiff();
}//class cTimer
