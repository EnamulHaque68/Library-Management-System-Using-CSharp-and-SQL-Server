using  LibraryManagementSystem.Entities;
using  LibraryManagementSystem.Enums;
using  LibraryManagementSystem.Factory;
using  LibraryManagementSystem.Manager;
using  LibraryManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  LibraryManagementSystem
{
 
    internal class Program
    {
        public static MemberRepo repo = new MemberRepo();
        static void Main(string[] args)
		{
			try
			{
				DoTask();
			}
			catch (Exception obj)
			{

                Console.WriteLine(obj.Message);
			}
			finally
			{
				Console.ReadLine();
			}
        }

        private static void DoTask()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t\t\t\t\t\t╔══════════════╗");
            Console.WriteLine("\t\t\t\t\t\t║    PROJECT   ║");
            Console.WriteLine("\t\t\t\t\t\t╚══════════════╝");
            Console.WriteLine("\t\t\t########################################################################\r");
            Console.ResetColor();

            Console.WriteLine("\n\t\t\t\t\tSubmitted By:");
            Console.WriteLine("\t\t\t\t\tTrainee Name   : Md. Enamul Haque");
            Console.WriteLine("\t\t\t\t\tTrainee ID     : 1292556");
            Console.WriteLine("\t\t\t\t\tTrainee Batch  : CS/SCSL-M/68/01");

            Console.WriteLine("\n\t\t\t\t\tSubmitted To:");
            Console.WriteLine("\t\t\t\t\tProject Consultant :Syed Zahidul Hasan");


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\t\t\t\t\t╔════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║   LIBRARY MANAGEMENT SYSTEM    ║");
            Console.WriteLine("\t\t\t\t\t╚════════════════════════════════╝");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\t\t\t=====================================================================\r");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("How many operation you want to like?\n***********************************\r");
            Console.WriteLine();
            Console.WriteLine();
            int op=Convert.ToInt32(Console.ReadLine());
           for (int i = 0; i < op; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(
                    "\t\t\t\t\t\tSelect Operation\n" +
                    "\t\t\t++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n" +
                    "\n1.---Read\n2.---Create\n3.---Update\n4.---Delete\n5.---Read Single Information"
                );

                Console.ResetColor();

                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        ShowAllMembers(0);
                        break;
                    case 2:
                        CreateNewMembers();
                        break;
                    case 3:
                        UpdateMembers();
                        break;
                    case 4:
                        DeleteMembers();
                        break;
                    case 5:
                        ShowAllMemberById();
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            }
        }

        private static void DeleteMembers()
        {
            Console.WriteLine("Enter Customer Id");
            int id = Convert.ToInt32(Console.ReadLine());
            repo.DeleteMember(id);
            ShowAllMembers(0);
        }

        private static void ShowAllMemberById()
        {
            Console.WriteLine("Enter Customer Id");
            int id = Convert.ToInt32(Console.ReadLine());
            ShowAllMembers(id);
        }

        private static void UpdateMembers()
        {
            Console.WriteLine("Enter Customer Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            EnterMembrType:
            Console.WriteLine("Enter Member Type:1.RegularMember 2.PremiumMember");
            int membertype = Convert.ToInt32(Console.ReadLine());
            MemberType type;
            try
            {
                type = (MemberType)(Enum.Parse(typeof(MemberType), membertype.ToString()));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto EnterMembrType;
;
            }
            if (membertype == 1)
            {
                type = MemberType.RegularMember;
            }
            else if (membertype == 2) 
            {
                type = MemberType.PremiumMember;
            }
            Console.WriteLine("Is the Registrar Member premium? true or false");
            bool resister=Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Enter Total Amount");
            double totalAmt = Convert.ToDouble(Console.ReadLine());
            Member upMem = new Member(id, name, email, type, resister,totalAmt, 0, 0);
            BaseMemberFactory factory = new MemberManagerFactory().CreateFactory(upMem);
            factory.ApplyDisCount();

            repo.UpdateMember(upMem);
            ShowAllMembers(0);
        }

        private static void CreateNewMembers()
        {
  
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            EnterMembrType:
            Console.WriteLine("Enter Member Type:1.RegularMember 2.PremiumMember");
            int membertype = Convert.ToInt32(Console.ReadLine());
            MemberType type;
            try
            {
                type = (MemberType)(Enum.Parse(typeof(MemberType), membertype.ToString()));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto EnterMembrType;
            }
            if (membertype == 1)
            {
                type = MemberType.RegularMember;
            }
            else if (membertype == 2)
            {
                type = MemberType.PremiumMember;
            }
           
            Console.WriteLine("Is the Registrar Member Premium? true or false");
            bool register = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Enter Total Amount");
            double totalAmt = Convert.ToDouble(Console.ReadLine());
            
          Member newMember = new Member(0, name, email, type,register, totalAmt, 0, 0);
            BaseMemberFactory factory = new MemberManagerFactory().CreateFactory(newMember);
            factory.ApplyDisCount();
            repo.CreateMember(newMember);
            ShowAllMembers(0);
        }
      
        private static void ShowAllMembers(int id)
        {
      
        List<Member> list;

            if (id > 0)
                list = repo.GetAllMembers().Where(m => m.MemberId == id).ToList();
            else
                list = repo.GetAllMembers().ToList();

            if (list == null || list.Count == 0)
            {
                Console.WriteLine("No Member Found!");
                return;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\t\t\t\t\t\tMEMBER LIST\n\t\t\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.ResetColor();
            foreach (var item in list)
            {
              
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("╔═════╦═══════════════╦════════════════════╦═══════════════╦════════════════════╦════════════╦════════════╦══════════╗");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(
                    "|   ID|Member Name    |Email               |Member Type    |Premium Member      | TotalAmount|DiscountPrct| PayAmount|"
                                 );
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("╠═════╬═══════════════╬════════════════════╬═══════════════╬════════════════════╬════════════╬════════════╬══════════╣");
                Console.ResetColor();
                Console.WriteLine(
                    String.Format(
                        "|{0,5}|{1,-15}|{2,-20}|{3,-15}|{4,-20}|{5,12}|{6,12}|{7,10}|",
                        item.MemberId,
                        item.MemberName,
                        item.MemberEmail,
                        item.MembType,
                        item.RegisterMember,
                        item.TotalAmount,
                        item.DiscountPercentage,
                        item.PayAmount
                    )
                );
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("╚═════╩═══════════════╩════════════════════╩═══════════════╩════════════════════╩════════════╩════════════╩══════════╝");
                Console.ResetColor();

            }
          

        }

    }
}
