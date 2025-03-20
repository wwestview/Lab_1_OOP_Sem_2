using System.Data;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Channels;
public class Timer
{
    private  int interval;
    private  Action action;
    private bool isRunning;
    private Thread timeThread;
    public Timer(int interval, Action action)
    {
        this.interval = interval * 1000;
        this.action = action;
    }
    public void Start()
    {
        isRunning = true;
        timeThread = new Thread(() =>
        {
            while (isRunning)
            {
                Thread.Sleep(interval);
                action.Invoke();
            }
        });
        timeThread.Start();
       
    }
    public void Stop () => isRunning = false;
}
class Program
{
    static void Main()
    {
        Action action = () => Console.WriteLine("Action executed at: " + DateTime.Now);
        
        Timer timer = new Timer(1, action);
        Timer timer2 = new Timer(1, action = ()=> Console.WriteLine("Action executed at 2: " + DateTime.Now));
        timer.Start(); timer2.Start();
        Thread.Sleep(10000);
        timer.Stop();
        timer2.Stop();
    }
}