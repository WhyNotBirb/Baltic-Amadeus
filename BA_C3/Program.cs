using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace BA_C3
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Group> groupsList = new List<Group>();

            using (var reader = new StreamReader(@"New Text Document (2).csv"))
            {
                bool passedFirstline = false;

                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(';');

                    if (passedFirstline == true)
                    {


                        var group = new Group
                        {
                            Id = int.Parse(values[0]),
                            Name = values[1],
                            Type_Id = int.Parse(values[2]),
                            Type_Label = values[3],
                            Lan_Id = int.Parse(values[4]),
                            Lan_Label = values[5],
                            Children = int.Parse(values[6]),
                            Free_space = int.Parse(values[7])

                        };
                        groupsList.Add(group);

                    }
                    else
                    {
                        passedFirstline = true;
                    }



                }


            }

            List<Group> MinMax = new List<Group>();
            var maxValue = MaxValue(groupsList);
            var minValue = MinValue(groupsList);
            


            foreach (var item in groupsList)
            {
                if (item.Children == maxValue || item.Children == minValue)
                {
                    MinMax.Add(item);
                }

            }
            
            
            foreach (var item in MinMax)
            {
                string a = item.Name;
                a = a.Replace("\"","");
                a = a.Substring(0, 3);
                a = a.Replace(" ", "");
                string b = item.Lan_Label.Substring(0, 3);
                b = b.Replace("\"", "");
                string c = item.Type_Label.Remove(0, 4);
                c = c.Replace("\"", "");

                c = c.Replace("iki", "-");
               c= c.Replace("metų", "");

                Console.WriteLine("{0}_{1}_{2}", a , b , c);

            }

            List<string> languages = new List<string>();
          
            
            foreach (var item in groupsList) 
            { 
                if (!languages.Contains(item.Lan_Label))
                {
                    languages.Add(item.Lan_Label);
                    Console.WriteLine(item.Lan_Label);

                }

            }

            foreach (var item in languages)
            {        
                    double children = 0;
                    double free = 0;
                foreach (var item2 in groupsList)
                {
                    
                    
                    if (item2.Lan_Label == item)
                    {

                        children += item2.Children;
                        free += item2.Free_space;
                    }
                }
                double percent=0;
                percent = Math.Round(percent = 100 * free / (free + children), 2);
               Console.WriteLine("{0} kalbos laisvos vietos procentais: {1}%", item, percent);

            }

            





            Console.Read();



        }

        public static int MaxValue(List<Group> list)
        {
            int max = int.MinValue;

            foreach (var item in list)
            {
                if (item.Children > max)
                {
                    max = item.Children;
                }

               
            }
            Console.WriteLine(max);
            return max;

        }

        public static int MinValue(List<Group> list)
        {

            int min = int.MaxValue;
            foreach (var item in list)
            {
                if (item.Children < min)
                {
                    min = item.Children;
                }

               
            }
            Console.WriteLine(min);
            return min;

        }

      
    }

}
