using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication42.Models;
using GraphAlgorithms;

namespace WebApplication42.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            using (DBModels db = new DBModels())
            {

                int[,] generateMatrix() //removed parameter
                {
                    //right now it takes ALL volunteers and ALL requesters addresses
                    //this needs to be changed so that we only take addresses based on their resource type id
                    List<useraddress> ua = new List<useraddress>();
                    List<requsetaddress> ra = new List<requsetaddress>();
                    ua = db.useraddresses.ToList();
                    ra = db.requsetaddresses.ToList();

                    //some parameters to keep track
                    int size;
                    int difference1 =0, difference2 =0;

                    
                    
                    //If volunteers are more than requesteors
                    if (ua.Count > ra.Count)
                    {
                        //set the matrix size to the largest of the two
                        size = ua.Count; 
                        //keep a track of how much larger volunteers are then requestors
                        difference1 = ua.Count - ra.Count;
                    }

                    else if (ra.Count>ua.Count)
                    {
                        //set the matrix size to the largest of the two
                        size = ra.Count;
                        //keep a track of how much larger requesters are then volunteers
                        difference2 = ra.Count - ua.Count;
                    }
                    else
                    {
                        //In case neither is greater than the other(both are equal) set the matrix size equal to one of their size
                        size = ra.Count;
                    }

                    var matrix = new int[size, size];//Make a matrix with the greater of the two (volunteer VS requestor)sizes

                    //fill with 0's for unbalanced if volunteers are less than requesters
                    if (difference2 > 0)
                    {

                        for (int i = ua.Count; i < (ua.Count + difference2); i++)
                            for (int j = 0; j < size; j++)
                                matrix[i, j] = 0; //Fills all the remaining volunteers rows with 0s
                    }

                    //fill with 0s for unblanaced if requesters are less than volunteers
                    if (difference1 > 0)
                    {

                        for (int i = size; i < ua.Capacity; i++)
                            for (int j = ra.Count; j < (ra.Count+difference1); j++)
                                matrix[i, j] = 0;//Fills all the remaining requestor columns with 0s
                    }





                    //variables to store all the address information for volunteers and requestors
                    String Vstreet, Vcity, Vstate, Vzipcode, Rstreet, Rcity, Rstate, Rzipcode;
                    
                   
                    for (int i = 0; i < ua.Capacity; i++)
                    {
                        //For each row store the volunteer address 

                            Vstreet = ua.ElementAt(i).Street;
                            Vcity = ua.ElementAt(i).city;
                            Vstate = ua.ElementAt(i).state;
                            Vzipcode = ua.ElementAt(i).zipcode;

                        //Store all address concatnated in string
                        String volunteerlocation = Vstreet + " " + Vcity + " " + Vstate + " " + Vzipcode;

                        for (int j = 0; j < size; j++)
                        {
                            //For each column store the requestors address
                            Rstreet = ra.ElementAt(j).street;
                            Rcity = ra.ElementAt(j).city;
                            Rstate = ra.ElementAt(j).state;
                            Rzipcode = ra.ElementAt(j).zipcode;

                            //This is ur code, i only modified it with the new google key (and of course address concatnation)
                            WebClient client = new WebClient();

                            String requesterlocation = Rstreet + " " + Rcity + " " + Rstate + " " + Rzipcode;
                            String location = volunteerlocation + "&destinations=" +requesterlocation;

                            //Concatnate the final string and pass it.
                            String maplocation = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=" + location + /*this is key, put ur key here-->*/ "&key=AIzaSyDghQ0T59XCXI4_-2PEj_0OJnCM2XrynZU";

                            string stream = client.DownloadString(maplocation);
                            GlossaryTransferObject glossaryTransfer = Newtonsoft.Json.JsonConvert.DeserializeObject<GlossaryTransferObject>(stream);
                            int time = glossaryTransfer.rows[0].elements[0].duration.value;

                            //So finally!!!, all the duration in time is store to their respective columns xD
                            matrix[i , j] = time;

                        }
                    }
                    //return matrix for processing
                    return matrix;
                }

                 void printMatrix(int[,] matrix)
                {
                    Console.WriteLine("Matrix:");
                    var size = matrix.GetLength(0);
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                            Console.Write("{0,5:0}", matrix[i, j]);
                        Console.WriteLine();
                    }
                }

                 String printArray(int[] array)
                {
                    Console.WriteLine("Array:");
                    String arraycost = null;
                    var size = array.Length;
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write("{0,5:0}", array[i]);
                        arraycost = arraycost + " "+array[i].ToString();
                    }
                    Console.WriteLine();
                    
                    return arraycost;
                }


                {
                    
                        


                    var matrix = generateMatrix();

                    printMatrix(matrix);

                    var algorithm = new HungarianAlgorithm(matrix);

                    var result = algorithm.Run();

                    ViewBag.M = printArray(result);
                }
                //Console.ReadKey();
                //return (0);
                


                //WebClient client = new WebClient();


                //        string stream = client.DownloadString("https://maps.googleapis.com/maps/api/distancematrix/json?origins=413+san+jacinto+street+la+porte+texas+77571&destinations=2305+bay+area+blvd+houston+texas+77058&key=AIzaSyDghQ0T59XCXI4_-2PEj_0OJnCM2XrynZU");
                //        GlossaryTransferObject glossaryTransfer = Newtonsoft.Json.JsonConvert.DeserializeObject<GlossaryTransferObject>(stream);
                //        int time = glossaryTransfer.rows[0].elements[0].duration.value;






                   

            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Will implement at a later date";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Will be added shortly!";

            return View();
        }
    }
}

public class GlossaryTransferObject
{
    public string[] destination_addresses { get; set; }
    public string[] origin_addresses { get; set; }
    public Row[] rows { get; set; }
    public string status { get; set; }
}

public class Row
{
    public Element[] elements { get; set; }
}

public class Element
{
    public Distance distance { get; set; }
    public Duration duration { get; set; }
    public string status { get; set; }
}

public class Distance
{
    public string text { get; set; }
    public int value { get; set; }
}

public class Duration
{
    public string text { get; set; }
    public int value { get; set; }
}