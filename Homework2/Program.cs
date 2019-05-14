/// Mark Hill
/// 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {

        static void Main(string[] args)
        {
            /// Set the user list
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            // Display the passwords that are "hello"  (Name??)
            var helloPwd =
                from user in users
                where user.Password == "hello"
                select user;

            if (helloPwd == null)
            {
                Console.WriteLine("Could not find a user with a password of \"hello\".");
            }
            else
            {
                Console.WriteLine("Found these passwords:");
                Console.WriteLine("-----------------------");
                foreach (var _user in helloPwd)
                {
                    // Console.WriteLine(_user.Name + ": " + _user.Password);  // this would deem more useful
                    Console.WriteLine(_user.Password);
                }
                //Console.WriteLine("\n---------------------\n");
            }

            // Delete any passwords that are the lower-case version of the user name.

            // Hmmm...  Don't MANIPULATE the list in a for/foreach loop
            //  AND the hint is Remove or RemoveAll, which to this newby to C# seems to 
            //  imply removing the user(s), not just the Password...
            //
            // It seems to me that the intent was to keep Steve in the list, with no password,
            //  so I'm going to use the ForEach loop and take the hit.  Removing Steve would be easier
            //  but where's the fun in that.  I have done a LOT of searching and experimenting, 
            //  but nothing seemed to meet the exact requirements.

            var nameAsPwd =
                from user in users
                where user.Password == user.Name.ToLower()
                select user;

            foreach (var _user in nameAsPwd)
            {
                if (_user.Name.ToLower() == _user.Password)
                {
                    _user.Password = "";
                }
            }

            // Delete the first User that has the password "hello".

            var firstHello = users.Where(_user => _user.Password == "hello").First();
            users.Remove (firstHello);

            // Display the updated list
            Console.WriteLine("\nThis is the list now:");
            Console.WriteLine("------------------");
            foreach (var _user in users)
            {
                Console.WriteLine("UserName: " + _user.Name + "  Password: " +_user.Password);
            }
            
        }
    }
}
