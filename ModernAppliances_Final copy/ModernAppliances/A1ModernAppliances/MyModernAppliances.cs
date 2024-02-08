using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;
using System.Runtime.CompilerServices;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {         
            Console.WriteLine("Enter the item number of an appliance: ");
            long itemNum = 0;
            if (!long.TryParse(Console.ReadLine(), out itemNum))
            {
                // Handle invalid input (e.g., non-numeric input)
                Console.WriteLine("Invalid input. Please enter a valid item number.");
                return;
            }
            Appliance foundAppliance = null;
            foreach (var appliance in Appliances)
            {
                // Test if appliance item number equals entered item number
                if (appliance.ItemNumber == itemNum)
                {
                    // Assign appliance in the list to foundAppliance variable
                    foundAppliance = appliance;

                    // Break
                    break;
                }
            }
            if (foundAppliance == null)
            {
                // No appliances found 
                Console.WriteLine("No appliances found with that item number.");
            }
            else
            {
                // appliance was found
                // Test if found appliance is available
                if (foundAppliance.IsAvailable)
                {
                    // Checkout found appliance
                    foundAppliance.Checkout();
                    // Write "Appliance has been checked out."
                    Console.WriteLine("Appliance has been checked out.");
                }
                else
                {
                    //appliance isn't available
                   
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }
   
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
           
            Console.WriteLine("Enter brand to search for:");
            string enteredBrand = Console.ReadLine();
       
            List<Appliance> foundAppliances = new List<Appliance>();

            // Iterate through loaded appliances
            foreach (var appliance in Appliances)
            {
                // Test if the current appliance brand matches what the user entered
                if (appliance.Brand.Equals(enteredBrand, StringComparison.OrdinalIgnoreCase))
                {
                    // Add the current appliance in the list to the found list
                    foundAppliances.Add(appliance);
                }
            }
           
            DisplayAppliancesFromList(foundAppliances, 0);
            
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options");
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");
            

            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"
            
            // Write "Enter number of doors: "
            Console.WriteLine("Enter number of doors wanted");
            
            // Create variable to hold entered number of doors
            string doorsWanted = Console.ReadLine();
            // Get user input as string and assign to variable

            // Convert user input from string to int and store as number of doors variable.
            if (!int.TryParse(doorsWanted, out int numberOfDoors))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }
            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();

            // Iterate/loop through Appliances
            foreach (var appliance in Appliances)
            {

                if (appliance is Refrigerator refrigerator)
                {
                    if (numberOfDoors == 0 || refrigerator.Doors == numberOfDoors)
                    {
                        found.Add(appliance);
                    }
                }
            }

            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"
            // Console.WriteLine("Possible Options for grade");
            // Console.WriteLine("0 - Any");
            // Console.WriteLine("1 - Residential");
            // Console.WriteLine("2 - Commercial");
            // Write "0 - Any"
            // Write "1 - Residential"
            // Write "2 - Commercial"

            // Write "Enter grade:"
           // Console.WriteLine("what grade is requested");

            // Get user input as string and assign to variable
           // string gradeInput = Console.ReadLine();
            // Create grade variable to hold grade to find (Any, Residential, or Commercial)
           // string grade;

           // if (gradeInput == "0")
            {
               // grade = "Any";
            }
           // else if (gradeInput == "1")
            {
               // grade = "Residential";
            }
           // else if (gradeInput == "2")
            {
                //grade = "Commercial";
            }
           // else
            {
               // Console.WriteLine("Invalid option");
                //return;
            }


            // Write "Possible options:"
            Console.WriteLine("Possible options for voltage");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt");
            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"

            // Write "Enter voltage:"
            Console.WriteLine("Please choose a possible option");
            // Get user input as string
            string voltInput = Console.ReadLine();
            // Create variable to hold voltage
            string volt;
            if (voltInput == "0")
            {
                volt = "Any";
            }
            else if (voltInput == "1")
            {
                volt = "18 Volts";
            }
            else if (voltInput == "2")
            {
                volt = "24 Volts";
            }
            else
            {
                Console.WriteLine("Invalid choice");
                return;
            }
            // Test input is "0"
                // Assign 0 to voltage
            // Test input is "1"
                // Assign 18 to voltage
            // Test input is "2"
                // Assign 24 to voltage
            // Otherwise
                // Write "Invalid option."
                // Return to calling (previous) method
                // return;

            // Create found variable to hold list of found appliances.
            List<Appliance> found = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance is Vacuum)
                {
                    Vacuum vacuum = (Vacuum)appliance;

                    if (volt == "Any" || (volt == "18 Volts" && vacuum.BatteryVoltage == 18 ) ||  (volt == "24 Volts" && vacuum.BatteryVoltage == 24))
                    {
                        found.Add(appliance);
                    }
                }
            }
            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options for Microwaves");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Work site");
            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"

            // Write "Enter room type:"
            Console.WriteLine("Enter room type");
            // Get user input as string and assign to variable
            string roomInput = Console.ReadLine();
            // Create character variable that holds room type
            string roomType;

            if (roomInput == "0")
            {
                roomType = "Any";
            }
            else if (roomInput == "1")
            {
                roomType = "Kitchen";
            }
            else if (roomInput == "2")
            {
                roomType = "Work site";
            }
            else
            {
                Console.WriteLine("Invalid option for room type");
                return;
            }
            // Test input is "0"
                // Assign 'A' to room type variable
            // Test input is "1"
                // Assign 'K' to room type variable
            // Test input is "2"
                // Assign 'W' to room type variable
            // Otherwise (input is something else)
                // Write "Invalid option."
                // Return to calling method
                // return;

            // Create variable that holds list of 'found' appliances
            List<Appliance> found = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance is Microwave)
                {
                    Microwave microwave = (Microwave)appliance;

                    if (roomType == "Any" || (roomType == "Kitchen" && microwave.RoomType == 'K') || (roomType == "Work site" && microwave.RoomType == 'W'))
                    {
                        found.Add(appliance);
                    }
                }
            }
            // Loop through Appliances
                // Test current appliance is Microwave
                    // Down cast Appliance to Microwave

                    // Test room type equals 'A' or microwave room type
                        // Add current appliance in list to found list

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options for dishwashers");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate");
            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"

            // Write "Enter sound rating:"
            Console.WriteLine("Enter the Sound rating wanted");
            // Get user input as string and assign to variable
            string dishInput = Console.ReadLine();
            // Create variable that holds sound rating
            string soundRating;

            if (dishInput == "0")
            {
                soundRating = "Any";
            }
            else if (dishInput == "1")
            {
                soundRating = "Qt";
            }
            else if (dishInput == "2")
            {
                soundRating = "Qr";
            }
            else if (dishInput == "3")
            {
                soundRating = "Qu";
            }
            else if (dishInput == "4")
            {
                soundRating = "M";
            }
            else
            {
                Console.WriteLine("Invalid option");
                return;
            }
            // Test input is "0"
            // Assign "Any" to sound rating variable
            // Test input is "1"
            // Assign "Qt" to sound rating variable
            // Test input is "2"
            // Assign "Qr" to sound rating variable
            // Test input is "3"
            // Assign "Qu" to sound rating variable
            // Test input is "4"
            // Assign "M" to sound rating variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method

            // Create variable that holds list of found appliances
            List<Appliance> found = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance is Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;

                    if (soundRating == "Any" || dishwasher.SoundRating.ToString() == soundRating)
                    {
                        found.Add(appliance);
                    }
                }
            }
            // Loop through Appliances
                // Test if current appliance is dishwasher
                    // Down cast current Appliance to Dishwasher

                    // Test sound rating is "Any" or equals soundrating for current dishwasher
                        // Add current appliance in list to found list

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Appliance Types"
            //Console.WriteLine("Options for Appliance types");
            //Console.WriteLine("0 - Any");
            //Console.WriteLine("1 - Refrigerators");
            //Console.WriteLine("2 - Vacuums");
            //Console.WriteLine("3 - Microwaves");
            //Console.WriteLine("4 - Dishwashers");
            // Write "0 - Any"
            // Write "1 – Refrigerators"
            // Write "2 – Vacuums"
            // Write "3 – Microwaves"
            // Write "4 – Dishwashers"

            // Write "Enter type of appliance:"
            //Console.WriteLine("Please enter what type of appliances you would like");
            // Get user input as string and assign to appliance type variable
            string applianceInput = "0";
            // Write "Enter number of appliances: "
            Console.WriteLine("Please enter the number of appliances wanted");
            // Get user input as string and assign to variable
            string amountWanted = Console.ReadLine();
            // Convert user input from string to int
            int numWanted = int.Parse(amountWanted);
            // Create variable to hold list of found appliances
            List <Appliance> found = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (applianceInput == "0")
                {
                    found.Add(appliance);
                }
                //else if (applianceInput == "1" && appliance is Refrigerator)
                //{
                //    found.Add(appliance);
                //}
                //else if (applianceInput == "2" && appliance is Vacuum)
                //{
                  //  found.Add(appliance);
                //}
                //else if (applianceInput == "3" && appliance is Microwave)
               // {
                  //  found.Add(appliance);
                //}
                //else if (applianceInput == "4" && appliance is Dishwasher)
                //{
                  //  found.Add(appliance);
               // }
                else if (applianceInput != "0")
                {
                    Console.WriteLine("Invalid input, Please try again");
                    return;
                }

            }

            found.Sort(new RandomComparer());
            
            DisplayAppliancesFromList(found, numWanted);
            // Loop through appliances
                // Test inputted appliance type is "0"
                    // Add current appliance in list to found list
                // Test inputted appliance type is "1"
                    // Test current appliance type is Refrigerator
                        // Add current appliance in list to found list
                // Test inputted appliance type is "2"
                    // Test current appliance type is Vacuum
                        // Add current appliance in list to found list
                // Test inputted appliance type is "3"
                    // Test current appliance type is Microwave
                        // Add current appliance in list to found list
                // Test inputted appliance type is "4"
                    // Test current appliance type is Dishwasher
                        // Add current appliance in list to found list

            // Randomize list of found appliances
            // found.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, num);
        }
    }
}
