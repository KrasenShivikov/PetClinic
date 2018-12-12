namespace PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PetClinic.Classes;

    class StartUp
    {
        static void Main()
        {
            List<Clinic> listOfClinics = new List<Clinic>();
            List<Pet> listOfPets = new List<Pet>();

            int number = int.Parse(Console.ReadLine());


            for (int i = 0; i < number; i++)
            {

                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                try
                {
                    switch (input[0])
                    {
                        case "CreatePet":
                            CreatePet(input, listOfPets);
                            break;
                        case "CreateClinic":
                            CreateClinic(input, listOfClinics);
                            break;
                        case "Add":
                            Console.WriteLine(Add(input, listOfClinics, listOfPets));
                            break;
                        case "Release":
                            Console.WriteLine(Release(input, listOfClinics));
                            break;
                        case "HasEmptyRooms":
                            Console.WriteLine(HasEmptyRooms(input, listOfClinics));
                            break;
                        case "Print":
                            Print(input, listOfClinics);
                            break;
                        case "PrintRoom":
                            PrintRoom(input, listOfClinics);
                            break;
                        default:
                            Console.WriteLine("Invalid Command");
                            break;

                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                
            }
        }

        public static void CreatePet(string[] input, List<Pet> listOfPets)
        {
            Pet pet = new Pet(input[1], int.Parse(input[2]), input[3]);

            listOfPets.Add(pet);
        }

        public static void CreateClinic(string[] input, List<Clinic> listOfClinics)
        {
            ListOfRooms<Room> rooms = new ListOfRooms<Room>();

            int numberOfRooms = int.Parse(input[2]);

            for (int i = 0; i < numberOfRooms; i++)
            {
                Room room = new Room();
                room.Number = i + 1;
                rooms.Add(room);
            }

            Clinic clinic = new Clinic(input[1], numberOfRooms, rooms);
            listOfClinics.Add(clinic);
        }

        public static bool Add(string[] input, List<Clinic> listOfClinics, List<Pet> listOfPets)
        {
            Clinic clinic = new Clinic();

            clinic = listOfClinics.Where(c => c.Name.Equals(input[2])).First();

            Pet pet = new Pet();

            pet = listOfPets.Where(p => p.Name.Equals(input[1])).First();

            foreach (var room in clinic.ListOfRooms)
            {
                if (room.IsEmty())
                {
                    room.Pet = pet;

                    return true;
                }
            }
            return false;

        }

        public static bool Release(string[] input, List<Clinic> listOfClinics)
        {
            Clinic clinic = new Clinic();

            clinic = listOfClinics.Where(c => c.Name.Equals(input[1])).First();

            int firstIndex = (clinic.ListOfRooms.Count() - 1) / 2;


            for (int i = firstIndex; i < clinic.ListOfRooms.Count(); i++)
            {
                if (!clinic.ListOfRooms[i].IsEmty())
                {
                    clinic.ListOfRooms[i].Pet = null;

                    return true;
                }
            }

            for (int index = 0; index < firstIndex; index++)
            {
                if (!clinic.ListOfRooms[index].IsEmty())
                {
                    clinic.ListOfRooms[index].Pet = null;

                    return true;
                }
            }

            return false;
        }


        public static bool HasEmptyRooms(string[] input, List<Clinic> listOfClinics)
        {
            Clinic clinic = new Clinic();

            clinic = listOfClinics.Where(c => c.Name.Equals(input[1])).First();

            foreach (var room in clinic.ListOfRooms)
            {
                if (room.IsEmty())
                {
                    return true;
                }
            }

            return false;
        }

        public static void Print(string[] input, List<Clinic> listOfClinics)
        {
            Clinic clinic = new Clinic();

            clinic = listOfClinics.Where(c => c.Name.Equals(input[1])).First();

            for (int i = 0; i < clinic.ListOfRooms.Count(); i++)
            {
                if (clinic.ListOfRooms[i].IsEmty())
                {
                    Console.WriteLine("Room empty");
                }
                else
                {
                    Console.WriteLine($"{clinic.ListOfRooms[i].Pet.Name} {clinic.ListOfRooms[i].Pet.Age} {clinic.ListOfRooms[i].Pet.Name}");
                }
            }


        }

        public static void PrintRoom(string[] input, List<Clinic> listOfClinics)
        {
            Clinic clinic = new Clinic();

            clinic = listOfClinics.Where(c => c.Name.Equals(input[1])).First();

            Room room = new Room();

            room = clinic.ListOfRooms.Where(r => r.Number.Equals(int.Parse(input[2]))).First();

            if (room.IsEmty())
            {
                Console.WriteLine("Room Empty");
            }

            else
            {
                Console.WriteLine($"{room.Pet.Name} {room.Pet.Age} {room.Pet.Kind}");
            }

            //foreach (var clinic in listOfClinics)
            //{
            //    if (clinic.Name == input[1])
            //    {
            //        for (int i = 0; i < clinic.ListOfRooms.Count(); i++)
            //        {
            //            if (clinic.ListOfRooms[i].Number == roomNumber && clinic.ListOfRooms[i].IsEmty())
            //            {
            //                Console.WriteLine("Room empty");
            //            }

            //            else if (clinic.ListOfRooms[i].Number == roomNumber && !clinic.ListOfRooms[i].IsEmty())
            //            {
            //                Console.WriteLine($"{clinic.ListOfRooms[i].Pet.Name} {clinic.ListOfRooms[i].Pet.Age} {clinic.ListOfRooms[i].Pet.Name}");
            //            }
            //        }
            //    }
            //}
        }
    }
}
