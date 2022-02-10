// Create People class to be able to put Last name first then any other given name to be sorted.
// Its implement IComparable (interface) so the class inheritance can be sorted.
// it must implement CompareTo Method.
public class People : IComparable<People>
{
    public string LastName;
    public string AnyName;

    public People(string LastName, string AnyName)
    {
        this.LastName = LastName;
        this.AnyName = AnyName;
    }

    public int CompareTo(People varPeople)
    {
        if (varPeople == null) { return 1; }

        //In the CompareTo method, we first compare the Last Name.
        ////If the rank is the same, we compare AnyGivenName.
        int result = String.Compare(LastName, varPeople.LastName);
        return result != 0 ? result : this.AnyName.CompareTo(varPeople.AnyName);
    }

    public override string ToString()
    {
        return AnyName + LastName;
    }

}
public class NameSorter
{

    static void Main(string[] args)
    {
        //check if file unsorted-names-list.txt is exsist if not then exit program
        Boolean blnCheckunsortedfile = System.IO.File.Exists(@"unsorted-names-list.txt");
        if (!blnCheckunsortedfile) 
        {
            System.Console.WriteLine("file not FOUND");
            return;
        }

        //read all line in unsorted-names-list.txt and stored in array of string
        string[] lines = System.IO.File.ReadAllLines(@"unsorted-names-list.txt");

        List<People> listPeople = new List<People>();

        foreach (string line in lines)
        {
            string LastName = ""; string AnyName = "";

            //devide name part using  spaces between name part.
            string[] names = line.Split(' ');

            //for all part of name except the last one put it on AnyName Variable.
            for (int i = 0; i < names.Length-1; ++i)
            {
                AnyName += names[i] + " ";
            }

            LastName = names[names.Length - 1];

            //for each full name store create People Class
            People name1 = new People(LastName, AnyName);

            //add every people class created in the ListPeople List.
            listPeople.Add(name1);

            //show the un-sorted data in screen.
            Console.WriteLine(line);
        }

        Console.WriteLine("\n");

        //sort the ArrayList ListPeople
        listPeople.Sort() ;
        
        //Write back all sorted data in ListPeople to a string variable in line by line. 
        string content ="";
        foreach (People list in listPeople)
        {
            content += list.ToString()+ "\n";
        }
        //Write the string variable to the file output/sorted-names-list.txt.
        using (StreamWriter outputFile = new StreamWriter(@"sorted-names-list.txt"))
        {
            outputFile.WriteLine(content);
            outputFile.Close();
        }

        //show the sorted data in screen.
        Console.WriteLine(content);

    }


}
