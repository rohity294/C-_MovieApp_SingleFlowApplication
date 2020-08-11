using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;





namespace _1Version
{
    class Program
    {
        enum userType
        {
            Admin ,
            Guest
        }

        static List<Movie> MyMovieList = null;

        static void Main(string[] args)
        {
            
            StartApplication_1();
            Console.ReadLine();
        }

        //Initialize App.
        static void StartApplication_1()
        {
            //Console.Clear();
            displayWelcomeMessage();

            userType currentUser = InitializeAdmin();

            if (currentUser == userType.Admin)
            {
                processAdmin();
            }

           else if (currentUser == userType.Guest)
            {
                processGuests();
            }
            else
            {
                //Unknown User type selected.
                Console.Clear();
            }
        }

        

        static void displayWelcomeMessage()
        {
            //Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t**************************************");
            Console.WriteLine("\t\t\t\t**** Welcome to MoviePlex Theatre ****");
            Console.WriteLine("\t\t\t\t**************************************");
            Console.ForegroundColor = ConsoleColor.White;

        }

        

        static userType InitializeAdmin()
        {
            Console.WriteLine("\n Please Select From The Following Options");
            Console.WriteLine("1: Administrator");
            Console.WriteLine("2: Guests");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlease enter your selection:1 or 2?");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            string user_input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            bool isValidInput = checkForInteger(user_input,out int ui);

            userType currentUser = userType.Admin;

            
            if (isValidInput)
            {
       
                if(ui == 1)
                {
                    currentUser = userType.Admin;
                }

                else if(ui == 2)
                { 
                    currentUser = userType.Guest;
                }

                else
                {
                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine("\nYou can only enter one among the two integer values : '1 for Admin entry' OR '2 for Guests entry' \n");
                   Console.ForegroundColor = ConsoleColor.White;
                   StartApplication_1();
                }
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nKindly provide input in the correct formaat.You can only enter one among the two integer values : '1 for Admin entry' OR '2 for Guests entry' \n");
                Console.ForegroundColor = ConsoleColor.White;
                StartApplication_1();

            }

            return currentUser;
        }

        static bool checkForInteger(string user_input,out int ui)
        {
            string temp = user_input;
            string temp2 = temp.Trim();
            string temp3 = temp2.Replace(" ", String.Empty);
            string user_input_formatted = temp3.ToLower();
            //Console.WriteLine(user_input_formatted);
            bool status = Int32.TryParse(user_input_formatted, out ui);
            return status;
        }

        //Show Age Rating instructions.
        static void displayAgeRating()
        {
         /*
         * G – General Audience, any age is good 
         * PG – We will take PG as 10 years or older 
         * PG-13 – We will take PG-13 as 13 years or older
         * R – We will take R as 15 years or older. 
         * NC-17 – We will take NC-17 as 17 years or older 
         */
            Console.WriteLine("Enter G for General Audience, which means all ages admitted .Nothing that would offend parents for viewing by children.");
            Console.WriteLine("Enter PG for Parental Guidance Suggested, which means viewer must be atleast 10 years or older. You can also enter numeric value 10.");
            Console.WriteLine("Enter PG-13 for Parental Guidance Strongly Cautioned, which means viewer must be atleast 13 years or older. You can also enter numeric value 13.");
            Console.WriteLine("Enter R for Restricted Access, which means viewer must be atleast 15 years or older. You can also enter numeric value 15.");
            Console.WriteLine("Enter NC-18 for No One under 18 admitted , which means viewer must be atleast 18 years or older. You can also enter numeric value 18 \n\n");
       
        }

        static void processAdmin()
        {
            authenticateAdmin();
        }

        static void authenticateAdmin()
        {

            int admin_authentication_failed_counter = 0;
            string flag1 = "";
            string adminPassword = "";
            int j = 5;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n'Please enter the admin password' OR 'press b or B, and hit enter to go back to the previous screen.'");// we have set admin password as admin123
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                string userInput = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.White;

                string inputPassword = userInput.Replace(" ", String.Empty);
                adminPassword = inputPassword.ToLower();

                //Validate Password
                if (adminPassword.Equals("b") || adminPassword.Equals("B"))
                {
                    flag1 = "BacktToStartApplication_1";
                    break;
                }

                else if (adminPassword.Equals("") || adminPassword.Equals(" "))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n \nPassword field can not be empty. Please try again.\n \n");
                    Console.ForegroundColor = ConsoleColor.White;         
                }
                
                else if (adminPassword.Equals("admin123"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAdmin Authentication Succeeded.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n \nAdmin Authentication Failed as You Entered Incorrect Admin Password.\n \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    admin_authentication_failed_counter++;

                    Console.WriteLine("\n \nYou Have {0} Number of Attempts Left. \n \n", --j);

                    if (j == 0)
                    {
                        Console.WriteLine("Taking You Back to the Previous Screen....\n\n");
                    }



                }
            }

            while (admin_authentication_failed_counter != 5);


            if (flag1.Equals("BacktToStartApplication_1"))
            {
                StartApplication_1();
            }

            else if (admin_authentication_failed_counter == 5)
            {
                StartApplication_1();
            }

            else
            {
                admin_home();
            }

        }

        static void processGuests()
        {
            //Console.WriteLine("processing guests");
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t\t\t\t\t\t *************************************\n");
            Console.WriteLine("\t\t\t\t\t\t *********** Welcome Guest ***********\n");
            Console.WriteLine("\t\t\t\t\t\t *************************************\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (MyMovieList is null || MyMovieList.Count==0)
            {
                Console.WriteLine("\nThere are no movies playing today. Kindly wait for the application admin to add movies, and retry again.\n");
                StartApplication_1();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nThere are {0} movies playing today.Please choose from the following movies.\n",MyMovieList.Count);
                Console.ForegroundColor = ConsoleColor.White;
                DisplayMovieList(MyMovieList);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string viewer_input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                bool status = checkForInteger(viewer_input,out int ui);
                if(status==true) // viewer has provided an integer input
                {
                    if(ui<0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You provided an invalid negative value. Kindly follow the list, and provide a numeric positive integer value corrsponding to the movie you want to watch.");
                        Console.ForegroundColor = ConsoleColor.White;
                        processGuests();
                    }

                    else if(ui==0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You provided zero as a value which is an invalid input. Kindly follow the list, and provide a numeric positive integer value corrsponding to the movie you want to watch.");
                        Console.ForegroundColor = ConsoleColor.White;
                        processGuests();
                    }

                    else if(ui>MyMovieList.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You provided a value which is greater than the highest code assigned among all running movies. Kindly follow the list, and provide a numeric positive integer value corrsponding to the movie you want to watch.");
                        Console.ForegroundColor = ConsoleColor.White;
                        processGuests();
                    }

                    else
                    {
                        verifyViewersAge(MyMovieList,ref ui);
                        
                        
                    }
                }
                else // viewer has provided a non-integer input
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You entered a non-integer value. You can only provide a numeric positive integer value corrsponding to the movie you want to watch.");
                    Console.ForegroundColor = ConsoleColor.White;
                    processGuests();
                }
            }
            
        }

        static void verifyViewersAge(List<Movie> MyMovieList,ref int ui)
        {
            ui = ui - 1;
            Movie m = MyMovieList[ui];
            string MovieName = m.getMovieName();
            string MovieAgeLimit = m.getMovieRatingOrAgeLimit();

            //Console.WriteLine(MyMovieList[ui].getMovieRatingOrAgeLimit());
            if (MyMovieList[ui].getMovieRatingOrAgeLimit().Equals("G"))
            {
                //Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Since you opted for a movie with age rating G or 'General Audience', which is viewable for all, you do not require age verfication.");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Grab your popcorns! Your movie '{0}', of age category {1} or over, is running!! Enjoy your movie!", MovieName, MovieAgeLimit);
                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {

            int ageLimit_int = 0;  
            string ageLimit_string = m.getMovieRatingOrAgeLimit();
            bool check = Int32.TryParse(ageLimit_string, out int result);

               if (check)
               {
                        ageLimit_int = result;
               }

               else
               {
                        //if (ageLimit_string.Equals("G"))
                        //{
                        //    //Console.WriteLine("equalled G");
                        //    ageLimit_int = 0;
                        //}

                        if (ageLimit_string.Equals("PG"))
                        {
                            //Console.WriteLine("equalled PG");
                            ageLimit_int = 10;
                        }

                        if (ageLimit_string.Equals("PG-13"))
                        {
                            //Console.WriteLine("equalled PG-13");
                            ageLimit_int = 13;
                        }

                        if (ageLimit_string.Equals("R"))
                        {
                            //Console.WriteLine("equalled R");
                            ageLimit_int = 15;
                        }

                        if (ageLimit_string.Equals("NC-18"))
                        {
                            // Console.WriteLine("equalled NC-17");
                            ageLimit_int = 18;
                        }

                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Please enter your age for verification");
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                string user_age = Console.ReadLine();
                bool isValidAge = checkForInteger(user_age, out int ui2);

                if (isValidAge == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You entered a non-integer value. Kindly input age in appropriate format as a positive integer value.");
                    Console.ForegroundColor = ConsoleColor.White;
                    processGuests();
                }
                else
                {
                    if (ui2 < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Age cannot be negative.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else if (ui2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Age cannot be zero.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    else if(ui2 > 130)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Age greater than 130 seems unrealistic. Did you mistakenly entered a wrong value? Kindly try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        processGuests();
                    }

                    else
                    {
                        if (ui2 < ageLimit_int)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry viewer, you are under-age to watch this movie.....taking you back to guest screen.");
                            Console.ForegroundColor = ConsoleColor.White;
                            processGuests();
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Grab your popcorns! Your movie '{0}', of age category {1} or over, is running!! Enjoy your movie!", MovieName, MovieAgeLimit);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                }

            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press M to go back to the Guest Main Menu");
            Console.WriteLine("Press S to go back to the Start Page");
            Console.WriteLine("Press E to voluntarily exit the application");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            String last_user_input = Console.ReadLine().Trim();
            Console.ForegroundColor = ConsoleColor.White;

            String lui_allCaps = last_user_input.ToUpper();
            last_user_input = lui_allCaps;

            if (last_user_input.Length > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input: You can only enter a single character, either 'M' to back back to Guest Menu or 'S' to go back to start page.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (last_user_input.Equals("M") || last_user_input.Equals("S") || last_user_input.Equals("E"))
                {
                    if (last_user_input.Equals("M"))
                    {
                        //go back to guest menu page
                        processGuests();
                    }
                    else if (last_user_input.Equals("S"))
                    {
                        //go back to start page
                        StartApplication_1();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine("**************************** Closing Application ****************************");
                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine("*************Application Closed, Thanks for using our movie application *****");
                        Console.WriteLine("*****************************************************************************");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Environment.Exit(0);
                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid character entered. Press either 'M' to back back to Guest Menu or 'S' to go back to start page.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
       

        static void admin_home()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n*******************************************************\n");
            Console.WriteLine("\n********** Welcome MoviePlex Administrator ************\n");
            Console.WriteLine("\n*******************************************************\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nHow many movies are playing today?: \n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            string movies_count = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Program.MyMovieList = new List<Movie>();
            bool flag = checkForInteger(movies_count, out int ui);
            

            int mcount;
            if (flag==false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nKindly enter input in correct format.Kindly enter an appropriate positive integer value which is less than 11.\n");
                Console.ForegroundColor = ConsoleColor.White;
                admin_home();
                
            }

            else if(ui<=0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou can only enter a number greater than zero. Kindly enter an appropriate positive integer value which is less than 11.\n");
                Console.ForegroundColor = ConsoleColor.White;
                admin_home();

            }

            else if(ui>10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou cannot enter a value greater than 10. Kindly enter an appropriate positive integer value which is less than 11.\n");
                Console.ForegroundColor = ConsoleColor.White;
                admin_home();
            }

            else
            {
                mcount = ui;
                EnterMovieList(ui,MyMovieList);

                string SatisfiedOrNot_Formatted = "";

                do
                  {

                        DisplayMovieList(MyMovieList);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nYour movies playing today are listed above. Are you satisfied? Y/N\n");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        string SatisfiedOrNot = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        string temp1 = SatisfiedOrNot.Trim();
                        string temp2 = temp1.Replace(" ", String.Empty);
                        SatisfiedOrNot_Formatted = temp2.ToLower();

                        if (SatisfiedOrNot_Formatted.Equals("y"))
                        {

                        //Console.WriteLine("If the user selects Y or y, they are taken to the starting options where the user can select to login as a guest or admin."); 
                        StartApplication_1();
                        }

                        else if (SatisfiedOrNot_Formatted.Equals("n"))
                        {

                        //Console.WriteLine("If the user selects N or n, they are moved back to the point where they are asked again how many movies are playing.");
                        admin_home();

                         }


                    else
                        {
                          Console.ForegroundColor = ConsoleColor.Red;
                          Console.WriteLine("Kindly enter correct input : Y for Yes and N for No\n");
                          Console.ForegroundColor = ConsoleColor.White;
                        }

                   }

               while (!(SatisfiedOrNot_Formatted.Equals("y") || SatisfiedOrNot_Formatted.Equals("n")));

            }

        }

        static void EnterMovieList(int mcount,List<Movie> MyMovieList)
        {
            
            for (int i = 1; i <= mcount; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPlease Enter Name of Movie {0}. \n", i);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string enteredName = Console.ReadLine().Trim();
                Console.ForegroundColor = ConsoleColor.White;
                string movie_name = enteredName.ToLower();
             
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPlease Enter The Rating or Age Limit For {0}. \n", enteredName);
                // Show Movie Rating //
                displayAgeRating();
                ///////////////////////
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string RatingOrAgeLimit = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                //checking for integer as age limit
                bool flag = checkForInteger(RatingOrAgeLimit, out int ui);
                if (flag == true) // which means user has input age as numeric
                { 
                   string ui_string = ui.ToString();
                   if(ui_string=="10" || ui_string=="13" || ui_string=="15" || ui_string=="18")
                      {
                        seedCollection(movie_name, ui_string, MyMovieList);
                      }
                   else
                      {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("\nKindly provide age limit in correct format, either an appropriate positive integer value or corresponding alphabet/ alphabetic sequence.\n");
                         Console.ForegroundColor = ConsoleColor.White;
                         i--;
                      }

                }
                if (flag == false)
                {
                    //checking for alphabet or alphabet sequence as age limit

                    /*Console.WriteLine("Enter G for General Audience, which means all ages admitted .Nothing that would offend parents for viewing by children.");
                   Console.WriteLine("Enter PG for Parental Guidance Suggested, which means viewer must be atleast 10 years or older. You can also enter numeric value 10");
                   Console.WriteLine("Enter PG-13 for Parental Guidance Strongly Cautioned, which means viewer must be atleast 13 years or older. You can also enter numeric value 13");
                   Console.WriteLine("Enter R for Restricted Access, which means viewer must be atleast 15 years or older. You can also enter numeric value 15");
                   Console.WriteLine("Enter NC-17 for No One 17 or under admitted , which means viewer must be atleast 18 years or older. You can also enter numeric value 18 \n");*/

                    string tempp1 = RatingOrAgeLimit.Trim();
                    string tempp2 = tempp1.Replace(" ",String.Empty);
                    string tempp3 = tempp2.ToLower();
                    RatingOrAgeLimit = tempp3;

                    if (RatingOrAgeLimit.Equals("g"))
                    {
                        //Console.WriteLine("inside g");

                        string ui_string = "G";
                        seedCollection(movie_name, ui_string, MyMovieList);
                    }

                    else if (RatingOrAgeLimit.Equals("pg"))
                    {
                        //Console.WriteLine("inside pg");
                        string ui_string = "PG";
                        seedCollection(movie_name, ui_string, MyMovieList);
                    }

                    else if (RatingOrAgeLimit.Equals("pg-13"))
                    {
                        //Console.WriteLine("inside pg-13");
                        string ui_string = "PG-13";
                        seedCollection(movie_name, ui_string, MyMovieList);
                    }

                    else if (RatingOrAgeLimit.Equals("r"))
                    {
                        //Console.WriteLine("inside r");
                        string ui_string = "R";
                        seedCollection(movie_name, ui_string, MyMovieList);
                    }

                    else if (RatingOrAgeLimit.Equals("nc-18"))
                    {
                        //Console.WriteLine("inside nc-18");
                        string ui_string = "NC-18";
                        seedCollection(movie_name, ui_string, MyMovieList);
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nKindly provide age limit in correct format, either an appropriate positive integer value or corresponding alphabet/ alphabetic sequence.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        i--; 
                        
                    }

                }

            }
            
        }

        static void seedCollection(string movie_name, string movie_age, List<Movie> MyMovieList)
        {
            Movie mymovie = null;
            mymovie = new Movie(movie_name, movie_age);
            MyMovieList.Add(mymovie);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Movie Details successfully saved");
            Console.ForegroundColor = ConsoleColor.White;

        }
        static void DisplayMovieList(List<Movie> MyMovieList)
        {
            int i = 1;
            foreach (Movie m in MyMovieList)
            {
                Console.WriteLine(i++ +". "+m.getMovieName() + " " + "{"+ m.getMovieRatingOrAgeLimit()+"}"); 
            }

            
        }
        
    }



    public class Movie
    {
        /*
         * G – General Audience, any age is good 
         * PG – We will take PG as 10 years or older 
         * PG-13 – We will take PG-13 as 13 years or older
         * R – We will take R as 15 years or older. 
         * NC-17 – We will take NC-17 as 17 years or older 
         */

        string movieTitle = "";
        string rating_or_ageLimit = "";
        public Movie(string mn, string ra)
        {
            this.movieTitle = mn;
            this.rating_or_ageLimit = ra;
        }

        public void setMovieName(string movie_name)
        {
            this.movieTitle = movie_name;
        }

        public string getMovieName()
        {
            return this.movieTitle;
        }

        public void setMovieRatingOrAgeLimit(string movie_name)
        {
            this.movieTitle = movie_name;
        }

        public string getMovieRatingOrAgeLimit()
        {
            return this.rating_or_ageLimit;
        }
    }


}


//pending
//thanks for using the application when closing
//remove all comments
//try using some graphical
