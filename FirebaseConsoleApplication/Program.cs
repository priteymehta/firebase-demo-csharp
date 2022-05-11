using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.Library.Firebase;

namespace FirebaseConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Instanciating with base URL  
            FirebaseDB firebaseDB = new FirebaseDB("https://c-sharpcorner-2d7ae.firebaseio.com");

            // Referring to Node with name "Teams"  
            FirebaseDB firebaseDBTeams = firebaseDB.Node("Teams");

            var data = @"{  
                            'Team-Awesome': {  
                                'Members': {  
                                    'M1': {  
                                        'City': 'Hyderabad',  
                                        'Name': 'Ashish'  
                                        },  
                                    'M2': {  
                                        'City': 'Cyberabad',  
                                        'Name': 'Vivek'  
                                        },  
                                    'M3': {  
                                        'City': 'Secunderabad',  
                                        'Name': 'Pradeep'  
                                        }  
                                   }  
                               }  
                          }";

            Console.WriteLine("GET Request");
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            Console.WriteLine(getResponse.Success);
            if (getResponse.Success)
                Console.WriteLine(getResponse.JSONContent);
            Console.WriteLine();

            Console.WriteLine("PUT Request");
            FirebaseResponse putResponse = firebaseDBTeams.Put(data);
            Console.WriteLine(putResponse.Success);
            Console.WriteLine();

            Console.WriteLine("POST Request");
            FirebaseResponse postResponse = firebaseDBTeams.Post(data);
            Console.WriteLine(postResponse.Success);
            Console.WriteLine();

            Console.WriteLine("PATCH Request");
            FirebaseResponse patchResponse = firebaseDBTeams
                // Use of NodePath to refer path lnager than a single Node  
                .NodePath("Team-Awesome/Members/M1")
                .Patch("{\"Designation\":\"CRM Consultant\"}");
            Console.WriteLine(patchResponse.Success);
            Console.WriteLine();

            Console.WriteLine("DELETE Request");
            FirebaseResponse deleteResponse = firebaseDBTeams.Delete();
            Console.WriteLine(deleteResponse.Success);
            Console.WriteLine();

            Console.WriteLine(firebaseDBTeams.ToString());
            Console.ReadLine();  
        }
    }
}
