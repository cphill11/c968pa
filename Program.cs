using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security;

namespace c968pa
{
    internal static class Program

    {
        //Allow Inventory.Products and Invenotory.AllParts to be accessed t/o program
        public static Inventory Inventory = new Inventory();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //Seed data for demo purposes

            Program.Inventory.AllParts.Add(new InHouse
            {
                PartID = 1,
                Name = "Wheel",
                Price = 25.00m,
                InStock = 10,
                Min = 1,
                Max = 50,
                MachineID = 123
            });

           Program.Inventory.AllParts.Add(new Outsourced
            {
                PartID = 2,
                Name = "Seat",
                Price = 15.00m,
                InStock = 5,
                Min = 1,
                Max = 20,
                CompanyName = "Seats Inc"
            });

            // ✅ ADD TEST PRODUCT
            Program.Inventory.Products.Add(new Product
            {
                ProductID = 1,
                Name = "Bicycle",
                Price = 199.99m,
                InStock = 3,
                Min = 1,
                Max = 10
            });

           
        Application.Run(new Form1());
        }
    }
}
