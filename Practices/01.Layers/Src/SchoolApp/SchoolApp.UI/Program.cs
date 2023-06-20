//Main

try
{
    Menu();

}
catch (Exception ex)
{
    Console.WriteLine("Critical Error: {0}", ex.Message);
}
//Functions
void Menu()
{
    char option = ' ';

    while (option != '0')
    {
        option = GetOption();
        ExecuteOption(option);

        Console.WriteLine("\nPress any key to EXIT... ");
        Console.ReadKey();
    }


}

char GetOption()
{
    PrintMenu();

    char option = Console.ReadKey().KeyChar;
    Console.WriteLine();

    return option;
}

void CreateStudent(){
    Console.Clear();
    Console.WriteLine("Create Student");
    string FirstName = "";
    string LastName = "";
    string Date;
    DateTime DateOfBirth;
    string Sex = "";

    do{
    Console.WriteLine("Ingrese el nombre (máximo 50 carácteres): ");
    FirstName = Console.ReadLine();
    }while(FirstName.Length > 50);

    do{
    Console.WriteLine("Ingrese el apellido (máximo 50 carácteres): ");
    LastName = Console.ReadLine();
    }while(LastName.Length > 50);

    do{
    Console.WriteLine("Ingrese su fecha de nacimiento (aaaa-mm-dd): ");
    Date = Console.ReadLine();
    string[] subs = Date.Split('-');
    int aaaa = Convert.ToInt32(subs[0]);
    int mm = Convert.ToInt32(subs[1]);
    int dd = Convert.ToInt32(subs[2]);

    DateOfBirth = new DateTime(aaaa, mm, dd);

    }while(LastName.Length > 50);

    do{
    Console.WriteLine("Ingrese su sexo (M/F): ");
    Sex = Console.ReadLine();
    }while(Sex != "M" && Sex != "F");

    Console.WriteLine("Nombre " + FirstName);
    Console.WriteLine("Apellido " + LastName);   
    Console.WriteLine("Fecha " + DateOfBirth);
    Console.WriteLine("Sexo " + Sex);
}

void ReadStudent(){
    Console.Clear();
    Console.WriteLine("Read Student");
    int Id = 0;
    string val;
    Console.WriteLine("Ingrese el id del estudiante: ");
    val = Console.ReadLine();
    Id = Convert.ToInt32(val);
}

void UpdateStudent(){
    Console.Clear();
    Console.WriteLine("Update Student");
    int Id = 0;
    string val;
    Console.WriteLine("Ingrese el id del estudiante: ");
    val = Console.ReadLine();
    Id = Convert.ToInt32(val);
    int Opcion;

    string FirstName = "";
    string LastName = "";
    string Date;
    DateTime DateOfBirth;
    string Sex = "";

    //BÚSQUEDA DE ESTUDIANTE

    Console.WriteLine("Seleccione el atributo que desea cambiar: ");
    Console.WriteLine("1. Nombre");
    Console.WriteLine("2. Apellido");
    Console.WriteLine("3. Fecha de nacimiento");
    Console.WriteLine("4. Sexo");
    
    Opcion = Convert.ToInt32(Console.ReadLine());
    switch (Opcion)
    {
        case 1: 
            do{
            Console.WriteLine("Ingrese el nombre (máximo 50 carácteres): ");
            FirstName = Console.ReadLine();
            }while(FirstName.Length > 50);
            break;

        case 2:
            do{
            Console.WriteLine("Ingrese el apellido (máximo 50 carácteres): ");
            LastName = Console.ReadLine();
            }while(LastName.Length > 50);
            break;

        case 3:
            do{
            Console.WriteLine("Ingrese su fecha de nacimiento (aaaa-mm-dd): ");
            Date = Console.ReadLine();
            string[] subs = Date.Split('-');
            int aaaa = Convert.ToInt32(subs[0]);
            int mm = Convert.ToInt32(subs[1]);
            int dd = Convert.ToInt32(subs[2]);

            DateOfBirth = new DateTime(aaaa, mm, dd);

            }while(LastName.Length > 50);
            break;

        case 4:
            do{
            Console.WriteLine("Ingrese su sexo (M/F): ");
            Sex = Console.ReadLine();
            }while(Sex != "M" && Sex != "F");
            break;

        default:
            Console.WriteLine("InvalidOption");
            break ;

    }
    
}

void DeleteStudent(){
    Console.Clear();
    Console.WriteLine("Delete Student");
    int Id = 0;
    string val;
    Console.WriteLine("Ingrese el id del estudiante: ");
    val = Console.ReadLine();
    Id = Convert.ToInt32(val);

    //BÚSQUEDA DEL ESTUDIANTE
}

void PrintMenu()
{
    Console.Clear  ();
    Console.WriteLine("Students - CRUD");
    Console.WriteLine("----------------------------------");
    Console.WriteLine("1. Create");
    Console.WriteLine("2. Read");
    Console.WriteLine("3. Update");
    Console.WriteLine("4. Delete");
    Console.WriteLine("0. Exit");
    Console.WriteLine("Select Option: ");
}

void ExecuteOption(char option)
{
    switch (option)
    {
        case '0': 
            Console.WriteLine("Exit");
            break;

        case '1':
            CreateStudent();
            break;

        case '2':
            ReadStudent();
            break;

        case '3':
            UpdateStudent();
            break;

        case '4':
            DeleteStudent();
            break;

        default:
            Console.WriteLine("InvalidOption");
            break ;

    }
}