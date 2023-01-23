// See https://aka.ms/new-console-template for more information
using System.Collections.Immutable;
using System.Text;
using System.Text.RegularExpressions;


//"Work update of January 18, 2022"
//worked from 9:45 AM to 7:00 PM
//worked from 9:50 AM to 5:45 PM
    StringBuilder DatePattern = new StringBuilder(@"[A-z]+(ary|rch|ril|ay|ne|ly|st|ber)\s?\d{1,2}\s?(,|-)?\s?\d{4}");

    StringBuilder TimePattern = new StringBuilder(@"\d{1,2}:\d{1,2}\s?(AM|am|Am|PM|Pm|pm)\s?(to|To)\s?\d{1,2}:\d{1,2}\s?(AM|am|Am|PM|Pm|pm)\s?");

    StringBuilder WorkPattern = new StringBuilder(@"(\*[^*\n]+)");

    string FileLoc = "C:\\Users\\SECL\\Documents\\WorkUpdate.txt";

    string[] lines = File.ReadAllLines(FileLoc);



    WorkUpdate workObj;

    string ?workDate=null;
    string ?workUpdate=null;
    string ?workTime=null;
    
    List<WorkUpdate>  workUpdateList= new List<WorkUpdate>();

    for (int i = 0; i < lines.Length; i++)
        {
   
            if (Regex.IsMatch(lines[i],DatePattern.ToString()))
            {
                workDate = Regex.Match(lines[i], DatePattern.ToString()).Value;
                // Console.WriteLine(workDate);
               
            }
        
            else if (Regex.IsMatch(lines[i], WorkPattern.ToString()))
            {

                workUpdate=workUpdate
                +Regex.Match(lines[i],WorkPattern.ToString()).ToString();
                //Console.WriteLine(workUpdate);
             
            }

            else if (Regex.IsMatch(lines[i],TimePattern.ToString()))
            {
                workTime = Regex.Match(lines[i], TimePattern.ToString()).Value;
                //Console.WriteLine(workTime);
                
                workObj = new WorkUpdate(workDate, workTime, workUpdate);
                workDate = null;
                workTime = null;
                workUpdate= null;
                workUpdateList.Add(workObj);

        }
    

            
        }


 for(int i=0; i < workUpdateList.Count; i++)
{
    Console.WriteLine(workUpdateList[i].Time.ToString());
    Console.WriteLine(workUpdateList[i].Date.ToString());
    Console.WriteLine(workUpdateList[i].Work.ToString());


}




//Console.WriteLine(Workupdate.ToString());   

//Console.WriteLine(Regex.Match(text,TimePattern.ToString()));
//Console.WriteLine(Regex.Match(text, DatePattern.ToString()));
//Console.WriteLine(Regex.Match(text, Work.ToString()));

//Console.WriteLine(text);
//String text = "";

//MatchCollection matches = Regex.Matches(text, Work.ToString());

//StringBuilder Workupdate = new StringBuilder();


//foreach (var match in matches)
//{
//    Console.WriteLine(match);


//}

public class WorkUpdate
{
    public string Date;
    public string Time;
    public string Work;

    public WorkUpdate(string date,string time, string work)
    {
        Date = date;
        Time = time;
        Work = work;
    }
}